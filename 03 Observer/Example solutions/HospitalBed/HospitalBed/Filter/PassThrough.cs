using HospitalBed.Alarm;

namespace HospitalBed.Filter;

public class PassThrough : IFilter
{
    public bool Filter(bool sample)
    {
        return sample;
    }
}