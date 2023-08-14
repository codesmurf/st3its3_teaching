namespace HospitalBed.Filtering
{
    public class RawFilter : IFilter
    {
        public bool FilterSample(bool sample)
        {
            return sample;
        }
    }
}