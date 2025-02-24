using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads.Wpf.Vm
{
    internal class VmChordPads: VmData
    {
        public int Base
        {
            get => _Base;
        }
        private int _Base = 60;

        public VmChordInfo[] ChordNames
        {
            get
            {
                return _ChordNames;
            }
        }
        private VmChordInfo[] _ChordNames;

        private VmChordInfo[][] ChordSet = new VmChordInfo[][] {
            new VmChordInfo[] { "I / C ", "ii / Dm",  "iii / Em",  "IV / F",  "V / G",  "vi / Am",  "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C#", "ii / D#m", "iii / Fm",  "IV / F#", "V / G#", "vi / A#m", "VI# / B",  "V7 / G#7"},
            new VmChordInfo[] { "I / D ", "ii / Em",  "iii / F#m", "IV / G",  "V / A",  "vi / Bm",  "VI# / C",  "V7 / A7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
            new VmChordInfo[] { "I / C",  "ii / Dm", "iii / Em", "IV / F", "V / G", "vi / Am", "VI# / A#", "V7 / G7"},
        };

        public VmChordPads()
        {
            _ChordNames = ChordSet[2];
        }
    }
}
