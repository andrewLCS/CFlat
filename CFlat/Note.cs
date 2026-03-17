using System.Security.AccessControl;

namespace CFlat;

public struct Note
{
    private enum Letter
    {
        A, B, C, D, E, F, G
    }
    private enum Accent
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
        (Letter letter, Accent accent, int octave) = ParseNote(note);
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

    private static (Letter, Accent, int) ParseNote(string note)
    {
        if (string.IsNullOrEmpty(note))
            throw new ArgumentException("Note string cannot be null or empty.");

        char letterChar = note[0];
        if (!Enum.TryParse(letterChar.ToString(), true, out Letter letter)) 
            throw new ArgumentException($"Invalid note letter '{letterChar}'. Must be A-G");

        return (Letter.C, Accent.Natural, 3);
    }

}
