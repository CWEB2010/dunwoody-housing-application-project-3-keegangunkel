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
        //Initializes my source for the data and a new search window so I can access the resident data grid from another window
        SearchWindow datagrid = new SearchWindow();
        DataSource source = new DataSource();
        // List to hold the data read in
        List<Resident_Student> searchPageList = null;
        //Initialize a resident variable
        Resident_Student aResident;
        // Counters for the dsplaying of how many students of each type there are
        int studentWorkerCount;
        int studentScholarshipCount;
        int studentAthleteCount;

        public NewResidentWIndow()
        {
            
            InitializeComponent();
            //Reads in the data to the datagrid
            searchPageList = source.ReadData();
            datagrid.resident_grid.DataContext = searchPageList;
            datagrid.resident_grid.ItemsSource = searchPageList;
        }

        //Method to add residents
        private void addResident(object sender, RoutedEventArgs e)
        {

           ComboBoxItem studentType = (ComboBoxItem)student_type_dropdown.SelectedItem;
            //If and else if statments, basically identitical except for the rent pay and the counters, so I won't comment everyone for redundant purposes
            if (studentType.Content.ToString() == "Scholarship")
            {
                // Assigns the dropdown menus to variables
                ComboBoxItem floor = (ComboBoxItem)floor_number_dropdown.SelectedItem;
                ComboBoxItem room = (ComboBoxItem)room_number_dropdown.SelectedItem;
                // Creates a new Resident based off of the inputted values
                aResident = new Resident_Student(student_id_box.Text, first_name_box.Text, last_name_box.Text, floor.Content.ToString(), room.Content.ToString(), 100, studentType.Content.ToString());
                searchPageList.Add(aResident);
                // Writes out the list to the data file 
                source.WriteData(searchPageList);
                // These next 3 commands work together to make sure the resident data grid is up to date with the right information
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

        //Method to go back to the selection window
        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            SelectionWindow selectionWindow = new SelectionWindow();
            selectionWindow.Show();
            this.Close();

        }
    }
}
