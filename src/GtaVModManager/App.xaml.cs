using System.Windows;
using GtaVModManager.ViewModels;

namespace GtaVModManager;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = new MainWindow
        {
            DataContext = new MainViewModel()
        };

        window.Show();
    }
}