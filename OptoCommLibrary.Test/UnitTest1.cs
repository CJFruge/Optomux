using System;
using Xunit.Abstractions;
using Xunit;
using OptoCommLibrary;

namespace OptoCommLibrary.Test
{
    public class OptoMuxNetworkTest
    {
        //private readonly ITestOutputHelper _output;
       private readonly OptoMuxNetwork _testObject;
        public OptoMuxNetworkTest()
        {
            _testObject = new OptoMuxNetwork();
        }
        [Fact]
        public void NetworkDeviceList() => Assert.NotNull(_testObject);

        [Fact]
        public void NetworkDeviceAdd()
        {
            _testObject.AddDevice(1,DeviceType.B1);
            // added B1 device id 1 ONCE
        }
        [Fact]
        public void NetworkDeviceAdd1()
        { 
            _testObject.AddDevice(1,DeviceType.B1);
            _testObject.AddDevice(1,DeviceType.B1);
            // added B1 device id 1 TWICE
        }
        [Fact]
        public void NetworkDeviceAdd2()
        { 
            _testObject.AddDevice(1,DeviceType.B1);
            _testObject.AddDevice(2,DeviceType.B1);
            // added B1 device id 1 and 2
        }
        [Fact]
        public void SimpleHardwareCheck()
        {
            // real hardware test
            _testObject.AddDevice(1,DeviceType.B1);
            _testObject.AddDevice(3,DeviceType.B2);
            _testObject.OpenNetwork("/dev/ttyUSB0");
            _testObject.GetDeviceData(">01F??\r");
            //Thread.Sleep(1000);
            string resp = _testObject.GetData();
            //_output.WriteLine($"device 01 responded: {resp}");
            _testObject.CloseNetwork();
        }
    }
    public class OptoMuxCommandTest
    {
        private readonly OptoMuxCommand _testObject;
        public OptoMuxCommandTest()
        {
            _testObject = new OptoMuxCommand();
        }
    
        [Fact]
        public void SimpleCommandCheck()
        {
            OMuxCommand omux =_testObject.OptoMuxCommandTemplate("Reset");
            Assert.NotNull(omux);
            //omux.Prefix = "nothing";
        }
    }
}
