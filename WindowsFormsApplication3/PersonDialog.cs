//------------------------------------------------------------------------------
// <copyright file="PersonDialog.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication3
{
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="PersonDialog" />
    /// </summary>
    public partial class PersonDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDialog"/> class.
        /// </summary>
        public PersonDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the Person
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// The PersonDialog_FormClosed
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosedEventArgs"/></param>
        private void PersonDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            switch (changeDetector1.DialogResult)
            {
                case DialogResult.None:
                case DialogResult.OK:
                    Person = new Person(textBox1.Text, textBox2.Text, textBox3.Text);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The PersonDialog_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void PersonDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Equals(DialogResult.Cancel))
            {
                e.Cancel = changeDetector1.ConfirmFormClosing();
            }
        }

        /// <summary>
        /// The PersonDialog_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="System.EventArgs"/></param>
        private void PersonDialog_Load(object sender, System.EventArgs e)
        {
            if (Person != null)
            {
                textBox1.Text = Person.FirstName;
                textBox2.Text = Person.LastName;
                textBox3.Text = Person.MiddleName;
            }
        }

        /// <summary>
        /// The textBox1_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="System.EventArgs"/></param>
        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            changeDetector1.Changed = true;
        }

        /// <summary>
        /// The textBox2_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="System.EventArgs"/></param>
        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            changeDetector1.Changed = true;
        }

        /// <summary>
        /// The textBox3_TextChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="System.EventArgs"/></param>
        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            changeDetector1.Changed = true;
        }
    }
}
