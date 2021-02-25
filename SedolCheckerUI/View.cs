namespace SedolCheckerGUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SedolValidatorBusinessLogic;

    public class View
    {
        IView Show { get; set; }

        public View(IView sight)
        {
            if (sight == null)
            {
                throw new ArgumentNullException("View not yet begin ");
            }

            Show = sight;
        }

        public void Validate()
        {
            var input = Show.SedolNum;

            var validator = new SedolValidator();
            var result = validator.ValidateSedol(input);

            Show.Valid = result.IsValidSedol;
            Show.IsUserDefined = result.IsUserDefined;
            Show.Validation = result.ValidationDetails;
        }
    }
}
