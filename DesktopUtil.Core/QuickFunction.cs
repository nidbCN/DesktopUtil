using System.Diagnostics;

namespace DesktopUtil.Core;

public class QuickFunction
{
#nullable disable
    public QuickFunction()
    {
    }
#nullable restore
    public QuickFunction(string displayName, string command, string? icon = null, string? workDir = null)
    {
        DisplayName = displayName;
        Command = command;

        if (icon != null)
            IconName = icon;
        if (workDir != null)
            WorkingDirectory = workDir;

    }

    public string DisplayName { get; set; }

    public string Command { get; set; }

    public string IconName { get; set; } = "mdi-launch";

    public string WorkingDirectory { get; set; }

    public async Task Execute()
    {
        var process = new Process()
        {
            StartInfo = new(Command)
            {
                //WorkingDirectory = WorkingDirectory,
            }
        };

        process.Start();
        await process.WaitForExitAsync();
    }
}