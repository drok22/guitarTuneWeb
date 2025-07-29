using gtServer.Enums;

namespace gtServer.Objects;

public class GuitarString
{
    public List<ChromaticScale> CSNotes { get; set; }
    public List<string> SNotes { get; set; }
    public int NumFrets { get; set; }
    public GuitarString(int numFrets = 24)
    {
        NumFrets = numFrets;
        CSNotes = [];
        SNotes = [];
    }
    public void TuneString(ChromaticScale note)
    {
        List<ChromaticScale> csNotes = [];
        List<string> sNotes = [];
        ChromaticScale nextNote = note;

        for (int i = 0; i < NumFrets; i++)
        {
            csNotes.Add(nextNote);
            sNotes.Add(ChromaticScaleConversions.NoteStringValue(nextNote));
            nextNote = ScalePatterns.FindNextNote(nextNote);
        }
        CSNotes = csNotes;
        SNotes = sNotes;
    }
}