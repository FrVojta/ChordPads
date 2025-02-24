namespace FrVojta.ChordPads.Wpf.Vm
{
    public class VmChordInfo: VmData
    {
        public VmChordInfo(string scaleDeg, string name)
        {
            ScaleDeg = scaleDeg;
            Name = name;
        }

        public string ScaleDeg { get; }
        public string Name { get; }

        public static implicit operator VmChordInfo(string text)
        {
            var tt = text.Split('/');
            return new VmChordInfo(tt[0].Trim(), tt[1].Trim());
        }
    }
}