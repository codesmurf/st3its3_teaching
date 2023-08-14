namespace HospitalBed
{
    public class PassthroughFilter : IFilter
    {
        public bool FilterSample(bool sample)
        {
            return sample;
        }
    }
}