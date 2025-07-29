using gtServer.Enums;

namespace gtServer.Objects;

public class ScaleBuilder
{
    public ChromaticScale[] CScale { get; set; }
    public List<string> SScale { get; set; }

    public ScaleBuilder()
    {
        CScale = [];
        SScale = [];
    }
    public void BuildScales(string key, string keyType, string scaleType)
    {
        ChromaticScale[] cScale;
        ChromaticScale cKey = ChromaticScaleConversions.ScaleValue(key);
        bool isMajorKey = keyType == "Major";

        switch (scaleType)
        {
            case "Pentatonic":
                cScale = ScalePatterns.PentatonicScalePattern(cKey, isMajorKey);
                break;
            case "Minor":
                cScale = ScalePatterns.MinorScalePattern(cKey);
                break;
            case "Major":
                cScale = ScalePatterns.MajorScalePattern(cKey);
                break;
            case "Blues":
                cScale = ScalePatterns.BluesScalePattern(cKey, isMajorKey);
                break;
            default: cScale = ScalePatterns.FullChromaticScale(); break;
        }
        CScale = cScale;
        SScale = ConvertCScaleToSScale(cScale);
    }
    public List<string> ConvertCScaleToSScale(ChromaticScale[] scalePattern)
    {
        List<string> sScale = [];
        foreach (ChromaticScale note in scalePattern)
        {
            sScale.Add(ChromaticScaleConversions.NoteStringValue(note));
        }
        return sScale;
    }
}