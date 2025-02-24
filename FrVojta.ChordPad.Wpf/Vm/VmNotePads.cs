using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrVojta.ChordPads.Wpf.Vm
{
    public class VmNotePads: VmData
    {
        public int BaseNote
        {
            get => _BaseNote;
            set
            {
                if (_BaseNote == value) return;
                _BaseNote = value;
                OnPropertyChanged();
            }
        }
        private int _BaseNote = 60;
    }
}
