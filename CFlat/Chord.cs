namespace CFlat;

public class Chord
{
    private List<Note> notes = new List<Note>();

    public Chord(params Note[] notes)
    {
        foreach (var note in notes)
        {
            this.notes.Append(note);
        }
    }
}