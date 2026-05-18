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
    private Settings settings = new();

    public MainViewModel()
    {
        _settingsService = new SettingsService();

        Settings = _settingsService.Load();

        StatusText = $"Settings loaded from: {_settingsService.SettingsPath}";
    }

    public void SaveSettings()
    {
        _settingsService.Save(Settings);
        StatusText = "Settings saved.";
    }
}