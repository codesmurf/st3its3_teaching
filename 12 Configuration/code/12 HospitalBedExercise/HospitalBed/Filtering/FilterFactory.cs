using System;

namespace HospitalBed.Filtering
{
    public class FilterFactory
    {
        public static IFilter CreateFilter(string descriptor)
        {
            switch (descriptor.ToLower())
            {
                case "noise":
                    return new NoiseFilter();
                case "raw":
                    return new RawFilter();
                default:
                    throw new ArgumentException("Unknown filter descriptor: " + descriptor);
            }
        }
    }
}