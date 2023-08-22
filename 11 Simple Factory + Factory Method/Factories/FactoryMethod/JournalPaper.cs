using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    abstract class JournalPaper
    {
        private readonly string _name;
        protected List<ISection> Sections = new List<ISection>();

        protected JournalPaper(string name)
        {
            _name = name;
            CreateSections();
        }

        // CreateSections() creates the individual sections that go into this journal paper
        // This is the FACTORY METHOD. It is abstract, so subclasses will need to implement 
        // it. Thereby, subclasses gain control of which pages are actually created.
        // General document handling (Save, Print, Share, etc.) is identical regardless of 
        // the sections in the paper, so this is handled in this class
        protected abstract void CreateSections();


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
            Console.WriteLine("JournalPaper saved...");
        }

        public void Share()
        {
            Console.WriteLine("JournalPaper shared...");
        }
    }


    class FullPaper : JournalPaper
    {
        public FullPaper(string name) : base(name)
        {
        }

        protected override void CreateSections()
        {
            Sections.Add(new Abstract());
            Sections.Add(new Introduction());
            Sections.Add(new Methods());
            Sections.Add(new Results());
            Sections.Add(new Discussion());
            Sections.Add(new Conclusion());
            Sections.Add(new Acknowledgements());
            Sections.Add(new References());
        }
    }

    class ShortPaper : JournalPaper
    {
        public ShortPaper(string name) : base(name)
        {
        }

        protected override void CreateSections()
        {
            Sections.Add(new Abstract());
            Sections.Add(new Introduction());
            Sections.Add(new Conclusion());
            Sections.Add(new References());
        }
    }

    class Overview : JournalPaper
    {
        public Overview(string name) : base(name)
        {
        }

        protected override void CreateSections()
        {
            Sections.Add(new Abstract());
            Sections.Add(new References());
        }
    }
}
