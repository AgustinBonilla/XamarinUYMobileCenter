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
    public partial class FormPage : ContentPage
    {
        public FormPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            FormViewModel viewModel = new FormViewModel();
            viewModel.DisplayAlert = this.DisplayAlert;
            this.BindingContext = viewModel;
            await viewModel.Refresh();
        }
    }
}