using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequences.Logic;

namespace Sequences.Tests.Logic.Tests
{
    [TestClass]
    public class SequenceListTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(12)]
        public void Add_AddFirstElement_ShouldAdd(int value)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            bool act = list.Add((uint)value);
            bool expect = true;

            Assert.AreEqual(act, expect);
        }

        [DataTestMethod]
        [DataRow(new int[] { 12, 89, 34, 56, 23, 374, 0 })]
        [DataRow(new int[] { 1, 9, 4, 6 })]
        public void Add_AddSet_ShouldAdd(int[] expect)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            for (int i = 0; i < expect.Length; ++i)
            {
                list.Add((uint)expect[i]);
                Assert.AreEqual(expect[i], (int)list.Peek((uint)i));
            }
        }

        [DataTestMethod]
        [DataRow(new int[] { 12, 89, 34, 56, 23, 374, 0 })]
        [DataRow(new int[] { 12 })]
        [DataRow(new int[] { 1, 9, 4, 6 })]
        public void Peek_PeekFirstElement_ShouldPeek(int[] range)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            for (uint i = 0; i < range.Length; ++i)
            {
                list.Add((uint)range[i]);
            }

            uint act = list.Peek(0);
            uint expect = (uint)range[0];

            Assert.AreEqual(expect, act);
        }

        [DataTestMethod]
        [DataRow(new int[] { 12, 89, 34, 56, 23, 374, 0 }, 6)]
        [DataRow(new int[] { 12 }, 0)]
        [DataRow(new int[] { 1, 9, 4, 6 }, 3)]
        public void Peek_PeekLastElement_ShouldPeek(int[] range, int index)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            for (uint i = 0; i < range.Length; ++i)
            {
                list.Add((uint)range[i]);
            }

            uint act = list.Peek((uint)index);
            uint expect = (uint)range[index];

            Assert.AreEqual(expect, act);
        }

        [DataTestMethod]
        [DataRow(new int[] {1, 23, 44, 56, 54}, 0, 1)]
        [DataRow(new int[] { 1, 23, 44, 56, 54 }, 4, 54)]
        [DataRow(new int[] { 1, 23, 44, 56, 54 }, 2, 44)]
        [DataRow(new int[] { 1, 23, 44, 56, 54 }, 3, 56)]
        public void Peek_Pos_ReturnElementByPos_ElementByPos(int[] input, int pos, int expected)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            for (uint i = 0; i < input.Length; ++i)
            {
                list.Add((uint)input[i]);
            }

            uint act = list.Peek((uint)pos);
            Assert.AreEqual((uint)expected, act);
        }

        [DataTestMethod]
        [DataRow(new int[] { 34, 23 }, 3)]
        [DataRow(new int[] { 34, 23, 56 }, 10)]
        [ExpectedException(typeof(NullReferenceException))]
        public void Peek_Pos_ReturnElementByOutOfRange_ThrowExp(int[] input, int pos)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            for (uint i = 0; i < input.Length; ++i)
            {
                list.Add((uint)input[i]);
            }

            list.Peek((uint)pos);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 22, 44, 56, 54 }, 5)]
        [DataRow(new int[] { 1, 23, 44, 56 }, 4)]
        [DataRow(new int[] { 1, 23, 44 }, 3)]
        [DataRow(new int[] { }, 0)]
        public void Count_CountElements_CountRight(int[] input, int expect)
        {
            SequenceList<uint> list = new SequenceList<uint>();

            for (uint i = 0; i < input.Length; ++i)
            {
                list.Add((uint)input[i]);
            }

            uint act = list.Count;

            Assert.AreEqual((uint)expect, act);
        }

        [TestMethod]
        public void Count_CountNullList_ReturnZero()
        {
            SequenceList<uint> list = new SequenceList<uint>();

            uint act = list.Count;
            uint expect = 0;

            Assert.AreEqual(expect, act);
        }
    }
}
