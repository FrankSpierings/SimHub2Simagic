using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;

namespace CarChangePlugin
{
    public partial class PluginSettingsControl : UserControl
    {
        private PluginSettings _settings;

        public PluginSettingsControl(PluginSettings settings)
        {
            InitializeComponent();
            _settings = settings;
            DataContext = settings;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            _settings.Cars.Add(new CarSetting());
        }

        private void RemoveCar_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is CarSetting car)
            {
                _settings.Cars.Remove(car);
            }
        }
    }
}
