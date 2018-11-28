using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            People = new PeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = new Dialog1();
            if (d.ShowDialog().Equals(DialogResult.OK))
            {
                MessageBox.Show("OK");
            }
        }

        public PeopleList People { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileManager1.FileName = "Phrases1.phf";
            People.AddRange(new Person[] { new Person("Ion", "Gireada"), new Person("Dale", "Cooper") });
            PopulatePeopleListBox();
        }

        private void PopulatePeopleListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(People.FullNames().ToArray());
            fileManager1.ChangeDetector.Changed = true;
            var isPeopleCountZero = listBox1.Items.Count.Equals(0);
            SetControlEnabledCountIsZero(isPeopleCountZero);
        }

        private void SetControlEnabledCountIsZero(bool isPeopleCountZero)
        {
            if (isPeopleCountZero)
            {
                SetControlEnabledValue(false, new ToolStripButton[] { toolStripButton2 });
                SetControlEnabledValue(true, new ToolStripButton[] { toolStripButton1 });
            }
            else
            {
                SetControlEnabledValue(true, new ToolStripButton[] { toolStripButton1, toolStripButton2 });
            }
        }

        private void SetControlEnabledValue(bool status, ToolStripButton[] controls)
        {
            controls.ToList().ForEach(c => c.Enabled = status);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = changeDetector1.ConfirmFormClosing();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changeDetector1.DialogResult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Information is being saved...");
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        private void NewApplicationFile()
        {
            fileManager1.NewApplicationFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }

        private void SaveApplicationFile()
        {
            fileManager1.SaveApplicationFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsApplicationFile();
        }

        private void SaveAsApplicationFile()
        {
            fileManager1.SaveAsApplicationFile();
        }

        private void fileManager1_FilenameChanged(object sender, EventArgs e)
        {
            Text = System.IO.Path.GetFileNameWithoutExtension(fileManager1.FileName);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string questionApproveDeleteAll = @"Are you sure you want de remove all items?";
            string boxTitle = "Confirmation";
            if (MessageBox.Show(questionApproveDeleteAll, boxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                People.Clear();
                PopulatePeopleListBox();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        private void AddPerson()
        {
            AddPerson(new Person());
        }

        private void AddPerson(Person defaultPerson)
        {
            Person person = AddPersonDialog(defaultPerson);
            if (person != null)
            {
                People.Add(person);
                PopulatePeopleListBox();
            }
        }

        private Person AddPersonDialog(Person defaultPerson)
        {
            return PersonEditorDialog("New", defaultPerson);
        }

        private Person PersonEditorDialog(string caption, Person person)
        {
            var d = new PersonDialog();
            d.Text = caption;
            d.Person = person;

            if (d.ShowDialog().Equals(DialogResult.OK))
            {
                return d.Person;
            }

            return null;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenApplicationFile();
        }

        private void OpenApplicationFile()
        {
            fileManager1.OpenApplicationFile();
        }
    }
}
