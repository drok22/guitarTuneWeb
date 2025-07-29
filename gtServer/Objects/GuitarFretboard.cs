namespace gtServer.Objects;

public class GuitarFretboard
{
    public List<GuitarString> GuitarStrings { get; set; }
    int NumStrings { get; set; }

    public GuitarFretboard(int numStrings = 6)
    {
        NumStrings = numStrings;
        List<GuitarString> strings = [];
        for (int i = 0; i < numStrings; i++)
        {
            GuitarString freshString = new();
            strings.Add(freshString);
        }
        GuitarStrings = strings;
    }
}