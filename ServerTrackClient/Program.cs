using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerTrackClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServerTrackServiceReference.ServerTrackServiceClient client = new ServerTrackServiceReference.ServerTrackServiceClient())
            {
                //Record data concurrently
                List<Thread> threadList = new List<Thread>();
                for (int i = 0; i < 1000; ++i)
                {
                    threadList.Add(new Thread(
                                   new ThreadStart(
                                   new ClientRecordThread(String.Format("Server{0}", i)).ThreadProc)));
                }

                foreach (Thread t in threadList)
                {
                    t.Start();
                }
                foreach (Thread t in threadList)
                {
                    t.Join();
                }

                //Display results for one of the servers
                var server1Data = client.DisplayServerLoad("Server1");

                Console.Out.WriteLine("Server1 60 Minute averages");
                foreach (DateTime d in server1Data["last60Minutes"].Keys)
                {
                    Console.Out.WriteLine("{0}   CPU:{1}  RAM:{2}", 
                                            d, 
                                            server1Data["last60Minutes"][d].CPULoad,
                                            server1Data["last60Minutes"][d].RAMLoad);

                }
                Console.Out.WriteLine("Server1 24 Hour averages");
                foreach (DateTime d in server1Data["last24Hours"].Keys)
                {
                    Console.Out.WriteLine("{0}   CPU:{1}  RAM:{2}", 
                                            d,
                                            server1Data["last24Hours"][d].CPULoad,
                                            server1Data["last24Hours"][d].RAMLoad);

                }


            }
        }

        private class ClientRecordThread
        {
            private string serverName;
            private ServerTrackServiceReference.ServerTrackServiceClient client; 

            public ClientRecordThread (string serverName)
            {
                this.serverName = serverName;
                this.client = new ServerTrackServiceReference.ServerTrackServiceClient();
            }

            public void ThreadProc()
            {
                client.RecordServerLoad(serverName, PerformanceCounters.getCurrentCpuUsage(), PerformanceCounters.getAvailableRAM());
            }
        }

        private static class PerformanceCounters
        {
            public static double getCurrentCpuUsage()
            {
                PerformanceCounter cpuCounter = new PerformanceCounter();

                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";
                cpuCounter.NextValue();
                System.Threading.Thread.Sleep(500);
                double cpuUsage = Convert.ToDouble(cpuCounter.NextValue());
                return cpuUsage;
            }

            public static double getAvailableRAM()
            {
                PerformanceCounter ramCounter;
                
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                double availableRAM = Convert.ToDouble(ramCounter.NextValue());
                return availableRAM;
            } 
        }
    }
}
