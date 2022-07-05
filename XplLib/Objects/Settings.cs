using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XplLib.Objects
{
    public class Settings
    {
        readonly string settingsFilePath = "C:\\Dev\\XplBackupManager\\XplSettings.cfg";
        List<(string Key, string Value)> settings = new List<(string, string)> ();

        public Settings()
        {
            string[] lines = System.IO.File.ReadAllLines(this.settingsFilePath);
            foreach (string line in lines)
            {
                (string Key, string Value) currentSetting;
                currentSetting.Key = line.Split("|")[0];
                currentSetting.Value = line.Split("|")[1];
                settings.Add(currentSetting);
            }
        }

        public string? get(string setting)
        {
            foreach(var item in settings)
                if(item.Key == setting)
                    return item.Value.Trim();
            return null;
        }

        public void set(string setting, string value)
        {
            for (int i = 0; i < settings.Count; i++)
                if (settings[i].Key == setting)
                    settings[i] = (setting.Trim(), value.Trim());
            writeSettingsFile();
        }

        private void writeSettingsFile()
        {
            string fileOutput = String.Empty;
            foreach (var item in settings)
                fileOutput += $"{item.Key}|{item.Value}\n";
            System.IO.File.WriteAllText(settingsFilePath, fileOutput);
        }
    }
}