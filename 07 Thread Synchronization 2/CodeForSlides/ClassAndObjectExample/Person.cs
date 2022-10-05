using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjectExample
{
    class Person
    {
        private string givenName;
        private string surName;
        public string taglLine { get; set; } = "";

        public Person(string givenName, string surName)
        {
            this.givenName = givenName;
            this.surName = surName;
        }

        public void SayHello()
        {
            Console.WriteLine("My name is: {0} {1}", givenName, surName);
        }

        public void SayTagLine()
        {
            Console.WriteLine(taglLine);
        }

    }
}
