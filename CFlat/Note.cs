namespace CFlat;

public struct Note
{
    public enum Letter
    {
        C, D, E, F, G, A, B
    }

    public enum Accidental
    {
        DoubleFlat = -2,
        Flat = -1,
        Natural = 0,
        Sharp = 1,
        DoubleSharp = 2
    }

    private int value;
    private int oct;

    public Note()
    {
        value = 0;
        oct = 3; // "middle C"
    }

    public Note(string note)
    {
        (int value, int octave) = NoteStringToNote(note);
        this.value = value;
        this.oct = octave;
    }

    public Note(Letter letter, Accidental acc, int octave)
    {
        this.value = NoteToValue(letter, acc);
        this.oct = octave;
    }

    public override readonly string ToString()
    {
        return value + "" + oct;
    }

    private static string AccidentalToString(Accidental accent) =>
        accent switch 
        {
            Accidental.DoubleFlat => "bb",
            Accidental.Flat => "b",
            Accidental.Natural => "",
            Accidental.Sharp => "#",
            Accidental.DoubleSharp => "##",
            _ => throw new ArgumentException($"Invalid accidental value {accent}")
        };

    private static Accidental StringToAccidental(string str) =>
        str switch 
        {
            "bb" => Accidental.DoubleFlat,
            "b" => Accidental.Flat,
            "" => Accidental.Natural,
            "#" => Accidental.Sharp,
            "##" => Accidental.DoubleSharp,
            _ => throw new ArgumentException($"Invalid accidental: {str}")
        };

    // need to rewrite this method using regex, will probably make life easier
    private static (int, int) NoteStringToNote(string noteString)
    {

        if (string.IsNullOrEmpty(noteString))
            throw new ArgumentException("Note string cannot be null or empty.");

        char letterChar = noteString[0];
        if (!Enum.TryParse(letterChar.ToString(), false, out Letter letterParse)) 
            throw new ArgumentException($"Invalid note letter '{letterChar}'. Must be A-G (capitals).");
        Letter noteLetter = letterParse;

        char secondChar = noteString[1];
        if (char.IsNumber(secondChar)) // octave, no accent
        {
            if (noteString.Length > 2)
                throw new ArgumentException("Octave value must be only one digit 0-8.");
        }
        Accidental noteAccent = Accidental.Natural;

        return (noteLetter, noteAccent, 3);
    }

}
