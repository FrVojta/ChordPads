using FrVojta.ChordPads.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrVojta.ChordPads.Wpf.Views
{
    /// <summary>
    /// Interakční logika pro ViewChordPads.xaml
    /// </summary>
    public partial class ViewChordPads : UserControl
    {
        public ViewChordPads()
        {
            InitializeComponent();
        }

        private void ChordPad_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var app = (Application.Current as App);
            if (app == null) return;

            var chordName = (sender as Button)?.Tag as string;
            if (chordName == null) return;
            if (chordName.Length < 1) return;

            var chordId = chordName.TryTranslateToScaleChord();
            if (chordId == null) return;

            var chord = app.ChordGenerator.TryGetScaleChord(60, chordId.Value);
            if (chord == null) return;

            app.Strummer.SetNotes(chord);
        }

        private void ChordPad_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var app = (Application.Current as App);
            if (app == null) return;

            app.Strummer.SetNotes(null);
        }

    }
}
