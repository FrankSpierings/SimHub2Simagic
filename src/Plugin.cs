using GameReaderCommon;
using SimHub.Plugins;
using System.Reflection;
using System.Threading.Tasks;
using SimHub;

namespace CarChangePlugin
{
    [PluginDescription("Changes steering settings when changing cars")]
    [PluginAuthor("Frank Spierings")]
    [PluginName("Car Change Plugin")]
    public class CarChangePlugin : IPlugin, IDataPlugin, IWPFSettings
    {
        public PluginManager PluginManager { get; set; }
        public PluginSettings Settings;

        private string _lastCarId = string.Empty;
        private readonly Simagic _simagic = new Simagic();

        public void Init(PluginManager pluginManager)
        {
            PluginManager = pluginManager;
            Settings = this.ReadCommonSettings<PluginSettings>(
                "GeneralSettings",
                () => PluginSettings.InitializeDefaults()
            );
            Logging.Current.Info("Car Change plugin initialized");
        }

        public void DataUpdate(PluginManager pluginManager, ref GameData data)
        {
            if (data == null || !data.GameRunning || data.NewData == null)
                return;

            string carId =
                GetStringProperty(data.NewData, "CarModel")
                ?? GetStringProperty(data.NewData, "CarName")
                ?? string.Empty;

            if (string.IsNullOrWhiteSpace(carId))
                return;

            if (carId != _lastCarId)
            {
                _lastCarId = carId;
                OnCarChanged(carId);
            }
        }

        public System.Windows.Controls.Control GetWPFSettingsControl(PluginManager pluginManager)
        {
            Logging.Current.Info("CarChange Settings Control");
            return new PluginSettingsControl(Settings);
        }

        private void OnCarChanged(string carId)
        {
            Logging.Current.Info($"Car changed to: {carId}");

            uint? steeringLock = Settings.GetLock(carId);
            if (steeringLock.HasValue && steeringLock.Value > 100 && steeringLock.Value < 4000)
            {
                Logging.Current.Info($"Applying softlock: {steeringLock.Value}");
                Task.Run(async () => await _simagic.UpdateSteeringLock(steeringLock.Value));
            }
        }

        public void End(PluginManager pluginManager)
        {
            Logging.Current.Info("Plugin shutdown");
            this.SaveCommonSettings("GeneralSettings", Settings);
        }

        // ---------------- Helpers ----------------

        private static string GetStringProperty(object obj, string propertyName)
        {
            PropertyInfo prop = obj.GetType().GetProperty(propertyName);
            return prop?.GetValue(obj)?.ToString();
        }
    }
}
