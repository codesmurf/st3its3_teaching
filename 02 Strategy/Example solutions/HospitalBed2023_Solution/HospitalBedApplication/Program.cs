// See https://aka.ms/new-console-template for more information

using HospitalBed;
using HospitalBed.Alarm;
using HospitalBed.Filter;

Console.WriteLine("Hello, World!");

var bedControl = new BedControl();
var presenceSensor = new PresenceSensor(bedControl);

var i = 0;
while (i < 100)
{
    presenceSensor.ReadSample();

    var consoleKeyInfo = Console.ReadKey();
    Console.SetCursorPosition(0, Console.CursorTop);
    switch (consoleKeyInfo.Key)
    {
        case ConsoleKey.L:
            bedControl.alarm = new Light();
            break;
        case ConsoleKey.B:
            bedControl.alarm = new Buzzer();
            break;
        case ConsoleKey.P:
            Console.WriteLine("Using pass-through");
            bedControl.filter = new PassThrough();
            break;
        case ConsoleKey.N:
            Console.WriteLine("Using noise");
            bedControl.filter = new Noise();
            break;
        default:
            break;
    }


    i++;
}