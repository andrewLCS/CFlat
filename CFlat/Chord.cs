namespace CFlat;

public class Chord
{
    private List<Note> notes;

    public Chord(params Note[] notes)
    {
        this.notes = new List<Note>(2);

        foreach (var note in notes)
        {
            this.notes.Append(note);
        }
    }
}