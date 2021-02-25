namespace SedolValidatorBusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SedolValidatorInterfaces;

    
    public class SedolValidationResult : ISedolValidationResult
    {
       
        public SedolValidationResult(string inputString, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            this.InputString = inputString;
            this.IsValidSedol = isValidSedol;
            this.IsUserDefined = isUserDefined;
            this.ValidationDetails = validationDetails;
        }

        

        public string InputString { get; private set; }      
        public bool IsValidSedol { get; private set; }        
        public bool IsUserDefined { get; private set; }       
        public string ValidationDetails { get; private set; }

       
    }
}
