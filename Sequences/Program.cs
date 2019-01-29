using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequence.UI;
using Sequences.UI;

namespace Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Output.OutputMessage(Output.NULL_ENTRY_PARAMETERS);
                Output.OutputMessage(Output.TRY_AGAIN_WITH_RESTART);
                Output.CorrectFormatInfo();

                return;
            }

            if (args.Length > 1)
            {
                Output.OutputMessage(Output.TOO_MANY_ARGS);
                Output.OutputMessage(Output.TRY_AGAIN_WITH_RESTART);
                Output.CorrectFormatInfo();

                return;
            }

            uint value = 0;

            if (!Input.ParseArg(args[0], out value) || value > 100000000)
            {
                Output.OutputMessage(Output.INCORRECT_ARGS);
                Output.OutputMessage(Output.TRY_AGAIN_WITH_RESTART);
                Output.CorrectFormatInfo();

                return;
            }

            try
            {
                ListAnalyzer analizer = new ListAnalyzer(value);

                analizer.SetSequence();
                analizer.ViewList();
            }
            catch (Exception e)
            {
                Output.OutputExceptionInfo(e);
            } 
        }
    }
}
