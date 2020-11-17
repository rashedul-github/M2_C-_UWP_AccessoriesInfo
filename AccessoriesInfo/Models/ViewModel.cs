using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessoriesInfo.Models
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<Accessories> accessories;
        int index;
        bool isEditing = false;
        bool isAdding = false;
        public ViewModel()
        {
            accessories = new List<Accessories>()
            {
                new Accessories{DeviceName="Monitor",ModelNumber="EI-1522",Price="5000",Stutus="Available"},
                new Accessories{DeviceName="Processor",ModelNumber="Core-i8",Price="2000",Stutus="Up Comming"},
                new Accessories{DeviceName="Motherboard",ModelNumber="DDR-4",Price="3000",Stutus="Available"},
                new Accessories{DeviceName="RAM-4GB",ModelNumber="DDR-4",Price="6000",Stutus="Available"},
                new Accessories{DeviceName="Hard Disk-1TB",ModelNumber="BI-20",Price="2000",Stutus="Sold out"}
            };
            index = 0;
        }
        public async Task<List<Accessories>> GetAccessoriesAsync()
        {
            return await Task.FromResult<List<Accessories>>(this.accessories);
        }
        public Accessories Current
        {
            get => accessories[index];
        }
        public bool IsAddingOrEditing
        {
            get => isEditing || isAdding;
        }
        public bool IsBrowsing
        {
            get => !isAdding && !isEditing;
        }
        public void AddNew()
        {
            this.accessories.Add(new Accessories());
            this.index = this.accessories.Count - 1;
            this.isAdding = true;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(Current));
        }
        public void BeginEdit()
        {
            this.isEditing = true;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(IsBrowsing));
        }
        public void Save()
        {
            this.isAdding = false;
            this.isEditing = false;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(IsBrowsing));
        }
        public void Cancel()
        {
            if (this.isAdding)
            {
                this.accessories.RemoveAt(this.accessories.Count - 1);
                this.index = 0;
                this.OnPropertyChanged(nameof(Current));
            }
            this.isEditing = false;
            this.isAdding = false;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(IsBrowsing));
        }
        public void Next()
        {
            if (index < this.accessories.Count - 1)
            {
                index++;
                this.OnPropertyChanged(nameof(Current));
            }
        }
        public void Previous()
        {
            if (index > 0)
            {
                index--;
                this.OnPropertyChanged(nameof(Current));
            }
        }
        public void First()
        {

            index = 0;
            this.OnPropertyChanged(nameof(Current));

        }
        public void Last()
        {

            index = this.accessories.Count - 1;
            this.OnPropertyChanged(nameof(Current));

        }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
