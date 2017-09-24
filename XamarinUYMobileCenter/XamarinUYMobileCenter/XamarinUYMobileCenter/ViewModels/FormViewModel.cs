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
    public class FormViewModel : BaseViewModel
    {
        public ICommand SendCommand { get; private set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.RaisePropertyChanged();
            }
        }

        private string commentary;
        public string Commentary
        {
            get { return commentary; }
            set
            {
                commentary = value;
                this.RaisePropertyChanged();
            }
        }
        
        public FormViewModel()
        {
            this.SendCommand = new Command(async () => await this.OnSendCommand());
        }

        public async Task Refresh()
        {
            this.IsLoading = true;
            Analytics.TrackEvent("Form");
            this.Name = string.Empty;
            this.Commentary = string.Empty;
            this.IsLoading = false;
        }

        public async Task OnSendCommand()
        {
            if (string.IsNullOrEmpty(this.Commentary) && string.IsNullOrEmpty(this.Name))
            {
                await this.DisplayAlert("Form page", "You must enter at least one data.", "OK");
            }
            else
            {
                Dictionary<string, string> formResponse = new Dictionary<string, string>();
                formResponse.Add("Commentary", string.Format("{0} - {1}", this.Name, this.Commentary));
                Analytics.TrackEvent("Form response", formResponse);
                await this.DisplayAlert("Send page", "The information has been sent", "OK");
                this.Name = string.Empty;
                this.Commentary = string.Empty;
            }
        }
    }
}
