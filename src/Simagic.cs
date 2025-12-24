using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarChangePlugin
{
    class Simagic
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly String _url = "http://127.0.0.1:56789/jsonrpc";

        public async Task UpdateSteeringLock(uint steeringLock)
        {
            SimHub.Logging.Current.Info($"Sending steering lock {steeringLock} to Simagic");
            try
            {
                string json = JsonConvert.SerializeObject(
                    new
                    {
                        id = 1,
                        jsonrpc = "2.0",
                        method = "set_config",
                        @params = new
                        {
                            items = new
                            {
                                @base = new
                                {
                                    wheel_angle_limit = steeringLock,
                                    max_wheel_angle = steeringLock,
                                },
                            },
                        },
                    }
                );

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_url, content);

                if (!response.IsSuccessStatusCode)
                {
                    SimHub.Logging.Current.Warn(
                        $"HTTP {(int)response.StatusCode} {response.ReasonPhrase}"
                    );
                }
            }
            catch (Exception ex)
            {
                SimHub.Logging.Current.Error("Failed to send JSON payload", ex);
            }
        }
    }
}
