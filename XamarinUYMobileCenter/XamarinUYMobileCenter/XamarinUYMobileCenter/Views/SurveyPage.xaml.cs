using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUYMobileCenter.ViewModels;

namespace XamarinUYMobileCenter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveyPage : ContentPage
    {
        public SurveyPage()
        {
            InitializeComponent();
            this.listView.SeparatorVisibility = SeparatorVisibility.None;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            SurveyViewModel viewModel = new SurveyViewModel();
            viewModel.DisplayAlert = this.DisplayAlert;
            viewModel.DisplayConfirm = this.DisplayAlert;
            this.BindingContext = viewModel;
            await viewModel.Refresh();
        }
    }
}