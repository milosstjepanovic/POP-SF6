using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP.Tests
{
    class Test1
    {
        static void main(string[] args)
        {
            Person p1 = new Person("John", "Doe");
            //p1.Name = "New name John";


            Person p2 = new Person("Marko", "Markovci");
            Person p3 = new Person("Nikola", "Nikolic");
            Person p4 = new Person("Aleksa", "Aleksic");


            List<string> strings = new List<string>();

            int[] a = { 1, 2, 3 };

            /*for (var i = 0; i < a.Count(); i++)
            {
                Console.Write(a[i] + ", ");
                strings.Add($"broj {a[i]}");
            }*/

            strings.Add("rucno dodat broj 4");

            foreach (var item in strings)
            {

            }

            string[] s = { "Nikola Nikolic", "Marko Markovic", "Janko Jankovic", "Aleksa Aleksic", "Milos Milosevic", "Ranko Rankovic" };

            for (var i = 0; i < s.Count(); i++)
            {
                Console.Write(s[i] + "\n");
            }


            //Console.WriteLine(String.Format("Hello my name is: {0}, and my last name is: {1}", p1.Name, p1.Surname));
            //Console.WriteLine($"Hello my name is: {p1.Name}, and my last name is: {p1.Surname}");
            Console.ReadLine();
        }
    }
}
