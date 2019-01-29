using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences.Logic
{
    public class SequenceList<T> : IEnumerable<T>, IEnumerator<T>, IDisposable
        where T: struct 
    {
        #region    Constants
        public const string LIST_EMPTY_GET_LAST = "You cannot get the last element of the list because the list is empty.";
        public const string LIST_EMPTY_GET_FIRST = "You cannot get the first element of the list because the list is empty.";
        public const string EXP_CANNOT_GET = "You can not get the element";
        public const string ERR_EMPTY_LIST = " The list is empty.";
        public const string INDEX_VALUE = "The value of index ";
        public const string INDEX_BELOW = "is below the list range.";
        public const string INDEX_ABOVE = "The value of index ";
        #endregion

        private Node<T> _first = null;
        private Node<T> _last = null;
        private Node<T> _current = null;

        public bool Add(T info)                     
        {
            try
            {
                Node<T> newElem = new Node<T>(info);

                if (newElem == null)
                {
                    return false;
                }

                if (_first == null)
                {
                    _first = newElem;
                    _last = newElem;

                    return true;
                }
                
                Node<T> i = _first;

                for (; i.Next != null; i = i.Next)
                {
                }

                i.Next = newElem;
                _last = newElem;

                return true;
            }
            catch (OutOfMemoryException)
            {
                throw new OutOfMemorySequenceException();
            }
        }

        protected T PeekLast()
        {
            try
            {
                T result = default(T);

                if (_last != null)
                {
                    result = _last.Info;
                }

                return result;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(ERR_EMPTY_LIST, e);
            }
        }

        protected T PeekFirst()
        {
            try
            {
                T retVal = default(T);

                if (_first.Next == null)
                {
                    retVal = _first.Info;
                }
                else
                {
                    retVal = _first.Info;
                }
                return retVal;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(ERR_EMPTY_LIST, e);
            }
        }                                       

        public T Peek(uint pos)
        {
            try
            {
                if (pos == 0)
                {
                    return _first.Info;
                }

                T returnValue = default(T);
                
                Node<T> currElem = _first;

                for (uint i = 0; i < pos - 1; ++i)
                {
                    currElem = currElem.Next;
                }

                returnValue = currElem.Next.Info;

                return returnValue;
            }
            catch (NullReferenceException e)
            {
                if (_first == null)
                {
                    throw new NullReferenceException(string.Format("{0}[{1}] {2}", EXP_CANNOT_GET, pos, ERR_EMPTY_LIST), e);
                }

                e.Data.Add("Position", pos);
                e.Data.Add("MinIndex", 0);
                e.Data.Add("MaxIndex", Count- 1);

                if (pos < 0)
                {
                    throw new NullReferenceException(string.Format("{0}{1}", INDEX_VALUE, INDEX_BELOW), e);

                }

                throw new NullReferenceException(string.Format("{0}{1}", INDEX_VALUE, INDEX_ABOVE), e);
            }
        }

        public uint Count
        {
            get
            {
                uint count = 0;

                if (_first == null)
                {
                    return 0;
                }

                for (Node<T> i = _first; i != null; i = i.Next)
                {
                    ++count;
                }

                return count;
            }
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
            Node<T> current = _first;

            while (current != null)
            {
                yield return current.Info;

                current = current.Next;
            }
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

        T IEnumerator<T>.Current
        {
            get
            {
                return _current.Info;
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
