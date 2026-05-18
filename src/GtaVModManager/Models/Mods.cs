namespace GtaVModManager.Models;

public class Mod
{
    public string Name { get; set; } = string.Empty;
    public string FullPath { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
}