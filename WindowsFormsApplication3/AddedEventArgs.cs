using System;

namespace WindowsFormsApplication3
{
    public class AddedEventArgs : EventArgs
    {
        public AddedEventArgs()
        {
            PeopleAdded = new Person[] { };
        }

        public Person[] PeopleAdded { get; set; }
    }
}