using Sequence.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.UI
{
    static class Input
    {
        public static bool ParseArg(string arg, out uint result)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                Console.WriteLine(Output.EMPTY_ARG);

                result = 0;

                return false;
            }

            if (!uint.TryParse(arg, out result))
            {
                Console.WriteLine(Output.EMPTY_ARG);

                result = 0;
                return false;
            }
            else
            {
                Console.WriteLine(Output.ARG_ACCEPTED);
            }

            return true;
        }
    }
}
