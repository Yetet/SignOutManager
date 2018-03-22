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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SignOutManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This Window shouldn't be used. It's only a placeholder to switch to SignOutWindow.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Switch to SignOutWindow.
            new SignOutWindow().Show();
            this.Close();
        }
    }
}
