using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Data_Structures_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SortedDictonary");
            //Sorted Dictionary Implements the IDictionary interface
            SortedDictionary<string, double> ADictionary = new SortedDictionary<string, double>();  //<key,value>
            //IDictionary<string, double> ADictionary = new SortedDictionary<string, double>(); is also valid
            //values can be added using initializer list like
            //SortedDictionary<int, string> ADictionary = new SortedDictionary<int, string>() { { 1, "One" }, { 2, "Two" }, { 3, "Three" } };
            ADictionary.Add("Mateen", 3.4);
            ADictionary.Add("Shazeel", 3.05);   //SortedDictonary 2 cheezain save krti ha pehli cheez
            ADictionary.Add("Kaleem", 3.2);       //uski key hoti ha jiski base pe sort hoti ha dictionary
            ADictionary.Add("Awais", 2.8);         //Aur doosri cheez wo value hoti ha jo hmne save karani ha
                                                   //yahan pe name key ha so alphabetically name sort hnge dictionary me .... aur save hmne cgpa karanay hain
                                                   //Sorted Dictrionary Sorts the values based on Keys
            foreach (KeyValuePair<string, double> keyValuePair in ADictionary)  //treversal using foreach
            {
                Console.WriteLine(keyValuePair.Key + "\t" + keyValuePair.Value);
            }
            /*Treversal using for loop
            for (int i = 0; i < ADictionary.Count; i++)
            {
                string key = ADictionary.Keys.ElementAt(i);
                double value = ADictionary[key];
                Console.WriteLine(key + "\t" + value);
            }*/

            Console.WriteLine("Dictionary");
            //Dictionary Implements the IDictionary interface
            Dictionary<string, double> SimpleDictionary = new Dictionary<string, double>();  //<key,value>
            //IDictionary<string, double> SimpleDictionary = new Dictionary<string, double>(); is also valid
            //Everying is same as in a sorted Dictionary .... bs ye wali dictionry sort nhi krti xD
            SimpleDictionary.Add("Mateen", 3.4);
            SimpleDictionary.Add("Shazeel", 3.05);
            SimpleDictionary.Add("Kaleem", 3.2);    //jis squence me add kiye hain usi sequence me rahenge      
            SimpleDictionary.Add("Awais", 2.8);
            foreach (KeyValuePair<string, double> keyValuePair in SimpleDictionary)  //treversal using foreach
            {
                Console.WriteLine(keyValuePair.Key + "\t" + keyValuePair.Value);
            }
            //ussi trah for loop se b treverse kr skte hain jese upar comments me kiya hua
        }
    }
}
