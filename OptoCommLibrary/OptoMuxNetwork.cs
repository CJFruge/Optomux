using System;
using System.Collections.Generic;

namespace OptoCommLibrary
{
    public enum DeviceType { B1, B2, E1, E2};
    public class OptoMuxNetwork
    {
        private string optoMuxNetworkName;
        //private List<OptoDevice> optoMuxDevices;
        private OptoMuxComm optoMuxComm;
        private Dictionary<int,DeviceType> optoDeviceDictionary; 
        public string OptoMuxNetworkName { get => optoMuxNetworkName; set => optoMuxNetworkName = value; }
        public OptoMuxNetwork()
        {
            optoDeviceDictionary = new Dictionary<int,DeviceType>();
            optoMuxComm = new OptoMuxComm();
        }
        public void AddDevice(int deviceID, DeviceType deviceType)
        {
            try
            {
                optoDeviceDictionary.Add(deviceID,deviceType);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void OpenNetwork(string serialPortName) => optoMuxComm.OpenPort(serialPortName);
        public void CloseNetwork() => optoMuxComm.ClosePort();
    }
}