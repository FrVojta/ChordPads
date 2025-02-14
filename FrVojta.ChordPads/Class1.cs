namespace FrVojta.ChordPads;

public class Class1
{
    public static void Test()
    {
        using (var midiDevice = new NAudio.Midi.MidiOut(0))
        {
            var note = new NAudio.Midi.NoteEvent(0, 1, NAudio.Midi.MidiCommandCode.NoteOn, 60, 100);
            midiDevice.Send(note.GetAsShortMessage());
            Thread.Sleep(1000);
        };

    }
}
