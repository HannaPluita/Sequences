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

        public const string NOT_FORMAT = "Your have entered the value of not unsigned integer number format.";
        public const string TRY_AGAIN_WITH_RESTART = "Please, restart the application with one argument.";
        public const string APP_CANNOT_PROCESS = "The application cannot process data in a similar format";
        public const string NULL_ENTRY_PARAMETERS = "The application cannot process data if null entry parameters.";
        public const string FINISH = "The app working is finished.";

        public const string TOO_MANY_ARGS = "Too many arguments.";
        public const string EMPTY_ARG = "The empty argument.";
        public const string INVALID_ARG = "The argument of invalid format.";
        public const string INCORRECT_ARGS = "The command arguments are of incorrect format.";
        public const string ARG_ACCEPTED = "The command argument is accepted by application.";

        public const string FORMAT_REQUIREMENTS = "Expected a number of unsigned integer format as an argument.";
        public const string MAX = "Maximum allowable value is ";
        public const uint MAX_VALUE = 100000000;
        public const string TRACE = "  StackTrace:";
        public const string SITE = "  TargetSite:";

        #endregion

        public static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputMessages(params string[] strings)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in strings)
            {
                sb.Append(s);
            }

            Console.WriteLine(sb.ToString());
        }

        public static void CorrectFormatInfo()
        {
            Console.WriteLine(FORMAT_REQUIREMENTS);
            Console.WriteLine(string.Format("{0}{1}", MAX, MAX_VALUE));
            Console.ReadKey();
        }

        public static void OutputExceptionInfo(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("{0} {1}", SITE, e.StackTrace);
            Console.WriteLine("{0} {1}", TRACE, e.TargetSite.ToString());
        }
    }
}
