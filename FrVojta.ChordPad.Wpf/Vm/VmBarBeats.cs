using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FrVojta.ChordPads.Wpf.Vm
{
    public class VmBarBeats: VmData
    {
        public VmCommand<String> CmdSetStrummPattern { get; }

        public ObservableCollection<VmTime> Times { get; }
            = new ObservableCollection<VmTime>();

        public VmBarBeats()
        {
            CmdSetStrummPattern = new VmCommand<string>(
                CmdSetStrummPattern_CanExecute,
                CmdSetStrummPattern_Execute);
        }

        private void CmdSetStrummPattern_Execute(string obj)
        {
            return;
        }

        private bool CmdSetStrummPattern_CanExecute(string arg)
        {
            return true;
        }

        public void SetTimmes(string[] times, int pos)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                for (var i = 0; i < times.Length; i++)
                {
                    if (i >= Times.Count)
                        Times.Add(new VmTime() { Text = VmTime.TranslateText(times[i])});
                }

                while (Times.Count > times.Length)
                    Times.RemoveAt(Times.Count - 1);

                for (var i = 0; i < Times.Count; i++)
                    Times[i].IsActive = i == pos + 1;
            }));
        }
    }
}
