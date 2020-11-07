using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace DataAccessLibrary.Data
{
    public static class SettingsContext
    {
        private static Settings _settings { get; set; }

        public static void GetSettingsInformation()
        {

            var jsonFilePath = Directory.GetCurrentDirectory() + @"\settingsFile.json";
            var jsonData = File.ReadAllText(jsonFilePath);

            _settings = JsonConvert.DeserializeObject<Settings>(jsonData);
        }
        public static async Task<IEnumerable<string>> GetStatus()
        {
            
            var list = new List<string>();

            foreach (var status in _settings.Status)
            {
                list.Add(status);
            }
            return list;
        }

        public static int GetMaxItemsCount()
        {
            return _settings.MaxItemsCount;
        }
    }


    public  class Settings
    {
        public string[] Status { get; set; }
        public int MaxItemsCount { get; set; }
    }
}





