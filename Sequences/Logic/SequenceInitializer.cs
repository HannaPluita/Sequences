using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Logic.UserExceptions;

namespace Sequences.Logic
{
    public class SequenceInitializer
    {
        public const string ERR_SETTING = "Error of setting sequence.";

        public const string EXP_MSG = "The argument exceeds maximum permissible length of the sequence.";
        public const string EXP_OUT_OF_RANGE = @"The product of arguments' multiplication exceeds the maximum allowed value";
        public const uint LIMIT = 100000000;

        protected uint _length = 0;
        protected SequenceList<uint> _list = new SequenceList<uint>();

        public SequenceInitializer()
        {
        }

        public SequenceInitializer(uint length)
        {
            if (length > LIMIT)
            {
                throw new ArgumentOutOfSequenceLimitRangeException(string.Format("{0}: {1}",EXP_OUT_OF_RANGE, LIMIT));
            }

            _length = length;
        }

        protected void SetSequence()
        {
            try
            {
                for (uint i = 0; ; ++i)
                {
                    if (i * i < _length)
                    {
                        _list.Add(i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(ERR_SETTING, e);
            }
        }
    }
}
