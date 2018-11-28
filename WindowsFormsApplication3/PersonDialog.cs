using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class PersonDialog : Form
    {
        public PersonDialog()
        {
            InitializeComponent();
        }

        public Person Person { get; set; }

        private void PersonDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Equals(DialogResult.Cancel))
            {
                e.Cancel = changeDetector1.ConfirmFormClosing();
            }
        }

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

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            changeDetector1.Changed = true;
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            changeDetector1.Changed = true;
        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            changeDetector1.Changed = true;
        }

        private void PersonDialog_Load(object sender, System.EventArgs e)
        {
            if (Person != null)
            {
                textBox1.Text = Person.FirstName;
                textBox2.Text = Person.LastName;
                textBox3.Text = Person.MiddleName;
            }
        }
    }
}
