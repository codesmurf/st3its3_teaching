using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Celebrity obiwan = new Celebrity("Obi wan kenobi", "use the force");
            Celebrity eminem = new Celebrity("Eminem", "do you kids like violence?");
            Celebrity parishilton = new Celebrity("Paris hilton", "Hi babe!");

            List<IPerson> celebrities = new List<IPerson>();
            celebrities.Add(obiwan);
            celebrities.Add(eminem);
            celebrities.Add(parishilton);
            celebrities.Add(new Celebrity("Tessa", "Lad vær med at glo på mig. Vil du boks eller ha mit nummer?"));

            foreach (Celebrity celebrity in celebrities)
            {
                celebrity.SaySomething();
            }

            Teacher henrik = new Teacher("Henrik", "kod for helvede!!");
            Teacher michael = new Teacher("Michael", "drik øl!");

            celebrities.Add(henrik);
            celebrities.Add(michael);

            foreach (IPerson person in celebrities)
            {
                person.SaySomething();
            }
        }
    }
}
