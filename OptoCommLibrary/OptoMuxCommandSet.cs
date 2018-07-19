using System;
using System.Collections.Generic;

namespace OptoCommLibrary
{
    public class OptoMuxCommandSet
    {
         internal Dictionary<string,OMuxCommand> oMuxCmdDict;
        
        public OptoMuxCommandSet()
        {   
            oMuxCmdDict = new Dictionary<string,OMuxCommand>();
            // default commands
            oMuxCmdDict.Add("Power-Up_Clear",new OMuxCommand("A",false,false,false,DeviceType.All));
            oMuxCmdDict.Add("Reset",new OMuxCommand("B",false,false,false,DeviceType.All));
            oMuxCmdDict.Add("Identify",new OMuxCommand("F",false,false,false,DeviceType.All));
        }
        public void AddCommand(string mnemonic, OMuxCommand omuxcmd)
        {
            try
            {
                oMuxCmdDict.Add(mnemonic,omuxcmd);
            }
            catch(System.ArgumentException e)
            {
                //TODO: log this, usually duplicate mnemonic
                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public bool RemoveCommand(string mnemonic, OMuxCommand omuxcmd)
        {
            bool rtnval = false;
            try
            {
                rtnval = oMuxCmdDict.Remove(mnemonic);

            }
            catch(ArgumentNullException e)
            {
                // TODO: log this
                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
            return rtnval;
        }
        /// <summary>
        /// Get the command template by supplying the associated mnemonic, for example, "Reset"
        /// </summary>
        /// <param name="cmdMnemonic"></param>
        /// <returns></returns>
        public OMuxCommand GetCommand(string cmdMnemonic)
        {
            OMuxCommand cmd;
            try
            {
                oMuxCmdDict.TryGetValue(cmdMnemonic, out cmd);
            }
            catch(ArgumentNullException e)
            {
                //TODO: log this
                throw e;
            }
            catch(Exception e)
            {
                throw e;
            }
            return cmd;
        }
    }
}