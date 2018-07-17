using System;
using System.Collections.Generic;

namespace OptoCommLibrary
{
    class OptoMuxCommand
    {
        public class OMuxCommand
        {
            private string prefix;
            private bool positions,modifier,data;
            string Prefix { get => prefix; }
            bool Positions { get => positions; }
            bool Modifier { get => modifier; }
            bool Data { get => data; }
            public OMuxCommand(string Prefix,bool Positions,bool Modifier,bool Data)
            {
                prefix = Prefix; positions = Positions; data = Data;
            }
        }
        private Dictionary<string,OMuxCommand> oMuxCommandDict;
        
        OptoMuxCommand()
        {
            oMuxCommandDict.Add("Power-Up_Clear",new OMuxCommand("A",false,false,false));
        }
    }
}