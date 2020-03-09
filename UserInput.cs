using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEVACodeTest
{
    class UserInput
    {
        /*
         * This method instantiates the NumberToWords class and retrieves user input.
         * It retrieves the Date by utilising the DateTime struct and then converting to a 'Short'
         * date string to eliminate the time portion.
         * 
         * The User is then asked to input a number of any value whether it's negative or positive.
         * The tryParse method is used to ensure that the User does input an appropriate integer
         * and not a string. If the User inputs anything other than integer values, they are
         * responded with a message and are asked to input a value again until the condition
         * of the 'do-while' loop is met.
         */
        public void GetUserInput()
        {
            NumbersToWords ConvertToWords = new NumbersToWords();
            DateTime currentDateAndTime = DateTime.Now;
            string currentDate = currentDateAndTime.ToShortDateString();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            do
            {
                Console.Write("Enter an amount in numbers (Eg. 123): ");
                string num = Console.ReadLine();
                if (long.TryParse(num, out _))
                {
                    Console.WriteLine(name);
                    Console.WriteLine(currentDate);
                    Console.WriteLine(ConvertToWords.IntegerToWords(Convert.ToInt64(num)));
                    Console.Read();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Input!");
                }
            } while (true);
        }
    }
}
