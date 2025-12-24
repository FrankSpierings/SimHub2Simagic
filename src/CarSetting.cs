using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarChangePlugin
{
    public class CarSetting : INotifyPropertyChanged
    {
        private string _carId = string.Empty;
        private uint _wheelLock = 540;

        public CarSetting(string carId = "", uint wheelLock = 540)
        {
            _carId = carId;
            _wheelLock = wheelLock;
        }

        public string CarId
        {
            get => _carId;
            set
            {
                if (_carId != value)
                {
                    _carId = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint WheelLock
        {
            get => _wheelLock;
            set
            {
                if (_wheelLock != value)
                {
                    _wheelLock = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}