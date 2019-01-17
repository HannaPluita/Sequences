﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences
{
    public class Node<T>
    {
        public Node()
        {
            Prev = null;
            Next = null;
        }

        public Node(T info)
        {
            Info = info;
            Prev = null;
            Next = null;
        }

        public Node(Node<T> n)
            : this(n.Info)
        { }

        public T Info { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
    }
}
