using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinUYMobileCenter.Views;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Distribute;
using Microsoft.Azure.Mobile.Push;
using Plugin.VersionTracking;

namespace XamarinUYMobileCenter
{
    public partial class App : Application
    {
        public const string AppName = "Xamarin UY Mobile Center";

        public string AppVersion { get; set; }

        public App()
        {
            InitializeComponent();

            // Start Mobile Center Services
            //MobileCenter.Start("android=09863d5c-9cd4-4885-92bc-6f961430a77d;ios=6e302a72-b00f-48e4-9467-082ef931c193", typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Push));
            MobileCenter.Start("android=8ae13ecf-743f-4f99-9b01-5e0ebb901081;ios=c9bf414d-84a8-4bda-8c1e-d7e23175de76", typeof(Analytics), typeof(Crashes));

            this.AppVersion = string.Format("v{0}", CrossVersionTracking.Current.CurrentVersion);

            MainPage = new MainPage();

            //TODO: App launch error
            //int value = 2;
            //value = value / 0;
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
