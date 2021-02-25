using fit;
using fitlibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedolAcceptanceTests
{
    public class SedolAutomation:DoFixture
    {
        public string SedolNum { get; set; }

        [Description("String should be empty & string other than 7 characters long was not accepted")]

        Fixture EmptyStringOrStringOtherThan7CharactersLong()
        {
            return new SedolScenarios();
        }

        [Description("7characters input with incorrect checksum digit")]
        Fixture Seven_CharactersLongInputWithIncorrectChecksumDigit()
        {

            return new SedolScenarios();
        }

        [Description("Valid SEDOL was not valed by the end user (starting character should be 9).")]
        Fixture ValidSedolThatIsNotDefinedByTheEndUser_LeadingCharacterIsNot9()
        {

            return new SedolScenarios();
        }

        [Description("Valid End User Defined SEDOL (starting character should be 9).")]
        Fixture ValidEndUserDefinedSEDOL_LeadingCharacterIs9()
        {

            return new SedolScenarios();
        }
    }

}
