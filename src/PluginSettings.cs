using System;
using System.Collections.ObjectModel;
using System.Linq;
using SimHub;

namespace CarChangePlugin
{
    public class PluginSettings
    {
        // List of saved cars
        public ObservableCollection<CarSetting> Cars { get; set; } = new ObservableCollection<CarSetting>();

        public uint? GetLock(String carName)
        {
            CarSetting foundCar = Cars.FirstOrDefault(c =>
                c.CarId.Equals(carName, StringComparison.OrdinalIgnoreCase)
            );

            if (foundCar != null)
            {
                Logging.Current.Info($"Found car: {foundCar.CarId}, Lock: {foundCar.WheelLock}");
                return foundCar.WheelLock;
            }
            else
                return null;
        }

        public static PluginSettings InitializeDefaults()
        {
            PluginSettings settings = new PluginSettings();
            settings.Cars.Add(new CarSetting("Alfa_Romeo_GTA", 1332));
            settings.Cars.Add(new CarSetting("Alpine_A110", 1152));
            settings.Cars.Add(new CarSetting("Citroen Xsara WRC", 540));
            settings.Cars.Add(new CarSetting("FIAT 131 Abarth", 1224));
            settings.Cars.Add(new CarSetting("FIAT Abarth 124", 990));
            settings.Cars.Add(new CarSetting("Hyundai i20N Rally2", 452));
            settings.Cars.Add(new CarSetting("Lancia 037", 900));
            settings.Cars.Add(new CarSetting("Lancia Delta Integrale Evo", 1008));
            settings.Cars.Add(new CarSetting("Lancia Stratos HF", 720));
            settings.Cars.Add(new CarSetting("Mini Cooper S 1275", 840));
            settings.Cars.Add(new CarSetting("Peugeot 208 Rally4", 540));

            return settings;
        }
    }
}
