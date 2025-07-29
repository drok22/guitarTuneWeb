using gtServer.Enums;


namespace gtServer.Objects;

public class GuitarTuner
{
    public string Tuning { get; set; }
    public string TuningType { get; set; }
    public int NumStrings { get; set; }
    public GuitarFretboard Fretboard { get; set; }

    public GuitarTuner(string tuning = "E", string tuningType = "Standard", int numStrings = 6)
    {
        Tuning = tuning;
        TuningType = tuningType;
        NumStrings = numStrings;
        Fretboard = new GuitarFretboard(numStrings);
    }
    public void TuneGuitar()
    {   // Start at the bass string, and tune the guitar based on request input
        // FIXME: the structure of this part has gotten a little hard to understand. TuneThisString() functions
        // don't actually tune the strings, and we're doing that separately. Update this to make more sense.
        ChromaticScale bassString = TuneBassString(ChromaticScaleConversions.ScaleValue(Tuning));
        Fretboard.GuitarStrings[5].TuneString(bassString);

        ChromaticScale fifthString = TuneFifthString(bassString);
        Fretboard.GuitarStrings[4].TuneString(fifthString);

        ChromaticScale fourthString = TuneFourthString(fifthString);
        Fretboard.GuitarStrings[3].TuneString(fourthString);

        ChromaticScale thirdString = TuneThirdString(fourthString);
        Fretboard.GuitarStrings[2].TuneString(thirdString);

        ChromaticScale secondString = TuneSecondString(thirdString);
        Fretboard.GuitarStrings[1].TuneString(secondString);

        ChromaticScale firstString = TuneFirstString(secondString);
        Fretboard.GuitarStrings[0].TuneString(firstString);
    }
    private ChromaticScale TuneBassString(ChromaticScale note)
    {
        return note;
    }
    private ChromaticScale TuneFifthString(ChromaticScale note) // 'A' string
    {
        ChromaticScale fifthString = note;

        if (TuningType.Equals("Standard")) // (E) 5th (A) 5th(D) 5th (G) 4th (B) 5th(E)
            fifthString = ScalePatterns.FindFifth(note);
        else if (TuningType.Equals("Drop")) // (D) 7th (A) 5th (D) 5th (G) 4th (B) 5th (E)
            fifthString = ScalePatterns.FindSeventh(note);
        else if (TuningType.Equals("Open")) // (E) 6th (B) 5th (E) 4th (G#) 3rd (B) 5th (E)
            fifthString = ScalePatterns.FindSixth(note);

        return fifthString;
    }
    private ChromaticScale TuneFourthString(ChromaticScale note) // 'D' string
    {
        return ScalePatterns.FindFifth(note);
    }
    private ChromaticScale TuneThirdString(ChromaticScale note) // 'G' string
    {
        ChromaticScale thirdString = note;

        if (TuningType.Equals("Standard") || TuningType.Equals("Drop")) // (E) 5th (A) 5th(D) 5th (G) 4th (B) 5th(E)
            thirdString = ScalePatterns.FindFifth(note);

        else if (TuningType.Equals("Open")) // (E) 6th (B) 5th (E) 4th (G#) 3rd (B) 5th (E)
            thirdString = ScalePatterns.FindFourth(note);

        return thirdString;
    }
    private ChromaticScale TuneSecondString(ChromaticScale note) // 'B' string
    {
        ChromaticScale secondString = note;

        if (TuningType.Equals("Standard") || TuningType.Equals("Drop")) // (E) 5th (A) 5th(D) 5th (G) 4th (B) 5th(E)
            secondString = ScalePatterns.FindFourth(note);
        else if (TuningType.Equals("Open")) // (E) 6th (B) 5th (E) 4th (G#) 3rd (B) 5th (E)
            secondString = ScalePatterns.FindThird(note);

        return secondString;
    }
    private ChromaticScale TuneFirstString(ChromaticScale note) // 'E' string(high)
    {
        return ScalePatterns.FindFifth(note);
    }
}