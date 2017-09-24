using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinUYMobileCenter.ViewModels
{
    public class CrashViewModel : BaseViewModel
    {
        public enum CrashOption
        {
            Option1, Option2, Option3
        }

        public ICommand Crash1Command { get; private set; }

        public ICommand Crash2Command { get; private set; }

        public ICommand Crash3Command { get; private set; }

        private string appVersion;
        public string AppVersion
        {
            get { return appVersion; }
            set
            {
                appVersion = value;
                this.RaisePropertyChanged();
            }
        }

        public CrashViewModel()
        {
            this.Crash1Command = new Command(async () => await this.OnCrashCommand(CrashOption.Option1));
            this.Crash2Command = new Command(async () => await this.OnCrashCommand(CrashOption.Option2));
            this.Crash3Command = new Command(async () => await this.OnCrashCommand(CrashOption.Option3));
        }

        public async Task Refresh()
        {
            this.IsLoading = true;
            this.AppVersion = ((App)App.Current).AppVersion;
            Analytics.TrackEvent("Crash");
            this.IsLoading = false;
        }

        public async Task OnCrashCommand(CrashOption crashOption)
        {
            switch (crashOption)
            {
                case CrashOption.Option1:
                    string text = null;
                    text.Trim();
                    break;
                case CrashOption.Option2:
                    int[] array = new int[2];
                    array[3] = 3;
                    break;
                case CrashOption.Option3:
                    CrashOption option = (CrashOption)Enum.Parse(typeof(CrashOption), "Option4");
                    break;
            }
        }
    }
}
