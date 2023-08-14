using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp1
{
    internal class Celebrity : IPerson
    {
        private string name;
        private string tagline;

        public Celebrity(string name, string tagline)
        {
            this.name = name;
            this.tagline = tagline;
        }

        public void SaySomething()
        {
            Console.WriteLine("{0} says {1}", name, tagline);
        }
    }
}
