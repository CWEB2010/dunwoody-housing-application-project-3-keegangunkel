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
    /// Interaction logic for NewResidentWIndow.xaml
    /// </summary>
    public partial class NewResidentWIndow : Window
    {
        DataSource source = new DataSource();
        List<Resident_Student> searchPageList = null;
        Resident_Student aResident;
        public NewResidentWIndow()
        {
            InitializeComponent();
            searchPageList = source.ReadData();
            this.DataContext = searchPageList;
            //resident_grid.ItemsSource = searchPageList;
        }

        private void addResident(object sender, RoutedEventArgs e)
        {

        }
    }
}
