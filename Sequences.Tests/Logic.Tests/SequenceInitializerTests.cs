using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequences.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sequences.Tests.Logic.Tests
{
    [TestClass]
    public class SequenceInitializerTests
    {
        [DataTestMethod]
        [DataRow(1, new int[] { 0 })]
        [DataRow(2, new int[] { 0, 1})]
        [DataRow(10, new int[] { 0, 1, 2, 3 })]
        [DataRow(50, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 })]
        public void SetSequence_Set_SetCorrect(int limit, int[] expect)
        {
            ICollection<uint> listExpect = new List<uint>();

            for(int i = 0; i < expect.Length; ++i)
            {
                listExpect.Add((uint)expect[i]);
            }

            ListAnalyzer act = new ListAnalyzer((uint)limit);

            ICollection<uint> listAct = act.GetSequence();

            CollectionAssert.AreEqual(listExpect as ICollection, listAct as ICollection);
        }

        [DataTestMethod]
        [DataRow(0, null)]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetSequence_Null_ThrowNullReferenceExp(int limit, int[] expect)
        {
            ICollection<uint> listExpect = new List<uint>();

            for (int i = 0; i < expect.Length; ++i)
            {
                listExpect.Add((uint)expect[i]);
            }

            ListAnalyzer act = new ListAnalyzer((uint)limit);

            ICollection<uint> listAct = act.GetSequence();

            CollectionAssert.AreEqual(listExpect as ICollection, listAct as ICollection);
        }
    }
}
