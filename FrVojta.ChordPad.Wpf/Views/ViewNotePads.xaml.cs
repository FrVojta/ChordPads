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
    /// Interakční logika pro ViewNotePads.xaml
    /// </summary>
    public partial class ViewNotePads : UserControl
    {
        public static readonly DependencyProperty BaseNoteProperty = DependencyProperty.Register(
            nameof(BaseNote), typeof(Byte),
            typeof(ViewNotePads)
        );

        public Byte BaseNote
        {
            get => (Byte)GetValue(BaseNoteProperty);
            set => SetValue(BaseNoteProperty, value);
        }

        public ViewNotePads()
        {
            InitializeComponent();
        }

        private void Note_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var param = (sender as Button)?.Tag as string;
            if (param == null) return;
            if (param.Length < 1) return;

            (Application.Current as App)
                ?.MidiPlayer
                ?.Play(2, (byte)(BaseNote + param[0] - 'C'), 0);
        }

        private void Note_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var param = (sender as Button)?.Tag as string;
            if (param == null) return;
            if (param.Length < 1) return;

            (Application.Current as App)
                ?.MidiPlayer
                ?.Play(2, (byte)(BaseNote + param[0] - 'C'), 100);
        }
    }
}
