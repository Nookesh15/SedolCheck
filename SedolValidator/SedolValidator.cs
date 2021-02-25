namespace SedolValidatorBusinessLogic
{
    using System;
    using System.Linq;
    using SedolValidatorInterfaces;

   
    public class SedolValidator : ISedolValidator
    {


        public const int SedolLength = 7;
        public const char UserDefinedSedolPrefix = '9';
        public const int ZeroDigitAsciiValue = 48;
        public const int LetterAsciiOffset = 55;




        public virtual int[] ChrWeights { get; private set; }
        public SedolValidator()
            : this(new int[] { 1, 3, 1, 7, 3, 9, 1 })
        {
        }


        public SedolValidator(int[] length)
        {
            this.Weight(length);
            this.ChrWeights = length;
        }


              
         public virtual void Weight(int[] chrlenght)
        {
            if (chrlenght == null)
            {
                throw new ArgumentNullException("Character are not entered.");
            }

            if (chrlenght.Length != SedolLength)
            {
                throw new ArgumentException("Character array is expected to have the same number of elements as per the expected SEDOL length.");
            }
        }


        public virtual bool HasEndUserDefinedSedolPrefix(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input not entered.");
            }

            return input[0] == UserDefinedSedolPrefix;
        }



        public ISedolValidationResult ValidateSedol(string input)
        {
            bool isValid = false;
            bool isUserDefined = false;
            string validationDetails = string.Empty;

            if (this.HasRightLength(input))
            {
                var checksumDigit = this.CalculateChecksumDigit(RemoveChecksumDigit(input));

                if (input.Last() == checksumDigit)
                {
                    isValid = true;
                }
                else
                {
                    validationDetails = "The checksum is not satisfying the first 6 letters";
                }
            }
            else
            {
                validationDetails = string.Format("Input string was not {0}-characters long.", SedolLength);
            }

            return new SedolValidationResult(input, isValid, isUserDefined, validationDetails);
        }

        public string RemoveChecksumDigit(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("The Input string is null or empty");
            }

            return input.Substring(0, input.Length - 1);
        }

        public virtual bool HasRightLength(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length == SedolLength;
        }


        public virtual char CalculateChecksumDigit(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input not specified.");
            }

            var sum = 0;
            for (int i = 0; i < Math.Min(input.Length, this.ChrWeights.Length); i++)
            {
                if (char.IsDigit(input[i]))
                {
                    sum += ((int)input[i] - ZeroDigitAsciiValue) * this.ChrWeights[i];
                }
                else if (char.IsLetter(input[i]))
                {
                    sum += ((int)char.ToUpper(input[i]) - LetterAsciiOffset) * this.ChrWeights[i];
                }
            }

            var checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit.ToString().Last();
        }

        
    }
}
