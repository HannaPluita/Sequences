using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.UI;

namespace Sequences
{
    public class ListAnalyzer
    {
        protected SequenceList<int> _list = new SequenceList<int>();

        public void SetSequence(int value)
        {
            try
            {
                for (int i = 0; ; ++i)
                {
                    if (Math.Pow(i, 2) < value)
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

            }
            
        }

        public void ViewList()
        {
            _list.OutputToConsole();
        }
    }
}
