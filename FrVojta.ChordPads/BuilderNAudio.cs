using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads
{
    public class BuilderNAudio : BuilderAbstract, IBuilder
    {
        public BuilderNAudio(byte strummerChannel = 1)
            : base(strummerChannel)
        { }

        public override IMidiPlayer MidiPlayer
        {
            get
            {
                if (_MidiPlayer != null)
                    return _MidiPlayer;

                lock (_SyncObj)
                {
                    if (_MidiPlayer != null)
                        return _MidiPlayer;
                    _MidiPlayer = new MidiPlayer();
                }

                return _MidiPlayer;
            }
        }
        IMidiPlayer? _MidiPlayer = null;
    }
}
