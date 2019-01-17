using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences
{
    public static class MathSequence
    {
        public static int GetSqr(this SequenceList<int> list, int pos)
        {
            int square = 0;

            if(list != null)
            {
                square = list.Peek(pos) * list.Peek(pos);
            }
            return square;
        }

    }
}
