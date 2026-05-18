using System.IO;
using System.Text.Json;
using GtaVModManager.Models;

namespace GtaVModManager.Services;

public class SettingsService
{
    private readonly string _settingsPath;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    public SettingsService()
    {
        // Project root = executable folder's parent directories.
        // During development, the executable runs from:
        // src/GtaVModManager/bin/Debug/net10.0-windows/
        // We walk upward to the repository root.
        var baseDir = AppContext.BaseDirectory;
        var projectRoot = Directory
            .GetParent(baseDir)!    // net10.0-windows
            .Parent!                // Debug
            .Parent!                // bin
            .Parent!                // GtaVModManager
            .Parent!                // src
            .Parent!                // repository root
            .FullName;

        _settingsPath = Path.Combine(projectRoot, "Settings.json");
    }

    public string SettingsPath => _settingsPath;

    public Settings Load()
    {
        if (!File.Exists(_settingsPath))
        {
            var defaultSettings = new Settings();
            Save(defaultSettings);
            return defaultSettings;
        }

        var json = File.ReadAllText(_settingsPath);

        var settings = JsonSerializer.Deserialize<Settings>(json, _jsonOptions);

        return settings ?? new Settings();
    }

    public void Save(Settings settings)
    {
        var json = JsonSerializer.Serialize(settings, _jsonOptions);
        File.WriteAllText(_settingsPath, json);
    }
}