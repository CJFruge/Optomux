using System;
//using System.IO.Ports;
using RJCP.IO.Ports;

namespace OptoCommLibrary
{
    

    class OptoMuxComm
    {
        private SerialPortStream serialPort;
        private int baudRate;
        private int dataBits;
        private Parity parity;
        private StopBits stopBits;
        private Handshake handshake;

        #region Properties
        public int BaudRate { get => baudRate; set => baudRate = value; }
        public int DataBits { get => dataBits; set => dataBits = value; }
        public Parity Parity { get => parity; set => parity = value; }
        public StopBits StopBits { get => stopBits; set => stopBits = value; }
        public Handshake Handshake { get => handshake; set => handshake = value; }
        #endregion
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
                serialPort = new SerialPortStream(serialPortName);
                serialPort.BaudRate = baudRate;
                serialPort.DataBits = dataBits;
                serialPort.Parity = parity;
                serialPort.StopBits = stopBits;
                serialPort.Handshake = handshake;
                serialPort.Open();
            }             
            catch(System.IO.IOException e) 
            {
                // TODO:, log this exception as probable bad device name
                throw e; // its a library
            }
            catch(Exception e)
            {
                // it's a library
                throw e;
            }
        return true;
        } 
        public void ClosePort()
        {
            try
            {
                serialPort.Close();
            }
            catch(System.IO.IOException e)
            {
                // TODO:, log this exception
                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public OptoMuxComm()
        {
            baudRate = 19200;
            dataBits = 8;
            parity = Parity.None;
            stopBits = StopBits.One;
            handshake = Handshake.Rts;
        }
    }
}
