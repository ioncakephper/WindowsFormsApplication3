using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApplication3
{
    public class PeopleList : IList<Person>
    {
        public event EventHandler<AddedEventArgs> Added;
        public event EventHandler Cleared;

        private List<Person> _list = new List<Person>();

        public Person this[int index]
        {
            get
            {
                return _list[index];
            }

            set
            {
                _list[index] = value;
            }
        }

        public void AddRange(Person[] items)
        {
            _list.AddRange(items);
            OnAdded(new AddedEventArgs() { PeopleAdded = items });
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Person item)
        {
            if (item != null)
            {
                _list.Add(item);
                OnAdded(new AddedEventArgs() { PeopleAdded = new Person[] { item } });
            }
        }

        public string[] FullNames()
        {
           return _list.Select(p => p.FullName()).ToArray();
        }

        protected virtual void OnAdded(AddedEventArgs eventArgs)
        {
            Added?.Invoke(this, eventArgs);
        }

        public void Clear()
        {
            _list.Clear();
            OnCleared(new EventArgs());
        }

        protected virtual void OnCleared(EventArgs eventArgs)
        {
            Cleared?.Invoke(this, eventArgs);
        }

        public bool Contains(Person item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(Person item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Person item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(Person item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // return _list(GetEnumerator());
            throw new NotImplementedException();
        }
    }
}