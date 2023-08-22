using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var paper = new JournalPaper("A short paper", "Short paper");
            paper.Print();

            paper = new JournalPaper("An overview", "Overview");
            paper.Print();

            paper = new JournalPaper("A full paper", "Full paper");
            paper.Print();
        }
    }
}
