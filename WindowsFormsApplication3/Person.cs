//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WindowsFormsApplication3
{
    /// <summary>
    /// Defines the <see cref="Person" />
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            MiddleName = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/></param>
        /// <param name="lastName">The lastName<see cref="string"/></param>
        public Person(string firstName, string lastName) : this(lastName)
        {
            FirstName = firstName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/></param>
        /// <param name="lastName">The lastName<see cref="string"/></param>
        /// <param name="middleName">The middleName<see cref="string"/></param>
        public Person(string firstName, string lastName, string middleName) : this(firstName, lastName)
        {
            MiddleName = middleName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="lastName">The lastName<see cref="string"/></param>
        public Person(string lastName) : this()
        {
            LastName = lastName;
        }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the MiddleName
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The FullName
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public string FullName()
        {
            return string.Format(@"{1}, {0}{2}", FirstName.Trim(), LastName.Trim(), (string.IsNullOrEmpty(MiddleName)) ? string.Empty : " " + MiddleName.Trim());
        }
    }
}
