namespace FrVojta.ChordPads
{
    public class BeatChangedEventArgs: EventArgs
    {
        public string[] Beats { get; }

        public int Beat { get; }

        public BeatChangedEventArgs(string[] beats, int beat)
        {
            Beats = beats;
            Beat = beat;
        }
    }
}