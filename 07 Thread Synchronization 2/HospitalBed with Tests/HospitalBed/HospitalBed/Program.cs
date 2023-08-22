using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalBedLib;

namespace HospitalBed
{
    class Program
    {
        static void Main(string[] args)
        {
            Bed hospitalBed = new Bed();
            hospitalBed.Start();


            Console.WriteLine("Press 'x' to quit");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "x":
                        hospitalBed.Stop();
                        Thread.Sleep(1000);
                        return;
                }
            }


        }
    }
}
