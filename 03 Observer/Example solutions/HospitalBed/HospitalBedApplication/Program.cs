// See https://aka.ms/new-console-template for more information

using HospitalBed;
using HospitalBed.Alarm;
using HospitalBed.Filter;
using HospitalBed.Log;

Console.WriteLine("Hello, World!");

var bedControl = new BedControl();
var alarming = new Alarming(bedControl);
var log = new Log(bedControl);
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
            alarming.Alarm = new Light();
            break;
        case ConsoleKey.B:
            alarming.Alarm = new Buzzer();
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