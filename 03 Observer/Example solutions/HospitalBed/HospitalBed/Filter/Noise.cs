namespace HospitalBed.Filter;

public class Noise : IFilter
{
    private readonly int _threshold;
    private int _trueCount = 0;
    private int _falseCount = 0;
    private bool _currentOutput = false;

    public Noise(int threshold = 3)
    {
        _threshold = threshold;
    }

    public bool Filter(bool sample)
    {
        if (sample)
        {
            ++_trueCount;
            _falseCount = 0;
        }
        else
        { 
            ++_falseCount;
            _trueCount = 0;
        }
        if (_trueCount >= _threshold && _currentOutput == false) _currentOutput = true;
        else if (_falseCount >= _threshold && _currentOutput) _currentOutput = false;

        return _currentOutput;
    }
}