using System;
using Xunit;
using OptoCommLibrary;

namespace OptoCommLibrary.Test
{
    public class OptoMuxNetworkTest
    {
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
            _testObject.OpenNetwork("ttyUSB0");
        }
    }
}
