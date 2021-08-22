using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_ComboBox
{
    public class GreetingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string hello;
        public string Hello 
        {
            get { return hello; }
            set
            {
                hello = value;
                NotifyPropertyChanged("Hello");
            }
        }

        public List<GreetingModel> countryList;
        public List<GreetingModel> CountryList 
        {
            get { return countryList; }
            set
            {
                countryList = value;
            }
        }

        private GreetingModel selectedCountry;
        public GreetingModel SelectedCountry 
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = value;
                NotifyPropertyChanged("SelectedCountry");
                Hello = SelectedCountry.greeting;
            }
        }

        public GreetingViewModel()
        {
            CountryList = new List<GreetingModel>
            {
                new GreetingModel {countryID = 1, countryName="US", greeting ="Hello"},
                new GreetingModel{countryID=2,countryName="VietNam", greeting="Xin chào"},
                new GreetingModel{countryID=3,countryName="Mexico", greeting ="Holla"}
            };
            SelectedCountry = CountryList[0]; 

        }
    }
}
