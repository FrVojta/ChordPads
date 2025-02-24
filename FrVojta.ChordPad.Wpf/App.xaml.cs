using FrVojta.ChordPads.Bl;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FrVojta.ChordPads.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public byte StrummerChannel { get; } = 1;

        private IBuilder MidiBuilder { get; }
            = new BuilderNAudio(1);

        public IMidiPlayer MidiPlayer
            => MidiBuilder.MidiPlayer;

        public IStrummer Strummer
            => MidiBuilder.Strummer;

        public BlChordGenerator ChordGenerator { get; }
            = new BlChordGenerator();

        private static object _SyncObject = new object();

        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Strummer.Start();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Strummer.Stop();
        }
    }

}
