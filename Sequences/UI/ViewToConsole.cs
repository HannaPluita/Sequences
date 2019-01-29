using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.UI
{
    public static class ViewListToConsole
    {
        public const uint CELLS_TO_PRINT_NUMBER = 20;
        public const string SEQUENCE = "Sequence:";

        public static void OutputToConsole(this IEnumerable<uint> list, uint cellNumber = CELLS_TO_PRINT_NUMBER)
        {
            int i = 0;

            Console.WriteLine(SEQUENCE);
            
            foreach(int info in list)
            {
                Console.Write("{0} ", info);
                ++i;
                if(i == CELLS_TO_PRINT_NUMBER)
                {
                    i = 0;
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
