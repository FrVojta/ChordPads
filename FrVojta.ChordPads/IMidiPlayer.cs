using NAudio.Midi;

namespace FrVojta.ChordPads
{
    public interface IMidiPlayer
    {
        void Play(byte channel, byte note, byte velocity);

        void Mute(byte channel, byte note, byte vleocity);
    }
}