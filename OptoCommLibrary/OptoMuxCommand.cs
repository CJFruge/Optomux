
using System;

namespace VLLC.OptoCommLibrary
{
    public class OMuxCommand
    {
        private string prefix;
        private bool positions,modifier,data;
        private DeviceType deviceType;

/// <summary>
/// Unique string identifier for Optomux command
/// (example:"Power_Up-Clear" or "PUC")
/// </summary>
/// <value></value>
        public string Prefix { get => prefix; }
        public bool Positions { get => positions; }
        public bool Modifier { get => modifier; }
        public bool Data { get => data; }
        public DeviceType DeviceType { get => deviceType; }

        internal OMuxCommand(string Prefix,bool Positions,bool Modifier,bool Data,DeviceType DeviceType)
        {
            prefix = Prefix; 
            positions = Positions;
            modifier = Modifier;
            data = Data; 
            deviceType = DeviceType;
        }
    }
}