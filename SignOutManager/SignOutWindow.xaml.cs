using System;
using System.Collections.Generic;
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

namespace SignOutManager
{
  /// <summary>
  /// Interaction logic for SignOutWindow.xaml
  /// </summary>
  public partial class SignOutWindow : Window
  {
    // A List of Students that are currently signed out.
    private readonly List<Student> _studentList = new List<Student>();

    /// <summary>
    /// SignOutWindow constructor.
    /// </summary>
    public SignOutWindow()
    {
      InitializeComponent();
      ListBoxOutStudents.ItemsSource = _studentList;
    }

    private void ButtonSignOut_Click(object sender, RoutedEventArgs e)
    {
      SignOut();
    }

    private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
    {
      SignIn();
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
        _studentList.Add(student);
        ListBoxOutStudents.Items.Refresh();
        ComboBoxReasons.SelectedIndex = -1;
        Console.WriteLine("Student {0} signed out for {1}.", student.Name, student.Reason);
      }
      else
      {
        Console.WriteLine("Input in either Name or Reason cannot be empty.");
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
      Student student = (Student)ListBoxOutStudents.SelectedItem;
      _studentList.Remove(student);
      ListBoxOutStudents.Items.Refresh();
      Console.WriteLine("Student {0} signed in from {1}.", student.Name, student.Reason); // TODO: Fix Null reference exception
    }
  }
}

// TODO: Create popup on SignIn()
// TODO: Create XML file of all Students that signed out
// TODO: Re-format for smaller screen
// TODO: (optional) Create a print log method that will print out a log of all the Students to the connected printer.