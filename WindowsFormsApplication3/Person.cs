namespace WindowsFormsApplication3
{
    public class Person
    {
        public Person()
        {
            MiddleName = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
        }

        public Person(string lastName) : this()
        {
            LastName = lastName;
        }

        public Person(string firstName, string lastName) : this(lastName)
        {
            FirstName = firstName;
        }

        public Person(string firstName, string lastName, string middleName) : this(firstName, lastName)
        {
            MiddleName = middleName;
        }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName()
        {
            return string.Format(@"{1}, {0}{2}", FirstName.Trim(), LastName.Trim(), (string.IsNullOrEmpty(MiddleName)) ? string.Empty : " " + MiddleName.Trim());
        }
    }
}