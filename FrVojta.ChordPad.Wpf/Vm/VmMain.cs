using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FrVojta.ChordPads.Wpf.Vm
{
    public class VmMain: VmData
    {
        public VmNotePads NotePads1 { get; }
            = new VmNotePads();

        public VmNotePads NotePads2 { get; }
            = new VmNotePads();

        public VmBarBeats Beats { get; }

        public VmMain()
        {
            Beats = new VmBarBeats();

            var app = Application.Current as App;
            if (app != null)
            {
                app.Strummer.BeatChanged += BeatChanged;
            }
        }

        private void BeatChanged(object? sender, BeatChangedEventArgs e)
        {
            Beats.SetTimmes(e.Beats, e.Beat);
        }
    }
}
