﻿namespace SedolValidatorInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    
    public interface ISedolValidationResult
    {       
        string InputString { get; }       
        bool IsValidSedol { get; }        
        bool IsUserDefined { get; }      
        string ValidationDetails { get; }
    }
}
