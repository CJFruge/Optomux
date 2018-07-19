using System;

namespace OptoCommLibrary
{
    public enum DeviceType 
    {
        B1 = 1, // B1 brainboard (digital RS422)
        B2 = 2, // B2 brainboard (analog RS422)
        E1 = 3, // E1 brainboard (digital ethernet)
        E2 = 4, // E2 brainboard (analog ethernet)
        All = 0
     };
}