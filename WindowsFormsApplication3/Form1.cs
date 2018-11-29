//------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication3
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            People = new PeopleList();
        }

        /// <summary>
        /// Gets or sets the People
        /// </summary>
        public PeopleList People { get; set; }

        /// <summary>
        /// The AddPerson
        /// </summary>
        private void AddPerson()
        {
            AddPerson(new Person());
        }

        /// <summary>
        /// The AddPerson
        /// </summary>
        /// <param name="defaultPerson">The defaultPerson<see cref="Person"/></param>
        private void AddPerson(Person defaultPerson)
        {
            Person person = AddPersonDialog(defaultPerson);
            if (person != null)
            {
                People.Add(person);
                PopulatePeopleListBox();
            }
        }

        /// <summary>
        /// The AddPersonDialog
        /// </summary>
        /// <param name="defaultPerson">The defaultPerson<see cref="Person"/></param>
        /// <returns>The <see cref="Person"/></returns>
        private Person AddPersonDialog(Person defaultPerson)
        {
            return PersonEditorDialog("New", defaultPerson);
        }

        /// <summary>
        /// The button1_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var d = new Dialog1();
            if (d.ShowDialog().Equals(DialogResult.OK))
            {
                MessageBox.Show("OK");
            }
        }

        /// <summary>
        /// The fileManager1_CreateFile
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="WeblidityComponentLibrary.CreateFileEventArgs"/></param>
        private void fileManager1_CreateFile(object sender, WeblidityComponentLibrary.CreateFileEventArgs e)
        {
            People = new PeopleList();
            PopulatePeopleListBox();
        }

        /// <summary>
        /// The fileManager1_FilenameChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void fileManager1_FilenameChanged(object sender, EventArgs e)
        {
            Text = System.IO.Path.GetFileNameWithoutExtension(fileManager1.FileName);
        }

        /// <summary>
        /// The Form1_FormClosed
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosedEventArgs"/></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changeDetector1.DialogResult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Information is being saved...");
            }
        }

        /// <summary>
        /// The Form1_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = changeDetector1.ConfirmFormClosing();
        }

        /// <summary>
        /// The Form1_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            fileManager1.FileName = "Phrases1.phf";
            People.AddRange(new Person[] { new Person("Ion", "Gireada"), new Person("Dale", "Cooper") });
            PopulatePeopleListBox();
            fileManager1.ChangeDetector.Changed = false;
        }

        /// <summary>
        /// The NewApplicationFile
        /// </summary>
        private void NewApplicationFile()
        {
            fileManager1.NewApplicationFile();
        }

        /// <summary>
        /// The newToolStripButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        /// <summary>
        /// The OpenApplicationFile
        /// </summary>
        private void OpenApplicationFile()
        {
            fileManager1.OpenApplicationFile();
        }

        /// <summary>
        /// The openToolStripButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenApplicationFile();
        }

        /// <summary>
        /// The PersonEditorDialog
        /// </summary>
        /// <param name="caption">The caption<see cref="string"/></param>
        /// <param name="person">The person<see cref="Person"/></param>
        /// <returns>The <see cref="Person"/></returns>
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

        /// <summary>
        /// The PopulatePeopleListBox
        /// </summary>
        private void PopulatePeopleListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(People.FullNames().ToArray());
            fileManager1.ChangeDetector.Changed = true;

            var isPeopleCountZero = listBox1.Items.Count.Equals(0);
            SetControlEnabledCountIsZero(isPeopleCountZero);

            var isPeopleSelectedIndicesCountZero = listBox1.SelectedIndices.Count.Equals(0);
            SetControlEnabledSelectedIndicesCountIsZero(isPeopleSelectedIndicesCountZero);
        }

        /// <summary>
        /// The SaveApplicationFile
        /// </summary>
        private void SaveApplicationFile()
        {
            fileManager1.SaveApplicationFile();
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        private void SaveAsApplicationFile()
        {
            fileManager1.SaveAsApplicationFile();
        }

        /// <summary>
        /// The saveAsToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsApplicationFile();
        }

        /// <summary>
        /// The saveToolStripButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }

        /// <summary>
        /// The SetControlEnabledCountIsZero
        /// </summary>
        /// <param name="isPeopleCountZero">The isPeopleCountZero<see cref="bool"/></param>
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

        /// <summary>
        /// The SetControlEnabledSelectedIndicesCountIsZero
        /// </summary>
        /// <param name="isPeopleSelectedIndicesCountZero">The isPeopleSelectedIndicesCountZero<see cref="bool"/></param>
        private void SetControlEnabledSelectedIndicesCountIsZero(bool isPeopleSelectedIndicesCountZero)
        {
            if (isPeopleSelectedIndicesCountZero)
            {
                SetControlEnabledValue(false, new ToolStripButton[] { toolStripButton3 });
            }
            else
            {
                SetControlEnabledValue(true, new ToolStripButton[] { toolStripButton3 });
            }
        }

        /// <summary>
        /// The SetControlEnabledValue
        /// </summary>
        /// <param name="status">The status<see cref="bool"/></param>
        /// <param name="controls">The controls<see cref="ToolStripButton[]"/></param>
        private void SetControlEnabledValue(bool status, ToolStripButton[] controls)
        {
            controls.ToList().ForEach(c => c.Enabled = status);
        }

        /// <summary>
        /// The toolStripButton1_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        /// <summary>
        /// The toolStripButton2_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
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

        /// <summary>
        /// The toolStripButton3_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Do you want to remove selected item", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).Equals(DialogResult.Yes))
                {
                    People.RemoveAt(listBox1.SelectedIndices[0]);
                }
            }

            PopulatePeopleListBox();
        }
    }
}
