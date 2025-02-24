using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads
{
    public abstract class BuilderAbstract : IBuilder
    {
        public byte StrummerChannel { get; }

        public BuilderAbstract(byte strummerChannel = 1)
        {
            StrummerChannel = strummerChannel;
        }

        protected static object _SyncObj = new object();

        public abstract IMidiPlayer MidiPlayer { get; }

        public IStrummer Strummer
        {
            get
            {
                if (_Strummer != null) return _Strummer;
                lock (_SyncObj)
                {
                    if (_Strummer != null) return _Strummer;
                    _Strummer = new Strummer(MidiPlayer, StrummerChannel);
                }
                return _Strummer;
            }
        }
        private IStrummer? _Strummer = null;
    }
}
