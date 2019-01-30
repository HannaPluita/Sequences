using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Logic;

namespace Sequences.Logic.UserExceptions
{
    /// <summary>
    ///The exception class that occurs when trying to create a list of items
    /// if the length argument of the list is more than valid limit.
    /// </summary>
    class ArgumentOutOfSequenceLimitRangeException : ArgumentOutOfRangeException
    {
        public const string EXP_MSG_NAME = "ArgumentOutOfSequenceLimitRangeException: ";
        public const string EXP_MSG_CANNOT 
            = "You cannot create the sequence of such length because it is out of limit range.";
        public const string EXP_MSG_OUT_OF_LIMIT = "Your list length is  more than valid limit.";
        public const uint LIMIT = 100000000;

        public ArgumentOutOfSequenceLimitRangeException()
            : base(String.Concat(EXP_MSG_NAME, EXP_MSG_CANNOT))
        {
            this.Data.Add("Argument Limit", LIMIT);
        }

        public ArgumentOutOfSequenceLimitRangeException(string message)
            : base(message)
        {
        }
        public ArgumentOutOfSequenceLimitRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public override string ToString()
        {
            return string.Format("{0}{1}: {2}", EXP_MSG_NAME, EXP_MSG_OUT_OF_LIMIT, LIMIT);
        }
    }
}
