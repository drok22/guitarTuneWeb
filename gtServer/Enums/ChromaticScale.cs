using System.ComponentModel;

namespace gtServer.Enums;

public enum ChromaticScale
{
    [Description("A")] A,
    [Description("A#")] ASharp,
    [Description("B")] B,
    [Description("C")] C,
    [Description("C#")] CSharp,
    [Description("D")] D,
    [Description("D#")] DSharp,
    [Description("E")] E,
    [Description("F")] F,
    [Description("F#")] FSharp,
    [Description("G")] G,
    [Description("G#")] GSharp
}
public class ChromaticScaleConversions
{
    public static ChromaticScale ScaleValue(string scaleChar)
    {
        ChromaticScale note = ChromaticScale.A;
        switch (scaleChar)
        {
            case "A": note = ChromaticScale.A; break;
            case "A#": note = ChromaticScale.ASharp; break;
            case "B": note = ChromaticScale.B; break;
            case "C": note = ChromaticScale.C; break;
            case "C#": note = ChromaticScale.CSharp; break;
            case "D": note = ChromaticScale.D; break;
            case "D#": note = ChromaticScale.DSharp; break;
            case "E": note = ChromaticScale.E; break;
            case "F": note = ChromaticScale.F; break;
            case "F#": note = ChromaticScale.FSharp; break;
            case "G": note = ChromaticScale.G; break;
            case "G#": note = ChromaticScale.GSharp; break;
            default: break;
        }
        return note; // FIXME: Error state for when a non-musical note value is passed in?
    }
    public static string NoteStringValue(ChromaticScale note)
    {
        string noteString = "";
        switch (note)
        {
            case ChromaticScale.A: noteString = "A"; break;
            case ChromaticScale.ASharp: noteString = "A#"; break;
            case ChromaticScale.B: noteString = "B"; break;
            case ChromaticScale.C: noteString = "C"; break;
            case ChromaticScale.CSharp: noteString = "C#"; break;
            case ChromaticScale.D: noteString = "D"; break;
            case ChromaticScale.DSharp: noteString = "D#"; break;
            case ChromaticScale.E: noteString = "E"; break;
            case ChromaticScale.F: noteString = "F"; break;
            case ChromaticScale.FSharp: noteString = "F#"; break;
            case ChromaticScale.G: noteString = "G"; break;
            case ChromaticScale.GSharp: noteString = "G#"; break;
            default: break;
        }
        return noteString;
    }
}