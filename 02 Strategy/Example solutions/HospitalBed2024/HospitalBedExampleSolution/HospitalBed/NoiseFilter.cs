namespace HospitalBed
{
    public class NoiseFilter : IFilter
    {
        private bool returnValue = false; // default value until there has been 3 samples of same value
        int trueCount = 0;
        int falseCount = 0;

        public bool Filter(bool sample)
        {
            if (sample == true)
            {
                trueCount++;
                falseCount = 0;
            }
            else
            {
                falseCount++;
                trueCount = 0;
            }

            if (trueCount >= 3)
            {
                returnValue = true;
            }

            if (falseCount >= 3)
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
