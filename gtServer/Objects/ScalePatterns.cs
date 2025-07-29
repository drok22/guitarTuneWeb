using gtServer.Enums;

namespace gtServer.Objects;

public class ScalePatterns
{
    // MinorScalePattern - whole, half, whole, whole, half, whole, whole
    public static ChromaticScale[] MinorScalePattern(ChromaticScale note)
    {
        ChromaticScale[] scalePattern = new ChromaticScale[7];
        ChromaticScale nextStep = note;
        for (int i = 0; i < scalePattern.Length; i++)
        {
            if (i == 0) // root
                scalePattern[i] = note;
            else if ((i == 2) || (i == 5)) // half step
            {
                nextStep = FindNextInterval(1, nextStep);
                scalePattern[i] = nextStep;
            }
            else // whole step
            {
                nextStep = FindNextInterval(2, nextStep);
                scalePattern[i] = nextStep;
            }
        }
        return scalePattern;
    }
    // MajorScalePattern - whole, whole, half, whole, whole, whole, half
    public static ChromaticScale[] MajorScalePattern(ChromaticScale note)
    {
        ChromaticScale[] scalePattern = new ChromaticScale[7];
        ChromaticScale nextStep = note;
        for (int i = 0; i < scalePattern.Length; i++)
        {
            if (i == 0) // root
                scalePattern[i] = note;
            else if ((i == 3) || (i == 7)) // half step
            {
                nextStep = FindNextInterval(1, nextStep);
                scalePattern[i] = nextStep;
            }
            else // whole step
            {
                nextStep = FindNextInterval(2, nextStep);
                scalePattern[i] = nextStep;
            }
        }
        return scalePattern;
    }
    public static ChromaticScale[] PentatonicScalePattern(ChromaticScale note, bool isMajorKey)
    {
        if (isMajorKey)
            return MajorPentatonicScalePattern(note);
        else
            return MinorPentatonicScalePattern(note);
    }
    // Minor Pentatonic Pattern - 3,2,2,3 (semitones)
    public static ChromaticScale[] MinorPentatonicScalePattern(ChromaticScale note)
    {
        ChromaticScale[] scalePattern = new ChromaticScale[5];
        ChromaticScale nextStep = note;
        for (int i = 0; i < scalePattern.Length; i++)
        {
            if (i == 0) // root
                scalePattern[i] = note;
            else if ((i == 2) || (i == 3)) // 2 semitones
            {
                nextStep = FindNextInterval(2, nextStep);
                scalePattern[i] = nextStep;
            }
            else // 3 semitones
            {
                nextStep = FindNextInterval(3, nextStep);
                scalePattern[i] = nextStep;
            }
        }
        return scalePattern;
    }
    // Major Pentatonic Pattern - 2,2,3,2 (semitones)
    public static ChromaticScale[] MajorPentatonicScalePattern(ChromaticScale note)
    {
        ChromaticScale[] scalePattern = new ChromaticScale[5];
        ChromaticScale nextStep = note;
        for (int i = 0; i < scalePattern.Length; i++)
        {
            if (i == 0) // root
                scalePattern[i] = note;
            else if (i == 3) // 3 semitones
            {
                nextStep = FindNextInterval(3, nextStep);
                scalePattern[i] = nextStep;
            }
            else // 2 semitones
            {
                nextStep = FindNextInterval(2, nextStep);
                scalePattern[i] = nextStep;
            }
        }
        return scalePattern;
    }
    public static ChromaticScale[] BluesScalePattern(ChromaticScale note, bool isMajorKey)
    {
        if (isMajorKey)
            return MajorBluesScalePattern(note);
        else
            return MinorBluesScalePattern(note);
    }
    // Minor Blues Pattern - 3, 2, 1, 1, 3
    public static ChromaticScale[] MinorBluesScalePattern(ChromaticScale note)
    {
        ChromaticScale[] scalePattern = new ChromaticScale[6];
        ChromaticScale nextStep = note;
        for (int i = 0; i < scalePattern.Length; i++)
        {
            if (i == 0) // root
                scalePattern[i] = note;
            else if ((i == 3) || (i == 4)) // 1 semitone
            {
                nextStep = FindNextInterval(1, nextStep);
                scalePattern[i] = nextStep;
            }
            else if (i == 2) // 2 semitones
            {
                nextStep = FindNextInterval(2, nextStep);
                scalePattern[i] = nextStep;
            }
            else // 3 semitones
            {
                nextStep = FindNextInterval(3, nextStep);
                scalePattern[i] = nextStep;
            }
        }
        return scalePattern;
    }
    // Major Blues Pattern - 2, 1, 1, 3, 2
    public static ChromaticScale[] MajorBluesScalePattern(ChromaticScale note)
    {
        ChromaticScale[] scalePattern = new ChromaticScale[6];
        ChromaticScale nextStep = note;
        for (int i = 0; i < scalePattern.Length; i++)
        {
            if (i == 0) // root
                scalePattern[i] = note;
            else if ((i == 2) || (i == 3)) // 1 semitone
            {
                nextStep = FindNextInterval(1, nextStep);
                scalePattern[i] = nextStep;
            }
            else if ((i == 1) || (i == 5)) // 2 semitones
            {
                nextStep = FindNextInterval(2, nextStep);
                scalePattern[i] = nextStep;
            }
            else // 3 semitones
            {
                nextStep = FindNextInterval(3, nextStep);
                scalePattern[i] = nextStep;
            }
        }
        return scalePattern;
    }
    // Pre-made scales
    public static ChromaticScale[] FullChromaticScale()
    {
        return
        [
            ChromaticScale.A,
            ChromaticScale.ASharp,
            ChromaticScale.B,
            ChromaticScale.C,
            ChromaticScale.CSharp,
            ChromaticScale.D,
            ChromaticScale.DSharp,
            ChromaticScale.E,
            ChromaticScale.F,
            ChromaticScale.FSharp,
            ChromaticScale.G,
            ChromaticScale.GSharp
        ];
    }
    // Finding intervals
    private static ChromaticScale FindNextInterval(int interval, ChromaticScale note)
    {
        note += interval;
        if (!Enum.IsDefined(note))
            note -= 12;
        return note;
    }
    public static ChromaticScale FindNextNote(ChromaticScale note) => FindNextInterval(1, note);
    public static ChromaticScale FindThird(ChromaticScale note) => FindNextInterval(3, note);
    public static ChromaticScale FindFourth(ChromaticScale note) => FindNextInterval(4, note);
    public static ChromaticScale FindFifth(ChromaticScale note) => FindNextInterval(5, note);
    public static ChromaticScale FindSixth(ChromaticScale note) => FindNextInterval(6, note);
    public static ChromaticScale FindSeventh(ChromaticScale note) => FindNextInterval(7, note);
}