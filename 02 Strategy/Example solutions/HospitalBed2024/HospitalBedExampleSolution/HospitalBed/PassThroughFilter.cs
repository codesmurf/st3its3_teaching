namespace HospitalBed
{
    public class PassThroughFilter : IFilter
    {
        public bool Filter(bool sample)
        {
            return sample;
        }
    }
}
