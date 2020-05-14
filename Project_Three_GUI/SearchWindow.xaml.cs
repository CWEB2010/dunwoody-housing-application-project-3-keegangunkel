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
        DataSource source = new DataSource();
        List<Resident_Student> searchPageList = null;
        List<Student_Count> countList = null;
        public SearchWindow()
        {
            InitializeComponent();
            searchPageList = source.ReadData();
            resident_grid.DataContext = searchPageList;
            resident_grid.ItemsSource = searchPageList;
            countList = source.CountList();
            count_grid.DataContext = countList;
            count_grid.ItemsSource = countList;
            count_grid.Items.Refresh();



        }

        private void search_box_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = searchPageList.Where(Resident_Student => Resident_Student.ID.StartsWith(search_box.Text));

            resident_grid.ItemsSource = filtered;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectionWindow selectionWindow = new SelectionWindow();
            selectionWindow.Show();
            this.Close();
        }
    }
}
