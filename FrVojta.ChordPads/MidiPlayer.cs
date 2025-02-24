using NAudio.Midi;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads
{

    internal class MidiPlayer : IDisposable, IMidiPlayer
    {
        private readonly ConcurrentDictionary<int, DateTime> _Notes
            = new ConcurrentDictionary<int, DateTime>();

        public MidiOut? MidiDevice { get; private set; }

        public MidiPlayer()
        {
            MidiDevice = new MidiOut(0);
            MidiDevice.Send(new PatchChangeEvent(0, 1, (byte)MidiInstrument.AcousticGuitarSteel)
                .GetAsShortMessage());
        }

        public void Play(byte channel, byte note, byte velocity)
        {
            var code = (int)(note + (channel << 8));
            if (velocity == 0)
            {
                _Notes.Remove(code, out _);
                NoteOff(note);
                return;
            }

            if (_Notes.ContainsKey(code)) NoteOff(note);
            _Notes[code] = DateTime.UtcNow;

            NoteOn(note, velocity);
        }

        public void Mute(byte channel, byte note, byte vleocity)
        {
            var code = (int)(note + (channel << 8));

            _Notes.Remove(code, out _);
            NoteOff(note);
            return;
        }


        private void NoteOn(byte note, byte velocity)
        {
            var noteOn = new NoteEvent(
                0, 1, MidiCommandCode.NoteOn, note, velocity);
            MidiDevice?.Send(noteOn.GetAsShortMessage());
        }

        private void NoteOff(byte note)
        {
            var noteOff = new NoteEvent(
                0, 1, MidiCommandCode.NoteOff, note, 0);
            MidiDevice?.Send(noteOff.GetAsShortMessage());
        }

        void IDisposable.Dispose()
        {
            var outDevice = MidiDevice;
            MidiDevice = null;

            outDevice?.Dispose();
            _Notes.Clear();
        }
    }
}
