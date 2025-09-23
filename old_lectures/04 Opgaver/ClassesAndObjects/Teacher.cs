using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Teacher: IPerson
    {
    private string name;
    private string mumble;

    public Teacher(string name, string mumble)
    {
        this.name = name;
        this.mumble = mumble;
    }

    public void SaySomething()
    {
        Console.WriteLine("{0} says {1}", name, mumble);
    }
    }
}
