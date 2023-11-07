namespace EKG;

public class ECG
{
    public string CPR { get; set; }
    public double Average { get; set; }
    public double Max { get; set; }
    public double Min { get; set; }
    public DateTime? Date { get; set; } = null;
}