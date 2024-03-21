using System.ComponentModel;

namespace Bindings.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int _count;

        public string Name { get; set; }
        public double Price { get; set; }

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}