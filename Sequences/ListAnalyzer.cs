using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.Logic;
using Sequences.Logic.UserExceptions;
using Sequences.UI;

namespace Sequences
{
    public class ListAnalyzer: SequenceInitializer
    {
        public ListAnalyzer() : this(0)
        {
        }

        public ListAnalyzer(uint length)
        :base(length)
        {
        }

        public ICollection<uint> GetSequence()
        {
            SetSequence();
            return _list.ToCollection();
        }

        public void PrintListToConsole()
        {
            _list.OutputToConsole();
        }
    }
}
