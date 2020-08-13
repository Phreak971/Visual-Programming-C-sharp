using System;
using System.Collections.Generic;
using System.Data;
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

namespace Wpf_Data_Grid_and_Data_Binding_using_Data_Tables
{
    //In This Method We Will Not Make members of class We Will
    //Just Make 2 Functions To Create A Table and Add Data to Table After Collecting it from views(that code is same as previous two)
    //and Link the Data Table to the Data Grid


    //Open Project in Full Screen to see all DataGrid Entries
    public class Student
    {
        public static DataTable studentTable = new DataTable("Student");    //Student Table
        public static void CreateTable()    //creating Data Table ie Adding Columns/Headings
        {
            studentTable.Columns.Add("RollNumber", typeof(int));
            studentTable.Columns.Add("StudentName", typeof(string));
            studentTable.Columns.Add("DateofBirth", typeof(DateTime));
            studentTable.Columns.Add("Gender", typeof(string));
            studentTable.Columns.Add("Section", typeof(char));
            studentTable.Columns.Add("Cgpa", typeof(double));
            studentTable.PrimaryKey = new DataColumn[] { studentTable.Columns["RollNumber"] };
        }
        public static void AddToTable(int roll, string stu, DateTime dob, string gen, char sec, double cgpa) //Adding Data to Table
        {
            try
            {
                studentTable.Rows.Add(roll, stu, dob, gen, sec, cgpa);
                MessageBox.Show("Student Added Successfully");
            }
            catch (ConstraintException ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Student.CreateTable();  //As Soon As Program Starts Create Table 
            DataGridStudent.ItemsSource = Student.studentTable.DefaultView; //And Link The Student Table with the Data Grid in the xaml

        }
        private void Button_savestudents_Click(object sender, RoutedEventArgs e)
        {
            string rollnumber = textBox_RollNumber.Text;
            string Name = textBox_Name.Text;
            DateTime? dob = datepicker_dob.SelectedDate;
            string cgpa = textBox_CGPA.Text;
            string section = ComboBox_Section.Text;

            if (rollnumber.Equals("") || Name.Equals("") || !(dob.HasValue) || cgpa.Equals("") || section.Equals("") || (Radiobutton_Female.IsChecked == false && Radiobutton_Male.IsChecked == false))
            {
                MessageBox.Show("All Fields Must Be Filled");
                return;
            }
            else
            {
                string Gender;
                if (Radiobutton_Male.IsChecked == true)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }
                List<string> subjects = new List<string>();
                CheckBox[] CheckBoxes = new CheckBox[] { checkbox_vp, checkbox_ccn, checkbox_daa, checkbox_na, checkbox_hrm };
                for (int i = 0; i < CheckBoxes.Length; i++)
                {
                    if (CheckBoxes[i].IsChecked == true)
                    {
                        string subname = CheckBoxes[i].Content.ToString();
                        subjects.Add(subname);
                    }
                }
                Student student = new Student();
                try
                {
                    /*From Previous Code
                    student.Roll_Number = Int32.Parse(rollnumber);
                    student.Student_Name = Name;
                    student.DateofBirth = (DateTime)dob;
                    student.Gender = Gender;
                    student.Section = char.Parse(section);
                    student.Cgpa = double.Parse(cgpa);
                    student.SubjectsSelected = subjects.ToArray();
                    Student.NamesList += Name + "\n";*/
                    Student.AddToTable(Int32.Parse(rollnumber), Name, (DateTime)dob, Gender, char.Parse(section), double.Parse(cgpa));  //parsing and pushing to function
                }
                catch (Exception ee)    //if there is parsing error
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
