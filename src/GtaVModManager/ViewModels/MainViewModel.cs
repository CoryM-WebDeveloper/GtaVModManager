using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using GtaVModManager.Models;
using GtaVModManager.Services;

namespace GtaVModManager.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly SettingsService _settingsService;

    [ObservableProperty]
    private string statusText = "Initializing...";

    [ObservableProperty]
    private ObservableCollection<Mod> mods = new();

    public MainViewModel()
    {
        _settingsService = new SettingsService();

        LoadMods();
    }

    private void LoadMods()
    {
        var modService = new ModDiscoveryService("Mods");

        var discovered = modService.GetMods();

        Mods.Clear();

        foreach (var mod in discovered)
            Mods.Add(mod);

        StatusText = $"Discovered {Mods.Count} mods.";
    }
}