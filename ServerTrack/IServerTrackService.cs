using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServerTrack
{
    [ServiceContract]
    public interface IServerTrackService
    {

        [OperationContract]
        void RecordServerLoad(string serverName, double CPULoad, double RAMLoad);

        [OperationContract]
        Dictionary<string, SortedList<DateTime, LoadTuple>> DisplayServerLoad(string serverName);
    }

    [DataContract]
    public class LoadTuple
    {
        double _CPULoad = 0;
        double _RAMLoad = 0;

        public LoadTuple()
        {

        }

        public LoadTuple(double inCPULoad, double inRAMLoad)
        {
            CPULoad = inCPULoad;
            RAMLoad = inRAMLoad;
        }

        [DataMember]
        public double CPULoad
        {
            get { return _CPULoad; }
            set { _CPULoad = value; }
        }

        [DataMember]
        public double RAMLoad
        {
            get { return _RAMLoad; }
            set { _RAMLoad = value; }
        }
    }
}
