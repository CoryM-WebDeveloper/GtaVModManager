using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GtaVModManager.Models;
using GtaVModManager.Services;

namespace GtaVModManager.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly SettingsService _settingsService;
    private readonly ModDeploymentService _deploymentService;

    [ObservableProperty]
    private string statusText = "Initializing...";

    [ObservableProperty]
    private Settings settings = new();

    [ObservableProperty]
    private ObservableCollection<Mod> mods = new();

    public MainViewModel()
    {
        // Load application settings
        _settingsService = new SettingsService();
        Settings = _settingsService.Load();

        // Create deployment service using GTA V path from settings
        _deploymentService = new ModDeploymentService(Settings.GtaVPath);

        // Discover mods
        LoadMods();
    }

    public void SaveSettings()
    {
        _settingsService.Save(Settings);
        StatusText = "Settings saved.";
    }

    private void LoadMods()
    {
        // Discover mods from the configured Mods directory
        var modService = new ModDiscoveryService(Settings.ModsDirectory);

        var discovered = modService.GetMods();

        // Update existing ObservableCollection
        Mods.Clear();

        foreach (var mod in discovered)
        {
            Mods.Add(mod);
        }

        StatusText = $"Discovered {Mods.Count} mods.";
    }

    [RelayCommand]
    private void Enable(Mod mod)
    {
        _deploymentService.EnableMod(mod);
        StatusText = $"Enabled {mod.Name}";
    }

    [RelayCommand]
    private void Disable(Mod mod)
    {
        _deploymentService.DisableMod(mod);
        StatusText = $"Disabled {mod.Name}";
    }
}