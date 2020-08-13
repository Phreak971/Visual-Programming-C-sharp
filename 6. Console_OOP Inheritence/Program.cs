using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_OOP_Inheritence
{
    public class Dude
    {
        public string name;
        public int hp = 100;
        public int mp = 0;
        public void sayName()
        {
            Console.WriteLine(name);
        }

    }
    public class Wizard : Dude
    {
        LinkedList<string> spells = new LinkedList<string>();
        public void cast(String spell)
        {
            mp = -10;
        }
    }
    public class GrandWizard : Wizard
    {
        new public void sayName()   //new is used to override the sayName function in parent class Dude
        {
            Console.WriteLine("Grand Wizard " + name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GrandWizard grandWizard = new GrandWizard();    //Grand Wizard Object   
            grandWizard.name = "Flash"; //grandWizard Name set to flash
            grandWizard.sayName();  //sayName from Grand Wizard Class will be called
            ((Dude)grandWizard).sayName();  // the same object is type caseted to Dude and sayName is called .... This time sayName from Dude class will be called for the same object
            GrandWizard obj = new GrandWizard();    //new Object of Grand Wizard Class
            ((Dude)obj).sayName(); //type casted to Dude so sayName from Dude class will be called ... output is empty space bcz name value is not set for this object
        }
    }
}
