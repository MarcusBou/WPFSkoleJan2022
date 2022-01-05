using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace HeltIFisk
{
    public class AnimalViewModel : INotifyPropertyChanged
    {
        private Animal currentAnimal;
        
        private ObservableCollection<Animal> animals = new ObservableCollection<Animal>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Animal> Animals { get { return this.animals; } set { this.animals = value; } }
        public Animal CurrentAnimal { get { return this.currentAnimal; } set { this.currentAnimal = value; OnPropertyChanged("CurrentAnimal"); } }
        public AnimalViewModel()
        {
            this.animals.Add(new Animal("Butterflyfish", "20 cm", "n/a"));
            this.animals.Add(new Animal("Tiger Shark", "3.25 to 4.25 m", "385 to 635 kg"));
            this.animals.Add(new Animal("Great White Shark", "4.6 m to 6 m", "2.268 kg"));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
