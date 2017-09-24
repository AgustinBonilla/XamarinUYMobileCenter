using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinUYMobileCenter.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaiseAllPropertiesChanged()
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }
        
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                this.isLoading = value;
                this.RaisePropertyChanged();
            }
        }

        public delegate Task DisplayAlertDelegate(string title, string message, string cancel);

        public DisplayAlertDelegate DisplayAlert { get; set; }

        public delegate Task<bool> DisplayConfirmDelegate(string title, string message, string accept, string cancel);

        public DisplayConfirmDelegate DisplayConfirm { get; set; }
    }
}
