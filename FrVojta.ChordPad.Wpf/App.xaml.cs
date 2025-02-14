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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Class1.Test();
        }
    }

}
