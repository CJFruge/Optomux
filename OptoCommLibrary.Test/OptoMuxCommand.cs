using System;
using System.Collections.Generic;

namespace OptoCommLibrary
{
    public class OMuxCommand
    {
        private string prefix;
        private bool positions,modifier,data;
        private DeviceType deviceType;
        public string Prefix { get => prefix; }
        public bool Positions { get => positions; }
        public bool Modifier { get => modifier; }
        public bool Data { get => data; }
        public DeviceType DeviceType { get => deviceType; }

        internal OMuxCommand(string Prefix,bool Positions,bool Modifier,bool Data,DeviceType DeviceType)
        {
            prefix = Prefix; 
            positions = Positions; 
            data = Data; 
            deviceType = DeviceType;
        }
    }
    public class OptoMuxCommand
    {
         internal Dictionary<string,OMuxCommand> oMuxCmdDict;
        
        public OptoMuxCommand()
        {   
            oMuxCmdDict = new Dictionary<string,OMuxCommand>(); 
            oMuxCmdDict.Add("Power-Up_Clear",new OMuxCommand("A",false,false,false,DeviceType.All));
            oMuxCmdDict.Add("Reset",new OMuxCommand("B",false,false,false,DeviceType.All));
            oMuxCmdDict.Add("Identify",new OMuxCommand("F",false,false,false,DeviceType.All));
        }
        /// <summary>
        /// Get the command template by supplying the associated mnemonic, for example, "Reset"
        /// </summary>
        /// <param name="cmdMnemonic"></param>
        /// <returns></returns>
        public OMuxCommand OptoMuxCommandTemplate(string cmdMnemonic)
        {
            OMuxCommand cmd;
            oMuxCmdDict.TryGetValue(cmdMnemonic, out cmd);
            return cmd;
        }
    }
}