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
            MobileCenter.Start("android=ed7fe19c-a387-48b8-b4d1-21aeb6fe15d0;ios=af9c5f8b-28fd-48ae-a523-566417f1a81b", typeof(Analytics), typeof(Crashes));

            this.AppVersion = string.Format("v{0}", CrossVersionTracking.Current.CurrentVersion);

            MainPage = new MainPage();
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
