using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            JournalPaper paper = new ShortPaper("A short paper");
            paper.Print();

            paper = new Overview("An overview");
            paper.Print();

            paper = new FullPaper("A full paper");
            paper.Print();

        }
    }
}
