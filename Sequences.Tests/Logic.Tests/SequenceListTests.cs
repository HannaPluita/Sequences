using System;
using System.Collections.Generic;
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
        public void Add_AddSet_ShouldAdd()
        {
            SequenceList<uint> list = new SequenceList<uint>();
            uint[] data = new uint[7] { 12, 89, 34, 56, 23, 374, 0 };

            List<uint> expect = new List<uint>(data);

            for(int i = 0; i < data.Length; ++i)
            {
                if (!list.Add((uint)data[i]))
                {
                    break;
                }
            }

            List<uint> act = new List<uint>();

            foreach (uint item in list)
            {
                act.Add(item);
            }

            CollectionAssert.AreEqual(expect, act);
        }

        [TestMethod]
        public void Peek_PeekFirstElement_ShouldPeek()
        {
            SequenceList<uint> list = new SequenceList<uint>();
            uint[] data = new uint[7] {12, 89, 34, 56, 23, 374, 0};

            for (uint i = 0; i < data.Length; ++i)
            {
                list.Add((uint)data[i]);
            }

            uint act = list.Peek(0);
            uint expect = data[0];

            Assert.AreEqual(expect, act);
        }

        [TestMethod]
        public void Peek_PeekLastElement_ShouldPeek()
        {
            SequenceList<uint> list = new SequenceList<uint>();
            uint[] data = new uint[7] { 12, 89, 34, 56, 23, 374, 0 };

            for (uint i = 0; i < data.Length; ++i)
            {
                list.Add((uint)data[i]);
            }

            uint act = list.Peek(6);
            uint expect = data[6];

            Assert.AreEqual(expect, act);
        }
    }
}
