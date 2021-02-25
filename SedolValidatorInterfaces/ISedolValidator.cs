namespace SedolValidatorInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

   
    public interface ISedolValidator
    {       
        ISedolValidationResult ValidateSedol(string input);
    }
}
