using System;
using System.IO;
using Newtonsoft.Json;

public class AppSettings
{
    public string IpAddress { get; set; }
    public int Port { get; set; }
    public string KeyboardMethod { get; set; } // Klavye simülasyonu yöntemi
}

public static class SettingsManager
{
    private static readonly string SettingsPath = "settings.json";

    public static void SaveSettings(AppSettings settings)
    {
        string json = JsonConvert.SerializeObject(settings);
        File.WriteAllText(SettingsPath, json);
    }

    public static AppSettings LoadSettings()
    {
        if (File.Exists(SettingsPath))
        {
            string json = File.ReadAllText(SettingsPath);
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
        return new AppSettings { IpAddress = "127.0.0.1", Port = 12345, KeyboardMethod = "SendKeys" }; // Varsayılan ayarlar
    }
}