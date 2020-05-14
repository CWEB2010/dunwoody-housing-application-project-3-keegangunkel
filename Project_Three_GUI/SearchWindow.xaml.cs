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
using Project_3.Models;
namespace Project_3
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        //Initializes my source for the data
        DataSource source = new DataSource();
        // Create lists to hold the data in
        List<Resident_Student> searchPageList = null;
        List<Student_Count> countList = null;
        public SearchWindow()
        {
            InitializeComponent();
            // Reads in the data to the resident data grid
            searchPageList = source.ReadData();
            resident_grid.DataContext = searchPageList;
            resident_grid.ItemsSource = searchPageList;
            // Reads in every student type and counts it then puts it into the counter data grid
            countList = source.CountList();
            count_grid.DataContext = countList;
            count_grid.ItemsSource = countList;
            count_grid.Items.Refresh();



        }

        // Method that filters out the students based off of the student ID
        private void search_box_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = searchPageList.Where(Resident_Student => Resident_Student.ID.StartsWith(search_box.Text));

            resident_grid.ItemsSource = filtered;
        }
        //Method to take you back to the selection window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectionWindow selectionWindow = new SelectionWindow();
            selectionWindow.Show();
            this.Close();
        }
    }
}
