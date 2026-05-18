using System.IO;
using GtaVModManager.Models;

namespace GtaVModManager.Services;

public class ModDeploymentService
{
    private readonly string _gtaPath;

    public ModDeploymentService(string gtaPath)
    {
        _gtaPath = gtaPath;
    }

    // =========================
    // ENABLE MOD (CREATE LINK)
    // =========================
    public void EnableMod(Mod mod)
    {
        var source = mod.FullPath;
        var target = Path.Combine(_gtaPath, mod.Name);

        if (Directory.Exists(target) || File.Exists(target))
            return;

        CreateSymbolicLink(target, source);
    }

    // =========================
    // DISABLE MOD (REMOVE LINK)
    // =========================
    public void DisableMod(Mod mod)
    {
        var target = Path.Combine(_gtaPath, mod.Name);

        if (Directory.Exists(target) || File.Exists(target))
        {
            Directory.Delete(target, true);
        }
    }

    // =========================
    // CLEAN GTA (REMOVE ALL LINKS)
    // =========================
    public void CleanGta(IEnumerable<Mod> mods)
    {
        foreach (var mod in mods)
        {
            DisableMod(mod);
        }
    }

    // =========================
    // SYMLINK CREATION (WINDOWS)
    // =========================
    private void CreateSymbolicLink(string linkPath, string targetPath)
    {
        var isDirectory = Directory.Exists(targetPath);

        var command = isDirectory
            ? $"cmd /c mklink /D \"{linkPath}\" \"{targetPath}\""
            : $"cmd /c mklink \"{linkPath}\" \"{targetPath}\"";

        var process = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = command.Replace("cmd /c ", "/c "),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        process.WaitForExit();
    }
}