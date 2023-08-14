using System;
using HospitalBed.Filtering;

namespace HospitalBed.SimpleFactory
{
    public class FilterFactory
    {
        public static IFilter CreateFilter(string descriptor)
        {
            if (descriptor == "Noise") return new NoiseFilter();
            if (descriptor == "Raw") return new RawFilter();
            throw new ArgumentException("Unknown filter descriptor: " + descriptor);
        }
    }
}
