using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinUYMobileCenter.ViewModels
{
    public class SurveyItemViewModel : BaseViewModel
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.RaisePropertyChanged();
            }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
