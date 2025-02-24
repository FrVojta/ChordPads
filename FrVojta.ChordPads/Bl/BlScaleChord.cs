using System.Runtime.CompilerServices;

namespace FrVojta.ChordPads.Bl
{
    public enum BlScaleChord
    {
        I,
        ii,
        iii,
        IV,
        V,
        V_7,
        vi,
        VI_sharp
    }

    public static class BlScaleCordEx
    {
        public static BlScaleChord? TryTranslateToScaleChord(this string chordName)
        {
            switch (chordName)
            {
                case "I": return BlScaleChord.I;
                case "ii": return BlScaleChord.ii;
                case "iii": return BlScaleChord.iii;
                case "IV": return BlScaleChord.IV;
                case "V": return BlScaleChord.V;
                case "V7": return BlScaleChord.V_7;
                case "vi": return BlScaleChord.vi;
                case "VI#": return BlScaleChord.VI_sharp;
            };
            return null;
        }
    }

}
