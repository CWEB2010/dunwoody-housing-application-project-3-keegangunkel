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
        SearchWindow datagrid = new SearchWindow();
        DataSource source = new DataSource();
        List<Resident_Student> searchPageList = null;

        Resident_Student aResident;
        int studentWorkerCount;
        int studentScholarshipCount = 1;
        int studentAthleteCount = 1;
        public NewResidentWIndow()
        {
            
            InitializeComponent();
            searchPageList = source.ReadData();

            datagrid.resident_grid.DataContext = searchPageList;
            datagrid.resident_grid.ItemsSource = searchPageList;
        }

        private void addResident(object sender, RoutedEventArgs e)
        {

           ComboBoxItem studentType = (ComboBoxItem)student_type_dropdown.SelectedItem;
           
           /* ComboBoxItem floor = (ComboBoxItem)floor_number_dropdown.SelectedItem;
            ComboBoxItem room = (ComboBoxItem)room_number_dropdown.SelectedItem;
            aResident = new Resident_Student(student_id_box.Text, first_name_box.Text, last_name_box.Text, floor.Content.ToString(), room.Content.ToString(), 100, studentType.Content.ToString());
            searchPageList.Add(aResident);
            source.WriteData(searchPageList);
            datagrid.resident_grid.ItemsSource = searchPageList;
            datagrid.resident_grid.Items.Refresh();
            searchPageList = source.ReadData();*/
            
            if (studentType.Content.ToString() == "Scholarship")
            {
                ComboBoxItem floor = (ComboBoxItem)floor_number_dropdown.SelectedItem;
                ComboBoxItem room = (ComboBoxItem)room_number_dropdown.SelectedItem;
                aResident = new Resident_Student(student_id_box.Text, first_name_box.Text, last_name_box.Text, floor.Content.ToString(), room.Content.ToString(), 100, studentType.Content.ToString());
                searchPageList.Add(aResident);
                source.WriteData(searchPageList);
                datagrid.resident_grid.ItemsSource = searchPageList;
                datagrid.resident_grid.Items.Refresh();
                searchPageList = source.ReadData();
                studentScholarshipCount +=1;
                Student_Count studentAthlete = new Student_Count(studentAthleteCount, studentScholarshipCount, studentWorkerCount);



            }
            else if (studentType.Content.ToString() == "Athlete")
            {
                ComboBoxItem floor = (ComboBoxItem)floor_number_dropdown.SelectedItem;
                ComboBoxItem room = (ComboBoxItem)room_number_dropdown.SelectedItem;
                aResident = new Resident_Student(student_id_box.Text, first_name_box.Text, last_name_box.Text, floor.Content.ToString(), room.Content.ToString(), 1200, studentType.Content.ToString());
                searchPageList.Add(aResident);
                source.WriteData(searchPageList);
                datagrid.resident_grid.ItemsSource = searchPageList;
                datagrid.resident_grid.Items.Refresh();
                searchPageList = source.ReadData();
                studentAthleteCount = studentAthleteCount + 1;
                Student_Count studentAthlete = new Student_Count(studentAthleteCount,studentScholarshipCount,studentWorkerCount);
            }
            else if (studentType.Content.ToString() == "Student Worker")
            {
                ComboBoxItem floor = (ComboBoxItem)floor_number_dropdown.SelectedItem;
                ComboBoxItem room = (ComboBoxItem)room_number_dropdown.SelectedItem;
                double monthlyHours = Convert.ToInt32(monthly_hours_box.Text);
                double monthlyPay = monthlyHours * 14;
                double monthlyRent = 1245 - monthlyPay;
                aResident = new Resident_Student(student_id_box.Text, first_name_box.Text, last_name_box.Text, floor.Content.ToString(), room.Content.ToString(), monthlyRent, studentType.Content.ToString());
                searchPageList.Add(aResident);
                source.WriteData(searchPageList);
                datagrid.resident_grid.ItemsSource = searchPageList;
                datagrid.resident_grid.Items.Refresh();
                searchPageList = source.ReadData();
                studentWorkerCount = studentWorkerCount + 1;
                Student_Count studentAthlete = new Student_Count(studentAthleteCount, studentScholarshipCount, studentWorkerCount);

            }
            datagrid.Show();
            this.Close();

        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            SelectionWindow selectionWindow = new SelectionWindow();
            selectionWindow.Show();
            this.Close();

        }
    }
}
