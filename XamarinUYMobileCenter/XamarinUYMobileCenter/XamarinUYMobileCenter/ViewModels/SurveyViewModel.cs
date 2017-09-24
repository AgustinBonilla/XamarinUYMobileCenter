using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUYMobileCenter.Helpers;

namespace XamarinUYMobileCenter.ViewModels
{
    public class SurveyViewModel : BaseViewModel
    {
        public ICommand SendCommand { get; private set; }

        private ObservableCollection<SurveyItemViewModel> listItems;
        public ObservableCollection<SurveyItemViewModel> ListItems
        {
            get { return this.listItems; }
            set
            {
                this.listItems = value;
                this.RaisePropertyChanged();
            }
        }

        private SurveyItemViewModel selectedListItem;
        public SurveyItemViewModel SelectedListItem
        {
            get { return this.selectedListItem; }
            set
            {
                this.selectedListItem = null;
                this.RaisePropertyChanged();
            }
        }

        private DateTime startTime;

        public SurveyViewModel()
        {
            this.SendCommand = new Command(async () => await this.OnSendCommand());
        }

        public async Task Refresh()
        {
            this.IsLoading = true;
            Analytics.TrackEvent("Survey");
            List<SurveyItemViewModel> list = new List<SurveyItemViewModel>
            {
                new SurveyItemViewModel { Text = "Xamarin.Forms", Selected = false },
                new SurveyItemViewModel { Text = "Prism", Selected = false },
                new SurveyItemViewModel { Text = "MvvmCross", Selected = false },
                new SurveyItemViewModel { Text = "MobileCenter", Selected = false },
                new SurveyItemViewModel { Text = "Push notifications", Selected = false },
                new SurveyItemViewModel { Text = "Xamarin.UITest", Selected = false },
                new SurveyItemViewModel { Text = "Xamarin + Cognitive Services", Selected = false },
                new SurveyItemViewModel { Text = "Game Development with Xamarin", Selected = false },
            };
            this.ListItems = new ObservableCollection<SurveyItemViewModel>(list);
            this.startTime = DateTime.Now;
            this.IsLoading = false;
        }

        public async Task OnSendCommand()
        {
            bool itemSelected = false;
            foreach (SurveyItemViewModel item in this.ListItems)
            {
                if (item.Selected)
                {
                    itemSelected = true;
                    break;
                }
            }

            if (Settings.SurveyCompleted)
            {
                await this.DisplayAlert("Survey page", "You have already completed the survey.", "OK");
            }
            else if (!itemSelected)
            {
                await this.DisplayAlert("Survey page", "You must select at least one option.", "OK");
            }
            else if (await this.DisplayConfirm("Survey page", "You are sure to send the survey?", "YES", "NO"))
            {
                TimeSpan timespan = (DateTime.Now - this.startTime);
                Dictionary<string, string> timeProperties = new Dictionary<string, string>();
                timeProperties.Add("Seconds", Convert.ToInt32(timespan.TotalSeconds).ToString());
                Analytics.TrackEvent("Survey response delay time", timeProperties);

                Dictionary<string, string> responseProperties = new Dictionary<string, string>();
                foreach (SurveyItemViewModel item in this.ListItems)
                {
                    if (item.Selected)
                    {
                        responseProperties.Clear();
                        responseProperties.Add("Option", item.Text);
                        Analytics.TrackEvent("Survey response", responseProperties);
                    }
                }

                Settings.SurveyCompleted = true;
                await this.DisplayAlert("Survey page", "The survey has been sent.", "OK");
            }
        }
    }
}
