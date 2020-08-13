using System;
using System.Collections.Generic;
using System.Data;  //required
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Two Tables
            //Table 2
            DataTable Students = new DataTable("Students");
            Students.Columns.Add("Reg Id", typeof(int));
            Students.Columns.Add("Full Name", typeof(string));
            Students.Columns.Add("Section", typeof(char));
            Students.Columns.Add("Gender", typeof(string));
            Students.PrimaryKey = new DataColumn[] { Students.Columns["Reg ID"] };    //Set Primary Key
            //Table 2 
            DataTable Cgpa = new DataTable("Student CGPA");
            Cgpa.Columns.Add("Reg Id", typeof(int));
            Cgpa.Columns.Add("Cgpa", typeof(double));
            Cgpa.PrimaryKey = new DataColumn[] { Cgpa.Columns["Reg Id"] };  //Set Primary Key
            //Ab humain dono tables ko foreign constraint se relate krna ha ... agr koi Reg Id Cgpa k table me
            //enter hogi toh uska Students k table me hona zaroori ha ku k agr student exist krta ha toh uska cgpa hoga naw ...
            //isliye hum foreign key constraint lagayenge
            ForeignKeyConstraint ForeignKey = new ForeignKeyConstraint("Foreign_Key", Students.Columns["Reg Id"], Cgpa.Columns["Reg Id"]);  //Creating Foreign Key
            Cgpa.Constraints.Add(ForeignKey);   //Adding Foreign Key to Cgpa Table           
            //Foreign Key Constatint Add krdia ha lkn work tb hii kre ga jb dono tables aik set k andar hnge ... isliye aikmset bna k dono tables usme daalenge
            DataSet BSCS_V = new DataSet("BSCS-V");
            BSCS_V.Tables.Add(Students);   //Student Table added to set
            BSCS_V.Tables.Add(Cgpa);   //CGPA Table Added to Set
            //Entering Data in Table
            //Dont Forget to Handle Exceptions
            try
            {
                Cgpa.Rows.Add(170360, 3.33);    //Error aye ga ku k ye Reg Id abhi exist nhi krti Student Table me
            }
            catch (InvalidConstraintException e)    //For Foreign Key Voilation
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Students.Rows.Add(170420, "Shazeel", 'D', "Male");
                Students.Rows.Add(170344, "Kaleem", 'D', "Male");
                Cgpa.Rows.Add(170420, 3.05);
                Students.Rows.Add(170344, "Kaleem", 'D', "Male");   //Error Aye ga ku k Primary key repeaat ho rhi ha
            }
            catch (ConstraintException e)   //For Primary Key Voilation
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(BSCS_V.GetXml()); //Shajra Nasb Display krta ha Set ka xml jesa xDD
            Console.WriteLine(BSCS_V.GetXmlSchema());   //An XML Schema describes the structure of an XML document .. Full Type ka code bna deta ha xD 
        }
    }
}
