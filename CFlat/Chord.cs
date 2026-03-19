namespace CFlat;

public class Chord
{
    private List<Note> notes = new List<Note>();

    public Chord(params Note[] ns)
    {
        foreach (var note in ns)
        {
            this.notes.Append(note);
        }
    }
}