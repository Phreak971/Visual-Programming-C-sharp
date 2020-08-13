using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Wpf_Data_Grid_and_Data_Binding_Using_List
{
    //All Code is Same As Previous Project ... The Few New lines Added Will be with a Comment
    //It Takes Only 3 More Lines of code to Bind Data To The Data Grid
    public class Student
    {
        public int Roll_Number { set; get; }
        public string Student_Name { set; get; }
        public DateTime DateofBirth { set; get; }
        public string Gender { set; get; }
        public char Section { set; get; }
        public double Cgpa { set; get; }
        public string[] SubjectsSelected { set; get; } = new string[5];
        public static string NamesList { get; set; }

        public static ObservableCollection<Student> StudentsClassList { get; set; } = new ObservableCollection<Student>();    //Add An ObservableCollection List
        //to the class which stores instances of the class ... Normal List cannot be used here this is a special type of list used for binding to the Data Grid

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataGridStudent.ItemsSource = Student.StudentsClassList;    //As Soon as the Program Starts We have Binded The Grid To the ObservableCollection List
        }
        private void Button_showall_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Student.NamesList);
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
                    student.Roll_Number = Int32.Parse(rollnumber);
                    student.Student_Name = Name;
                    student.DateofBirth = (DateTime)dob;
                    student.Gender = Gender;
                    student.Section = char.Parse(section);
                    student.Cgpa = double.Parse(cgpa);
                    student.SubjectsSelected = subjects.ToArray();
                    Student.NamesList += Name + "\n";
                    Student.StudentsClassList.Add(student); //When A Student Entry is created we push the class object to this List so it gets added to the Data Grid
                    MessageBox.Show("Student Added Successfully");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
