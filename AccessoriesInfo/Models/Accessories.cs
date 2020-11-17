using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessoriesInfo.Models
{
    public class Accessories : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _DeviceName;
        public string DeviceName { get => _DeviceName; set { _DeviceName = value; this.OnPropertyChanged(nameof(DeviceName)); } }
        string _ModelNumber;
        public string ModelNumber { get => _ModelNumber; set { _ModelNumber = value; this.OnPropertyChanged(nameof(ModelNumber)); } }
        string _Price;
        public string Price { get => _Price; set { _Price = value; this.OnPropertyChanged(nameof(Price)); } }
        string _Stutus;
        public string Stutus { get => _Stutus; set { _Stutus = value; this.OnPropertyChanged(nameof(Stutus)); } }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
