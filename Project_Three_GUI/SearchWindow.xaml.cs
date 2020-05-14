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
        List<Prospective_Student> searchPageList = null;
        public SearchWindow()
        {
            InitializeComponent();
            searchPageList = source.ReadData();
            this.DataContext = searchPageList;
            resident_grid.ItemsSource = searchPageList;
        }
    }
}
