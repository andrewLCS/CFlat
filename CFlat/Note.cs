namespace CFlat;

public struct Note
{
    public enum Letter
    {
        A, B, C, D, E, F, G
    }
    public enum Accent
    {
        DoubleFlat = -2,
        Flat = -1,
        Natural = 0,
        Sharp = 1,
        DoubleSharp = 2
    }

    private Letter letter;
    private Accent accent;
    private int octave;

    public Note()
    {
        letter = Letter.C;
        accent = Accent.Natural;
        octave = 3; // "middle C"
    }

    public Note(string note)
    {
        (Letter letter, Accent accent, int octave) = ParseNoteString(note);
        this.letter = letter;
        this.accent = accent;
        this.octave = octave;
    }

    public Note(Letter letter, Accent accent, int octave)
    {
        this.letter = letter;
        this.accent = accent;
        this.octave = octave;
    }

    public override readonly string ToString()
    {
        return letter.ToString() + AccentToString() + octave;
    }

    private readonly string AccentToString() =>
        accent switch 
        {
            Accent.DoubleFlat => "bb",
            Accent.Flat => "b",
            Accent.Natural => "",
            Accent.Sharp => "#",
            Accent.DoubleSharp => "##",
            _ => throw new ArgumentException($"Invalid accent value {accent}")
        };

    private readonly Accent StringToAccent(string accent) =>
        accent switch 
        {
            "bb" => Accent.DoubleFlat,
            "b" => Accent.Flat,
            "" => Accent.Natural,
            "#" => Accent.Sharp,
            "##" => Accent.DoubleSharp,
            _ => throw new ArgumentException($"Invalid accent value {accent}")
        };

    // need to rewrite this method using regex, will probably make life easier
    private static (Letter, Accent, int) ParseNoteString(string noteString)
    {

        if (string.IsNullOrEmpty(noteString))
            throw new ArgumentException("Note string cannot be null or empty.");

        char letterChar = noteString[0];
        if (!Enum.TryParse(letterChar.ToString(), false, out Letter letterParse)) 
            throw new ArgumentException($"Invalid note letter '{letterChar}'. Must be A-G (capitals).");
        Letter noteLetter = letterParse;

        char secondChar = noteString[1];
        if (Char.IsNumber(secondChar)) // octave, no accent
        {
            if (noteString.Length > 2)
                throw new ArgumentException("Octave value must be only one digit 0-8.");
        }
        Accent noteAccent = Accent.Natural;

        return (noteLetter, noteAccent, 3);
    }

}
