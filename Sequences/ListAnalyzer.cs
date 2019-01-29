using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Logic;
using Sequences.UI;

namespace Sequences
{
    public class ListAnalyzer
    {
        public const string ERR_SETTING = "Error of setting sequence.";
        public readonly uint MAX_VALUE = 100000000;

        protected uint _value;

        public ListAnalyzer() : this(0)
        {
        }

        public ListAnalyzer(uint value)
        {
            _value = value;
        }

        protected SequenceList<uint> _list = new SequenceList<uint>();

        public void SetSequence()
        {
            try
            {
                for (uint i = 0; ; ++i)
                {
                    if (i*i < _value)
                    {
                        _list.Add(i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(ERR_SETTING, e);
            }
            
        }

        public void ViewList()
        {
            _list.OutputToConsole();
        }
    }
}
