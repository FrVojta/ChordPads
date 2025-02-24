using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads
{
    internal class Strummer: IStrummer
    {
        private Thread? _StrummingThread = null;

        private static object _SyncObject = new object();

        public byte[] Notes { get; }
            = new byte[6] {128, 48, 60, 64, 67, 128};

        private byte[]? _NotesNext = null;

        public string Pattern { get; set; } = "|D.|dU|.u|du"; 
        // "|D.|du|D.|du"; // "UD..D.","uD..D.","UD..D.","uD..D.",".D..U.",".D..d.",".D..d.","UD.UD*";

        public IMidiPlayer Player { get; }

        public byte Channel { get; }

        public string[] Beats
        {
            get => _Beats;
        }
        private string[] _Beats = new string[0];

        public int Beat
        {
            get => _Beat;
        }
        private int _Beat = 0;

        protected virtual void ChangeBeats(string[] beats, int beat)
        {
            _Beat = beat;
            _Beats = beats;
            BeatChanged?.Invoke(this, new BeatChangedEventArgs(beats, beat));
        }

        public event EventHandler<BeatChangedEventArgs>? BeatChanged = null;

        public Strummer(IMidiPlayer player, byte channel)
        {
            Player = player;
            Channel = channel;
        }

        public void Start()
        {
            if (_StrummingThread != null) return;
            lock (_SyncObject)
            {
                _StrummingThread = new Thread(StrummingLoop)
                {
                    IsBackground = true,
                };
                _StrummingThread.Start();
            }
        }

        public void Stop()
        {
            var thread = _StrummingThread;
            _StrummingThread = null;
            if (thread == null) return;
            thread.Join();
        }

        public void SetNotes(byte[]? newNotes)
        {
            _NotesNext = newNotes;
        }

        private void StrummingLoop(object? args)
        {
            var currentThread = Thread.CurrentThread;
            while (!IsStopped())
            {
                var pattern = Pattern ?? "";
                var beats = pattern.Split('|');
                var beat = 0;

                if (beats.Length == 0 || _NotesNext == null)
                {
                    Thread.Sleep(1);
                    ChangeBeats(beats, beat);
                    continue;
                }

                foreach (var c in pattern)
                {
                    if (c == '|')
                    {
                        ChangeBeats(beats, beat);
                        beat = beat + 1;
                        ApplyNextNotes();
                        continue;
                    }
                    var vel = GetVelocity(c);
                    foreach (var n in Strum(Notes, c))
                    {
                        PlayNote(n, vel);
                        Thread.Sleep(20);
                        if (IsStopped()) break;
                    }
                    if (IsStopped()) break;
                    Thread.Sleep(230);
                }
                if (IsStopped()) break;

                if (String.IsNullOrWhiteSpace(pattern))
                    Thread.Sleep(1);
            }

            bool IsStopped()
                => currentThread != _StrummingThread;
        }

        private void PlayNote(byte n, byte vel)
        {
            if (n >= 128) return;

            Player.Play(Channel, n, vel);
        }

        private void MuteNote(byte n, byte velocity = 0)
        {
            if (n >= 128) return;

            Player.Mute(Channel, n, velocity);
        }

        private byte GetVelocity(char c)
        {
            if ("du".Contains(c)) return 80;
            if ("DU".Contains(c)) return 95;
            return 0;
        }

        private IEnumerable<byte> Strum(byte[] notes, char c)
        {
            if ("Dd".Contains(c))
            {
                for (var i = 0; i < notes.Length; i++)
                    yield return notes[i];
            }

            if ("Uu".Contains(c))
            {
                for (var i = notes.Length - 1; i >= 0; i--)
                    yield return notes[i];
            }

            for (var i = 0; i < notes.Length; i++)
                yield return 128;
        }

        private void ApplyNextNotes()
        {
            var newNotes = Interlocked.Exchange(ref _NotesNext, null);
            if (newNotes == null) return;

            var notes = Notes;
            for (var i = 0; i < notes.Length; i++)
            {
                var n = (i < newNotes.Length)
                    ? newNotes[i]
                    : 128;
                notes[i] = (byte)n;
            }
        }
    }
}
