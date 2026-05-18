namespace GtaVModManager.Models;

public class Settings
{
    public string GamePath { get; set; } = string.Empty;

    public string LaunchExecutable { get; set; } = string.Empty;

    public string ActiveProfile { get; set; } = "Default";

    public string ModsDirectory { get; set; } = "Mods";

    public string ProfilesDirectory { get; set; } = "Profiles";

    public string CacheDirectory { get; set; } = "Cache";

    public string LogsDirectory { get; set; } = "Logs";
}