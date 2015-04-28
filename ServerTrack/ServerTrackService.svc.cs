using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServerTrack
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ServerTrackService : IServerTrackService
    {
        public ServerTrackService()
        {
            serverData = new ConcurrentDictionary<string, SortedList<DateTime, LoadTuple>>();
        }

        public void RecordServerLoad(string serverName, double CPULoad, double RAMLoad)
        {
            if (!serverData.ContainsKey(serverName))
            {
                serverData.AddOrUpdate(serverName, new SortedList<DateTime, LoadTuple>(), (key, oldValue) => oldValue);
            }

            LoadTuple inData = new LoadTuple(CPULoad, RAMLoad);

            serverData[serverName].Add(DateTime.Now, inData);
        }

        public Dictionary<string, SortedList<DateTime, LoadTuple>> DisplayServerLoad(string serverName)
        {
            Dictionary<string, SortedList<DateTime, LoadTuple>> averageData = new Dictionary<string, SortedList<DateTime, LoadTuple>>();
            averageData.Add("last60Minutes", new SortedList<DateTime, LoadTuple>());
            averageData.Add("last24Hours", new SortedList<DateTime, LoadTuple>());

            DateTime sampledNow = DateTime.Now;

            if (!serverData.ContainsKey(serverName))
            {
                return averageData;
            }

            for (DateTime d = sampledNow.AddMinutes(-60); d < sampledNow; d = d.AddMinutes(1))
            {
                var minuteList = from data in serverData[serverName]
                                 where data.Key > d && data.Key < d.AddMinutes(1)
                                 select data.Value;

                double minuteSumCPULoad = 0;
                double minuteSumRAMLoad = 0;

                foreach (LoadTuple lt in minuteList)
                {
                    minuteSumCPULoad += lt.CPULoad;
                    minuteSumRAMLoad += lt.RAMLoad;
                }

                double minuteAverageCPULoad = minuteSumCPULoad / minuteList.Count();
                double minuteAverageRAMLoad = minuteSumRAMLoad / minuteList.Count();

                averageData["last60Minutes"].Add(d, new LoadTuple(minuteAverageCPULoad, minuteAverageRAMLoad));
            }
            for (DateTime d = sampledNow.AddHours(-24); d < sampledNow; d = d.AddHours(1))
            {
                var hourList = from data in serverData[serverName]
                                 where data.Key > d && data.Key < d.AddHours(1)
                                 select data.Value;

                double hourSumCPULoad = 0;
                double hourSumRAMLoad = 0;

                foreach (LoadTuple lt in hourList)
                {
                    hourSumCPULoad += lt.CPULoad;
                    hourSumRAMLoad += lt.RAMLoad;
                }

                double hourAverageCPULoad = hourSumCPULoad / hourList.Count();
                double hourAverageRAMLoad = hourSumRAMLoad / hourList.Count();

                averageData["last24Hours"].Add(d, new LoadTuple(hourAverageCPULoad, hourAverageRAMLoad));
            }

            return averageData;
        }

        private ConcurrentDictionary<string, SortedList<DateTime, LoadTuple>> serverData;
    }
}
