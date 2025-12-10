using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person a = new Person("Slim", "Shady");
            Person b = new Person("Arnold", "Swarzenegger");

            a.SayHello();
            a.SayTagLine();

            b.SayHello();
            b.SayTagLine();

            Console.ReadKey();
        }
    }
}
