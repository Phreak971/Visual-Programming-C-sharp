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

namespace Wpf_Grid_and_Some_More_Views
{
    //1. Create A Student Class To make Data manipulation easier
    public class Student
    {
        public int Roll_Number { set; get; }
        public string Student_Name { set; get; }
        public DateTime DateofBirth { set; get; }
        public string Gender { set; get; }
        public char Section { set; get; }
        public double Cgpa { set; get; }
        public string[] SubjectsSelected { set; get; } = new string[5];
        public static string NamesList { get; set; }   //ye list ha student k names ki jb b koi student ka object bane ga toh uska naam is string me add ho jaye ga
        //isko use krke hum sbke naam display kara denge .. ye static isliye ha ku k ye class ki property ha ... kisi aik student ki nai ha
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_showall_Click(object sender, RoutedEventArgs e) //When SHOW ALL Button will be clicked this function will be called
        {
            //yahan pe hum list me jo naam save hain unko show kr denge message Box me bs
            MessageBox.Show(Student.NamesList);
        }

        private void Button_savestudents_Click(object sender, RoutedEventArgs e)    //When Save Student Button will be clicked this function will be called
        {   //2. Jab Button click hoga hum saara data lenge aur Student class ka aik object bna k usme save kr denge

            string rollnumber = textBox_RollNumber.Text;    //Getting RollNumber from textBox
            string Name = textBox_Name.Text;    //Getting Name  from TextBox
            DateTime? dob = datepicker_dob.SelectedDate;    //Getting Date from Date Picker
            string cgpa = textBox_CGPA.Text;    //Getting Cgpa from TextBox
            string section = ComboBox_Section.Text; //Getting Section From ComboBox

            //3. Now We Need To Check if these views are empty if any of them is empty we will not proceed
            if (rollnumber.Equals("")    //agr roll number khaali ha 
                || Name.Equals("")      //ya Name khaali ha
                || !(dob.HasValue)     //ya dob me value nhi ha
                || cgpa.Equals("")     //ya cgpa me khaali ha
                || section.Equals("")   //ya section khaali ha
                || (Radiobutton_Female.IsChecked == false && Radiobutton_Male.IsChecked == false)  //ya dono radio button gender me se aik b select nai hua va
               )
            {
                //toh hum Message Show karenge aur is Function ko idher hii khtm kr denge kuch save nhi karenge
                MessageBox.Show("All Fields Must Be Filled");
                return; //khtm krde ga function ko
            }
            else    //agr khaali nhi ha koi b toh hum aage save karenge sb
            {
                //Getting Selected Value From Radio Buttons
                string Gender;
                if (Radiobutton_Male.IsChecked == true)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }

                //CheckBoxes me se tick hue ve checkBox Get karenge
                List<string> subjects = new List<string>();
                CheckBox[] CheckBoxes = new CheckBox[] { checkbox_vp, checkbox_ccn, checkbox_daa, checkbox_na, checkbox_hrm };  //aik check boxes ki array bna k sb check boxes usme initialize krdiye
                for (int i = 0; i < CheckBoxes.Length; i++) //har checkbox k liye loop chalaenge
                {
                    if (CheckBoxes[i].IsChecked == true)    //agr check hua va ha
                    {
                        string subname = CheckBoxes[i].Content.ToString();  //jo tick hua va hoga uska content string ban k save ho jaye ga
                        subjects.Add(subname);  //aur usko hum list me b add kr denge
                    }
                }
                //ab hum ne sb cheezain get krli hain
                //ab student class ka object bna k usme daalna ha bs
                Student student = new Student();

                //yahan pe hum data ko string se required datatype me parse b karenge toh usme runtime error b aa skta ha ... crash se b bachne k liye hum is cheez ko try catch me karenge
                try
                {
                    student.Roll_Number = Int32.Parse(rollnumber);
                    student.Student_Name = Name;
                    student.DateofBirth = (DateTime)dob;
                    student.Gender = Gender;
                    student.Section = char.Parse(section);
                    student.Cgpa = double.Parse(cgpa);
                    student.SubjectsSelected = subjects.ToArray();
                    Student.NamesList += Name + "\n";   //yahan class ki property me add krdia hmne name
                    MessageBox.Show("Student Added Successfully");
                }
                catch (Exception ee)    //for example string in put in roll number it cannot pe parsed to interger so this exception will run
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
