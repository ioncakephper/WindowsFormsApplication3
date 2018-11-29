//-----------------------------------------------------------------------
// <copyright file="PeopleList.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WindowsFormsApplication3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///
    /// </summary>
    public class PeopleList : IList<Person>
    {
        /// <summary>
        ///
        /// </summary>
        private List<Person> _list = new List<Person>();

        /// <summary>
        ///
        /// </summary>
        public event EventHandler<AddedEventArgs> Added;

        /// <summary>
        ///
        /// </summary>
        public event EventHandler Cleared;





        /// <summary>
        ///Gets
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        ///Gets a value indicating whether
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        ///Gets or sets
        /// </summary>
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



        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        public void Add(Person item)
        {
            if (item != null)
            {
                _list.Add(item);
                OnAdded(new AddedEventArgs() { PeopleAdded = new Person[] { item } });
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(Person[] items)
        {
            _list.AddRange(items);
            OnAdded(new AddedEventArgs() { PeopleAdded = items });
        }

        /// <summary>
        ///
        /// </summary>
        public void Clear()
        {
            _list.Clear();
            OnCleared(new EventArgs());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Person item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Person[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string[] FullNames()
        {
            return _list.Select(p => p.FullName()).ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Person> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(Person item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, Person item)
        {
            _list.Insert(index, item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Person item)
        {
            return _list.Remove(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            // return _list(GetEnumerator());
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void OnAdded(AddedEventArgs eventArgs)
        {
            Added?.Invoke(this, eventArgs);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void OnCleared(EventArgs eventArgs)
        {
            Cleared?.Invoke(this, eventArgs);
        }
    }
}
