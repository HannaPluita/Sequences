using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences
{
    public class SequenceList<T> : IEnumerable<T>, IEnumerator<T>
        where T: struct 
    {
        public const string LIST_EMPTY_GET_LAST = "You cannot get the last element of the list because the list is empty.";
        public const string LIST_EMPTY_GET_FIRST = "You cannot get the first element of the list because the list is empty.";
        public const string CANNOT_GET = "You cannot get element";
        public const string EMPTY_LIST = " because the list is empty.";
        public const string INDEX_VALUE = "The value of index ";
        public const string INDEX_BELOW = "is below the list range.";
        public const string INDEX_ABOVE = "The value of index ";

        private Node<T> _first = null;
        private Node<T> _last = null;
        private Node<T> _current = null;

        public void Add(T info)                     
        {
            Node<T> newElem = new Node<T>(info);

            if (newElem == null)
            {
                throw new OutOfMemorySequenceException();
            }

            if (_first == null)
            {
                _first = newElem;
                _last = newElem;
            }
            else
            {
                Node<T> i = _first;
                for (; i.Next != null; i = i.Next)
                {
                }
                i.Next = newElem;
                newElem.Prev = i;
                _last = newElem;
            }
        }

        public void AddToBegin(T info)
        {
            Node<T> newNode = new Node<T>(info);

            if (newNode == null)
            {
                throw new OutOfMemorySequenceException();
            }

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _first;
                newNode.Prev = null;
                _first = newNode;
                Node<T> node = _first;
                for (; node.Next.Next != null;)
                {
                    node = node.Next;
                }
                _last = node.Next;
                _last.Next = null;
                _last.Prev = node;
            }
        }

        public T GetLast()                                           
        {
            try
            {
                T retValue = default(T);
                if (_first.Next == null)          
                {
                    retValue = _first.Info;
                    _first = null;
                    _last = null;
                }
                else
                {
                    Node<T> i = _first;
                    for (; i.Next.Next != null; i = i.Next)
                    {
                    }
                    retValue = i.Next.Info;    
                    i.Next = null;             
                    _last = i;
                }
                return retValue;
            }
            catch (NullReferenceException e)
            {
                throw new Exception(LIST_EMPTY_GET_LAST, e);
            }
        }

        public T GetFirst()                                          
        {
            try
            {
                T retVal = default(T);
                if (_first.Next == null)
                {
                    retVal = _first.Info;
                    _first = null;
                    _last = null;
                }
                else
                {
                    retVal = _first.Info;
                    _first = _first.Next;
                    _first.Prev = null;
                }
                return retVal;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(LIST_EMPTY_GET_FIRST, e);   
            }

        }

        public T GetByPos(int pos)                                   
        {
            try
            {
                if (pos < 0)
                {
                    throw new NullReferenceException();
                }
                T retVal = default(T);
                if (pos == 0)
                {
                    retVal = GetFirst();
                }
                else
                {
                    Node<T> currElem = _first;
                    for (int i = 0; i < pos - 1; ++i)
                    {
                        currElem = currElem.Next;
                    }
                    if (currElem.Next.Next == null)
                    {
                        retVal = GetLast();
                    }
                    else
                    {
                        retVal = currElem.Next.Info;
                        currElem.Next = currElem.Next.Next;
                        currElem.Next.Prev = currElem;
                    }
                }
                return retVal;
            }
            catch (NullReferenceException e)
            {
                if (_first == null)
                {
                    throw new NullReferenceException(string.Format("{0}[{1}] {2}", CANNOT_GET, pos, EMPTY_LIST),e);
                }

                e.Data.Add("Position", pos);
                e.Data.Add("MinIndex", 0);
                e.Data.Add("MaxIndex", GetLength() - 1);

                if (pos < 0)
                {
                    throw new NullReferenceException(string.Format("{0}{1}", INDEX_VALUE, INDEX_BELOW), e);

                }

                throw new NullReferenceException(string.Format("{0}{1}", INDEX_VALUE, INDEX_ABOVE), e);
            }
        }

        public T Peek(int pos)
        {
            try
            {
                if (pos < 0)
                {
                    throw new NullReferenceException(String.Concat(INDEX_VALUE, INDEX_BELOW));
                }

                if (pos == 0)
                {
                    return _first.Info;
                }

                T returnVal = default(T);
                
                Node<T> currElem = _first;

                for (int i = 0; i < pos - 1; ++i)
                {
                    currElem = currElem.Next;
                }

                returnVal = currElem.Next.Info;

                return returnVal;
            }
            catch (NullReferenceException e)
            {
                if (_first == null)
                {
                    throw new NullReferenceException(string.Format("{0}[{1}] {2}", CANNOT_GET, pos, EMPTY_LIST), e);
                }

                e.Data.Add("Position", pos);
                e.Data.Add("MinIndex", 0);
                e.Data.Add("MaxIndex", GetLength() - 1);

                if (pos < 0)
                {
                    throw new NullReferenceException(string.Format("{0}{1}", INDEX_VALUE, INDEX_BELOW), e);

                }

                throw new NullReferenceException(string.Format("{0}{1}", INDEX_VALUE, INDEX_ABOVE), e);
            }
        }

        public int GetLength()
        {
            int retValue = 0;

            for (Node<T> i = _first; i != null; i = i.Next)
            {
                ++retValue;
            }

            return retValue;
        }
        
        public object Current   
        {
            get
            {
                for (Node<T> current = _first; ; current = current.Next)
                {
                    return current.Info;
                }
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return _current.Info;
            }
        }

        public bool MoveNext()    
        {
            if (_current == null)
            {
                _current = _first;
            }
            else
            {
                _current = _current.Next;
            }

            return _current.Next != null;
        }

        public void Reset()      
        {
            _current = null;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Reset();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> current = _first;
            while(current != null)
            {
                yield return current.Info;
                current = current.Next;
            }
        }

        public void Dispose()
        {
            _current = null;
            _first = null;

            GC.Collect();
        }

    }
}
