using System.IO;

namespace HospitalBed.Logging
{
    internal class FileWriter : IWriter
    {
        private readonly string _filename;

        public FileWriter(string filename)
        {
            _filename = filename;
        }

        public void Write(string s)
        {
            using (var file = new StreamWriter(_filename, true))
            {
                file.WriteLine(s);
            }
        }
    }
}