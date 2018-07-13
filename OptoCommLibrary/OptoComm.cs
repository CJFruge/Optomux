using System;
using System.IO.Ports;

namespace OptoCommLibrary
{
    public struct SerialPortOptions
    {
        public int baudRate;
        public int dataBits;
        public Parity parity;
        public StopBits stopBits;
        public Handshake handshake;
    }
    class OptoMuxComm
    {
        private SerialPort serialPort;
        private SerialPortOptions serialPortOptions;
        /// <summary>
        /// Serial Port Name
        /// 
        /// Windows 'COMn', where n = 1 to 99
        /// 
        /// Linux 'TTySn' or 'TTYUSBn', where n = 0 to 3
        /// </summary>
        public bool OpenPort(string serialPortName)
        {
            try
            {
                serialPort = new SerialPort(serialPortName);
                serialPort.BaudRate = serialPortOptions.baudRate;
                serialPort.DataBits = serialPortOptions.dataBits;
                serialPort.Parity = serialPortOptions.parity;
                serialPort.StopBits = serialPortOptions.stopBits;
                serialPort.Handshake = serialPortOptions.handshake;
                serialPort.Open();
            }             
            catch(System.IO.IOException e) 
            {
                // todo, log this exception as probable bad device name
                throw e; // its a library
            }
            catch (Exception e)
            {
                // it's a library
                throw e;
            }
        return true;
        } 
        
        public OptoMuxComm()
        {
            serialPortOptions = new SerialPortOptions();
            serialPortOptions.baudRate = 19200;
            serialPortOptions.dataBits = 8;
            serialPortOptions.parity = Parity.None;
            serialPortOptions.stopBits = StopBits.One;
            serialPortOptions.handshake = Handshake.RequestToSend;
        }
    }
}
