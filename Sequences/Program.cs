using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sequences.UI;

namespace Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            ListAnalyzer analizer = new ListAnalyzer();
            analizer.SetSequence(30);
            analizer.ViewList();
            
            Console.ReadKey();
        }
    }
}
