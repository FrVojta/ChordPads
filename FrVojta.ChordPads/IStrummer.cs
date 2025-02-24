using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads
{
    public interface IStrummer
    {
        event EventHandler<BeatChangedEventArgs>? BeatChanged;

        void SetNotes(byte[]? chord);
        void Start();
        void Stop();
    }
}
