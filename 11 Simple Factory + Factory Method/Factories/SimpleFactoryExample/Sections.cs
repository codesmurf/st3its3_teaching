using System;

namespace SimpleFactoryExample
{
    // The interface for sections in a journal paper
    public interface ISection
    {
        void Print();
    }

    // Concrete sections in a journal paper
    class Abstract : ISection
    {
        public void Print() => Console.WriteLine("Abstract");
    }

    class Introduction : ISection
    {
        public void Print() => Console.WriteLine("Introduction");
    }

    class Methods : ISection
    {
        public void Print() => Console.WriteLine("Methods");
    }

    class Results : ISection
    {
        public void Print() => Console.WriteLine("Results");
    }

    class Discussion : ISection
    {
        public void Print() => Console.WriteLine("Discussion");
    }


    class Conclusion : ISection
    {
        public void Print() => Console.WriteLine("Conclusion");
    }

    class Acknowledgements : ISection
    {
        public void Print() => Console.WriteLine("Acknowledgements");
    }

    class References : ISection
    {
        public void Print() => Console.WriteLine("References");
    }
}