namespace CFlat;

public struct Note
{
    private readonly char letter;
    private readonly byte value;

    public Note()
    {
        letter = 'C';
        value = 3; // "middle C"
    }

    public Note(char letter, byte value)
    {
        if (!(letter == 'A' || letter == 'B' || letter == 'C'
            || letter == 'D' || letter == 'E' || letter == 'F' || letter == 'G')
            ||
            (value < 0 && value > 8))
        {
            throw new ArgumentException("Invalid note entered. Notes are written as a letter [A-G] followed by a value [0-8]. (ex. D3)");
        }

        this.letter = letter;
        this.value = value;
    }

    public override readonly string ToString()
    {
        return letter + "" + value;
    }
}
