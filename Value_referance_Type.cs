using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Value_referance_Type
    {

        public void ValueRefType()
        {
            //------    1   -------------

            //int a = 10;
            //int b = a;
            //b = 20;
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            //-------   3   ------------
            //Person a = new Person();
            //Person b = a;
            //b.Name = "Aram";
            //Console.WriteLine(a.Name);
            //Console.WriteLine(b.Name);

            //---------   4     ---------

            //int[] a = new int[] { 1, 2, 3 };
            //int[] b = a;
            //b[0] = 15;
            //foreach(int el in a)
            //{
            //    Console.WriteLine(el);
            //}
            //Console.WriteLine("------------------");
            //foreach (int el in b)
            //{
            //    Console.WriteLine(el);
            //}

            //----------    5   -----------

            //int x = 15;
            //foo(x);
            //Console.WriteLine(x);

            //---------     6   ------------
            //Person a = new Person();
            //FooPerson(a);
            //Console.WriteLine(a.Name);

            //--------      9   ---------

            //int a = 5;
            //int b = 5;
            //Console.WriteLine(a == b);

            //Person person1 = new Person { Name = "Alice" };
            //Person person2 = new Person { Name = "Alice" };
            //Console.WriteLine(person1 == person2);

            //-------   11  ------------

            //Person ShallowCopy(Person p)
            //{
            //    return p;
            //}

            //Person DeepCopy(Person p)
            //{
            //    return new Person { Name = p.Name };
            //}

            //Person person1 = new Person { Name = "Alice" };
            //Person person2 = ShallowCopy(person1);
            //Person person3 = DeepCopy(person1);

            //person2.Name = "Bob";
            //person3.Name = "Charlie";
            //Console.WriteLine($"person1: {person1.Name}"); 
            //Console.WriteLine($"person2: {person2.Name}"); 
            //Console.WriteLine($"person3: {person3.Name}"); 

            //---------     14      -----------

            //int defaultInt = default(int);
            //bool defaultBool = default(bool);
            //Person defaultPerson = default(Person);

            //Console.WriteLine($"defaultInt: {defaultInt}"); // Should print 0
            //Console.WriteLine($"defaultBool: {defaultBool}"); // Should print False
            //Console.WriteLine($"defaultPerson: {defaultPerson}"); // Should print null

        }
        public void Foo(int x) 
        {
            Console.WriteLine(x*2);
        }

        public void FooPerson(Person person)
        {
            person.Name = "Lilit";
            Console.WriteLine(person.Name);
        }
    }

    class Person
    {
        public string Name { get; set; } = "Ararat";
    }
}
