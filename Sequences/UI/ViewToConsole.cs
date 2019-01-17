using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.UI
{
    public static class ViewListToConsole
    {
        public const uint CELL_NUMBER = 10;
        public const string SEQUENCE = "Sequence:";

        public static void OutputToConsole(this SequenceList<int> list, uint cellNumber = CELL_NUMBER)
        {
            int i = 0;

            Console.WriteLine(SEQUENCE);
            
            foreach(int info in list)
            {
                Console.Write("{0}  ", info);
                ++i;
                if(i == CELL_NUMBER)
                {
                    i = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
