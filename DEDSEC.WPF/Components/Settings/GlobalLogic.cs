using System.IO;
using System.Reflection;

namespace DEDSEC.WPF.Components.Settings
{
    public class GlobalLogic
    {
        public const string UserSettingsFilename = "settings.xml";
        public string _DefaultSettingsPath =
            Assembly.GetEntryAssembly()?.Location + "\\Settings\\" + UserSettingsFilename;
        public string _UserSettingsPath =
            Assembly.GetEntryAssembly()?.Location + "\\Settings\\UserSettings\\" + UserSettingsFilename;
        public GlobalSettings GlobalSettings { get; private set; }

        public GlobalLogic(GlobalSettings globalSettings)
        {
            GlobalSettings = globalSettings;
            if (globalSettings != null)
            {
                if (File.Exists(_UserSettingsPath))
                    this.GlobalSettings = GlobalSettings.Read(_UserSettingsPath);
                else if (File.Exists(_DefaultSettingsPath))
                    this.GlobalSettings = GlobalSettings.Read(_DefaultSettingsPath);
                else
                {
                    GlobalSettings.Save(_UserSettingsPath);
                }
            }
        }

        public void SaveUserSettings()
        {
            GlobalSettings.Save(_UserSettingsPath);
        }
    }
}
