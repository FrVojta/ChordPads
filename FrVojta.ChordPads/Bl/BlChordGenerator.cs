using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads.Bl
{
    public class BlChordGenerator
    {
        public byte[]? TryGetScaleChord(byte scalerRoot, BlScaleChord chord)
        {
            switch (chord)
            {
                case BlScaleChord.I: return GetDurChord(scalerRoot);
                case BlScaleChord.ii: return GetMolChord((byte)(scalerRoot + 2));
                case BlScaleChord.iii: return GetMolChord((byte)(scalerRoot + 4));
                case BlScaleChord.IV: return GetDurChord((byte)(scalerRoot + 5));
                case BlScaleChord.V: return GetDurChord((byte)(scalerRoot + 7));
                case BlScaleChord.V_7: return GetDurChord7((byte)(scalerRoot + 7));
                case BlScaleChord.vi: return GetMolChord((byte)(scalerRoot + 9));
                case BlScaleChord.VI_sharp: return GetDurChord((byte)(scalerRoot + 10));
            }
            return null;
        }

        private byte[] GetDurChord7(byte root)
        {
            return [
                (byte)(root - 12),
                (byte)(root + 00),
                (byte)(root + 04),
                (byte)(root + 07),
                (byte)(root + 10),
                128 ];
        }

        private byte[] GetDurChord(byte root)
        {
            return [
                (byte)(root - 12),
                (byte)(root + 00),
                (byte)(root + 04),
                (byte)(root + 07),
                128,
                128 ];
        }

        private byte[] GetMolChord(byte root)
        {
            return [
                (byte)(root - 12),
                (byte)(root + 00),
                (byte)(root + 03),
                (byte)(root + 07),
                128,
                128 ];
        }


    }
}
