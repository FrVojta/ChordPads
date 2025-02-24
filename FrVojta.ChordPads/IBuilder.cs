using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads
{
    public interface IBuilder
    {
        IMidiPlayer MidiPlayer { get; }

        IStrummer Strummer { get; }
    }
}
