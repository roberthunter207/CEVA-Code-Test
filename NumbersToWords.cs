using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEVACodeTest
{
    class NumbersToWords
    {
        private readonly string[] singleDigits = new[] { "", "One", "Two", "Three",
                    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                    "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] doubleDigits = new[] { "Ten", "Twenty", "Thirty",
                    "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private readonly string[] largeNumNames = new[] { " Billion ", " Million ", 
                    " Thousand ", " Hundred "};
        public string IntegerToWords(long num)
        {
            string words = "";

            /*
             * This switch statement is used to check whether or not the User has
             * only input the number '0'.
             * If so, the value returned to the console will be "Zero", and the
             * application will terminate here. However, if the input value is anything other
             * than '0', the application will continue to process following the default
             * case of the switch statement.
             */
            switch (num)
            {
                case 0:
                    return "Zero";
                default:
                    return ConvertToWords();
            }

            /*
             * This method's purpose to convert and input value other than '0'
             * into words.
             * The method is of recursive nature and works by first understanding 
             * whether or not the value is negative. If so, the method will call 
             * itself again to reiterate through the if statement to further convert 
             * the input values into words and find whether or not it's necessary to
             * add large number names such as 'Billion' or 'Thousand' to the string 'words'. 
             * 
             * The modulus operator (%) is used to grab the remainder of the input value
             * to ensure that it is matched with it's correlating value or 'word' in the 
             * 'singleDigits' or 'doubleDigits' array. Eg. The input value of '1' is equal to
             * 'singleDigits[1]' thus returning 'One'.
             */
            string ConvertToWords()
            {
                if (num < 0)
                {
                    words += "Negative " + IntegerToWords((Math.Abs(num)));
                }
                if ((num / ((int)Math.Pow(10,9))) > 0)
                {
                    words += IntegerToWords(num / ((int)Math.Pow(10, 9))) + largeNumNames[0];
                    num %= (int)Math.Pow(10,9);
                }
                if ((num / ((int)Math.Pow(10, 6))) > 0)
                {
                    words += IntegerToWords(num / ((int)Math.Pow(10, 6))) + largeNumNames[1];
                    num %= (int)Math.Pow(10, 6);
                }

                if ((num / ((int)Math.Pow(10, 3))) > 0)
                {
                    words += IntegerToWords(num / ((int)Math.Pow(10, 3))) + largeNumNames[2];
                    num %= (int)Math.Pow(10, 3);
                }

                if ((num / ((int)Math.Pow(10, 2))) > 0)
                {
                    words += IntegerToWords(num / ((int)Math.Pow(10, 2))) + largeNumNames[3];
                    num %= (int)Math.Pow(10, 2);
                }

                if (num > 0)
                {
                    if (!string.IsNullOrEmpty(words))
                        words += "And ";

                    if (num < 20)
                        words += singleDigits[num];
                    else
                    {
                        words += doubleDigits[(num / 10) - 1];
                        if ((num % 10) > 0)
                            words += " " + singleDigits[num % 10];
                    }
                }
                return words;
            }
        }
    }
}
