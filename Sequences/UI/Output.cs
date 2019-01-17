using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence.UI
{
    public static class Output
    {
        #region    Constants
        public const string INPUT_SEQUENCE = "Please, input a positive integer value:";
        public const string INCORRECT_DATA = "The data you have entered is incorrect.";
        public const string NOT_REAL = "Your have entered the value of not integer number format.";
        public const string NOT_ONE_STRING = "One-value entry data expected.";
        public const string TRY_AGAIN_WITH_RESTART = "Please, restart the application with entry data as parameter.";
        public const string APP_CANNOT_PROCESS = "The application cannot process data in a similar format";
        public const string NULL_ENTRY_PARAMETERS = "The application cannot process data if null entry parameters.";
        public const string FINISH = "The app working is finished.";

        public const string FORMAT_REQUIREMENTS = "Expected a positive number of integer numeric format.";
        public const string MAX = "Maximum allowable value is ";
        public const double MAX_VALUE = int.MaxValue;
        #endregion

        public static void OutputOneMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputMessages(params string[] strings)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in strings)
            {
                sb.Append(s);
            }
            Console.WriteLine(sb.ToString());
        }

        public static void CorrectFormatInfo()
        {
            Console.WriteLine(FORMAT_REQUIREMENTS);
            Console.WriteLine(String.Concat(MAX, MAX_VALUE));
        }

    }

}
