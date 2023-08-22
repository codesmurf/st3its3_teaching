using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryExample
{
    public class JournalPaper
    {
        private readonly string _name;
        protected List<ISection> Sections;

        public JournalPaper(string name, string paperType)
        {
            _name = name;
            Sections = SectionsFactory.CreateSections(paperType);
        }


        public void Print()
        {
            Console.WriteLine($"Journal paper '{_name}' contains the following sections:");
            Console.WriteLine("==============================================");
            foreach (var page in Sections)
            {
                page.Print();
            }
            Console.WriteLine("==============================================");
            Console.WriteLine("");
        }

        public void Save()
        {
            Console.WriteLine("Journal paper saved...");
        }

        public void Share()
        {
            Console.WriteLine("Journal paper shared...");
        }


    }

    class SectionsFactory
    {
        public static List<ISection> CreateSections(string paperType)
        {
            List<ISection> sections = new List<ISection>();
            switch (paperType)
            {
                case "Overview":
                    sections.Add(new Abstract());
                    sections.Add(new References());
                    break;

                case "Short paper":
                    sections.Add(new Abstract());
                    sections.Add(new Introduction());
                    sections.Add(new Conclusion());
                    sections.Add(new References());
                    break;

                case "Full paper":
                    sections.Add(new Abstract());
                    sections.Add(new Introduction());
                    sections.Add(new Methods());
                    sections.Add(new Results());
                    sections.Add(new Discussion());
                    sections.Add(new Conclusion());
                    sections.Add(new Acknowledgements());
                    sections.Add(new References());
                    break;
            }
            return sections;
        }
    }
}
