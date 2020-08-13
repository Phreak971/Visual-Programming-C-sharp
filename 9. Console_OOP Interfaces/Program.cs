using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Console_OOP_Interfaces
{
    public interface IHuman
    {
        /*An Interface has no implementaion of its own the methods and members in it are abstract 
        Interface me members daalne ka maqsad sirf ye ha k jo class b is interface se inherit hogi usko ye sb cheezain 
        lazmi impelemnt krni hngi wrna error aye ga*/

        int Hands { get; set; } //access modifier nai lagayenge interface k andar
        int Legs { set; get; }
        void Born();
        void Live();
        void Die();
    }
    public class Man : IHuman
    {
        //It is necessary to implement the members of Inteface IHuman in this class
        //yahan pe interface se inherit hue ve har member ka access modifier sirf public hoga uske ilawa nai rakh skte
        public int Hands { set; get; }
        public int Legs { set; get; }
        public void Born()
        {
            Console.WriteLine("Man_Azaan();");
        }
        public void Live()
        {
            Console.WriteLine("Man_Khwaari();");
        }
        public void Die()
        {
            Console.WriteLine("Man_Janaza();");
        }
        public void WhoAreYou()
        {
            Console.WriteLine("I am a Man");
        }
    }
    public class Women : IHuman
    {
        //It is necessary to implement the members of Inteface IHuman in this class
        //yahan pe interface se inherit hue ve har member ka access modifier sirf public hoga uske ilawa nai rakh skte
        public int Hands { set; get; }
        public int Legs { set; get; }
        public void Born()
        {
            Console.WriteLine("Women_Azaan();");
        }
        public void Live()
        {
            Console.WriteLine("Women_Khwaari();");
        }
        public void Die()
        {
            Console.WriteLine("Women_Janaza();");
        }
        public void WhoAreYou()
        {
            Console.WriteLine("I am a Woman");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Man man = new Man();    //Man ka object bna k man k members of access kr skte hain
            man.WhoAreYou();
            man.Live();

            Women women = new Women();  //Women ka object bna k man k members of access kr skte hain
            women.WhoAreYou();
            women.Live();

            //Interface k object se Dynamic binding krke b dono ko use kr skte but sirf wo members jo interface se inherit hue hain
            IHuman obj;

            obj = new Man();
            //obj.WhoAreYou();  //cannot be used as it is not inherited from interface
            obj.Born();
            obj.Live();
            obj.Die();

            obj = new Women();
            // obj.WhoAreYou();  //cannot be used as it is not inherited from interface
            obj.Born();
            obj.Live();
            obj.Die();
        }
    }

}
