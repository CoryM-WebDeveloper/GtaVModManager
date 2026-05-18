using System.IO;
using System.Collections.Generic;
using System.Linq;
using GtaVModManager.Models;

namespace GtaVModManager.Services;

public class ModDiscoveryService
{
    private readonly string _modsPath;

    public ModDiscoveryService(string modsPath)
    {
        _modsPath = modsPath;
    }

    public List<Mod> GetMods()
    {
        if (!Directory.Exists(_modsPath))
            return new List<Mod>();

        var modDirectories = Directory.GetDirectories(_modsPath);

        return modDirectories.Select(dir => new Mod
        {
            Name = Path.GetFileName(dir),
            FullPath = dir,
            IsEnabled = true
        }).ToList();
    }
}