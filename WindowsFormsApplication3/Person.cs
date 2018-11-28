using System;

namespace WindowsFormsApplication3
{
    public class Person
    {
        private string FirstName;
        private string LastName;

        public Person()
        {
            MiddleName = string.Empty;
        }

        public Person(string lastName) : this()
        {
            LastName = lastName;
        }

        public Person(string firstName, string lastName) : this(lastName)
        {
            this.FirstName = firstName;
        }

        public string MiddleName { get; set; }

        public string FullName()
        {
            return string.Format(@"{1}, {0}{2}", FirstName.Trim(), LastName.Trim(), (string.IsNullOrEmpty(MiddleName)) ? string.Empty : " " + MiddleName.Trim());
        }
    }
}