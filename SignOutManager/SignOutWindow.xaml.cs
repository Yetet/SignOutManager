using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace SignOutManager
{
    /// <summary>
    /// Interaction logic for SignOutWindow.xaml
    /// </summary>
    public partial class SignOutWindow : Window
    {
        // A List of Students that are currently signed out.
        private readonly List<Student> _studentList = new List<Student>();
        // List of Students that have signed out.
        private List<Student> _studentLog = new List<Student>();

        private const string _xmlPath = @"\\DESKTOP-E78T4J3\Signout\LOG\SignOutLog.xml";

        /// <summary>
        /// SignOutWindow constructor.
        /// </summary>
        public SignOutWindow()
        {
            InitializeComponent();
            ListBoxOutStudents.ItemsSource = _studentList;
            TextBlockSignOut.Focus();
        }

        private void ButtonSignOut_Click(object sender, RoutedEventArgs e)
        {
            SignOut();
            TextBoxName.Clear();
            this.Focus();
            TextBlockSignOut.Focus();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn();
            WriteLog(_xmlPath);
            this.Focus();
            TextBlockSignOut.Focus();
        }

        private void MenuItemPrint_Click(object sender, RoutedEventArgs e)
        {
            //Tyler Commented This Out TO Test Having The Log Write When A Student Signs In
            //WriteLog(_xmlPath);
        }

        private void MenuItemClear_Click(object sender, RoutedEventArgs e)
        {
            ClearLog(_xmlPath);
        }

        /// <summary>
        /// Create a new Student using the values from TextBoxName and ComboBoxReasons.
        /// Adds the Student to _studentList and refreshes the ListBox.
        /// </summary>
        private void SignOut()
        {
            // Check if both Name and Reason have a value
            if (TextBoxName.Text != string.Empty && ComboBoxReasons.SelectedIndex != -1)
            {
                Student student = new Student(TextBoxName.Text, ComboBoxReasons.Text);
                student.TimeLeft = DateTime.Now;
                _studentList.Add(student);
                ComboBoxReasons.SelectedIndex = -1;
                ListBoxOutStudents.Items.Refresh();
                Console.WriteLine("Student {0} signed out for {1} at {2}.", student.Name, student.Reason, student.TimeLeft);
            }
            else
            {
                Console.WriteLine("Input in either Name or Reason cannot be empty.");
                MessageBox.Show("Input in either Name or Reason cannot be empty.");
            }
        }

        /// <summary>
        /// Signs the Student currently selected in ListBoxOutStudents back in.
        /// Removes the Student from _studentList and refreshes the Listbox.
        /// Adds the Student and it's properties to an XML file to be later printed by the teacher
        /// and sent to the office.
        /// </summary>
        private void SignIn()
        {
            try
            {
                Student student = (Student)ListBoxOutStudents.SelectedItem;
                student.TimeReturned = DateTime.Now;
                _studentLog.Add(student);
                _studentList.Remove(student);
                ListBoxOutStudents.Items.Refresh();
                Console.WriteLine("Student {0} signed in from {1} at {2}.", student.Name, student.Reason, student.TimeReturned);
                MessageBox.Show(student.Name + " signed in from " + student.Reason + ".");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
            }
        }

        /// <summary>
        /// Write the items from _studentLog to an XML file to be printed.
        /// </summary>
        private void WriteLog(string path)
        {
            try
            {
                var xmlWriterSettings = new XmlWriterSettings() { Indent = true };
                XmlSerializer writer = new XmlSerializer(typeof(List<Student>));
                FileStream file = File.OpenWrite(@"\\DESKTOP-E78T4J3\Signout\LOG\SignOutLog.xml");
                writer.Serialize(file, _studentLog);
                file.Close();

               

                Console.WriteLine("Successfully created XML log.");

                            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Could not write Student to XML log. " + e.Message);
            }
        }

        /// <summary>
        /// Remove all of the items from the XML file.
        /// </summary>
        private void ClearLog(string path)
        {
            try
            {
                File.Delete(path);

                Console.WriteLine("Successfully deleted XML log.");
                MessageBox.Show("Successfully deleted log.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Could not delete XML log. " + e.Message);
            }
        }
    }
}
// TODO: Re-format for smaller screen
// TODO: (optional) Create a print log method that will print out a log of all the Students to the connected printer.
// TODO: Request password to use Tools menuItem.