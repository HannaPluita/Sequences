using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences
{
    /// <summary>
    ///The exception class that occurs when trying to create a list item if there is no free memory space.
    ///<para>Tracked when System.OutOfMemoryException is generated.</para>
    /// </summary>
    class OutOfMemorySequenceException : Exception
    {
        public const string EXCEPTION_MESSAGE_1 = "OutOfMemorySequenceException: ";
        public const string EXCEPTION_MESSAGE_2 = "You cannot add a new element of the sequence because of a lack of free memory space.";
        public const string EXCEPTION_MESSAGE_3 = "You are out of free memory space limit.";

        public OutOfMemorySequenceException()
            : base(String.Concat(EXCEPTION_MESSAGE_1, EXCEPTION_MESSAGE_2))
        {
        }

        public OutOfMemorySequenceException(string message)
            : base(message)
        {
        }
        public OutOfMemorySequenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public override string ToString()
        {
            return string.Format("{0}{1}", EXCEPTION_MESSAGE_1, EXCEPTION_MESSAGE_3);
        }
    }
}
