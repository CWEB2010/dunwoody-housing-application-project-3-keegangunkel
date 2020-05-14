using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Project_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
            private void GoToSelectionWindow(object sender, RoutedEventArgs e)
            {

                if (username_box.Text == "home" && password_box.Text.ToString() == "1234")
                {
                SelectionWindow selectionWindow = new SelectionWindow();
                selectionWindow.Show();
                this.Close();
                }
            else
            {
                Console.WriteLine("Wrong username or password. Please try again.");
            }

            }

        
    }
}
