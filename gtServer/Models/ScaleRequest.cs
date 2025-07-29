namespace gtServer.Models;

public class ScaleRequest
{
    public string Key { get; set; } = string.Empty;
    public string KeyType { get; set; } = string.Empty;
    public string Tuning { get; set; } = string.Empty;
    public string TuningType { get; set; } = string.Empty;
    public string ScaleType { get; set; } = string.Empty;
    public int NumStrings { get; set; }
}