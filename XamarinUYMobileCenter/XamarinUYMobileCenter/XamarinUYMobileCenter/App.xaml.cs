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
            MobileCenter.Start("android=e0aa0f26-027d-4223-9276-a721f93b1efa;ios=ccced66e-90cb-4219-a01b-fd5d24b1761a", typeof(Analytics), typeof(Crashes));

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
