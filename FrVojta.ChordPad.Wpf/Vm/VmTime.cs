using System.Windows;

namespace FrVojta.ChordPads.Wpf.Vm
{
    public class VmTime: VmData
    {
        public string Text
        {
            get => _Text;
            set
            {
                if (_Text == value) return;
                _Text = value;
                OnPropertyChanged();
            }
        }
        private string _Text = "";

        public string FrameColor
        {
            get => IsActive ? "Black" : "Transparent";
        }

        public bool IsActive
        {
            get => _IsActive;
            set
            {
                if (_IsActive == value) return;
                _IsActive = value;
                // Text = IsActive ? "○⬤🠙🠛🠑🠓│🠠 🠢 🠡 🠣 ,🠤 🠦 🠥 🠧 ,🠨 🠪 🠩 🠫 ,🠬 🠮 🠭 🠯 ,🠰 🠲 🠱 🠳" : "○";
                OnPropertyChanged();
                OnPropertyChanged(nameof(FrameColor));
            }
        }
        private bool _IsActive = false;

        // "○⬤·│🠡🠣🠥🠧🠩🠫🠭🠯🠱🠳"
        public static string TranslateText(string text)
        {
            return text
                .Replace("D", "🠛")
                .Replace("d", "🠓")
                .Replace("U", "🠙")
                .Replace("u", "🠑")
                .Replace(".", "·")
                ;
        }
    }
}