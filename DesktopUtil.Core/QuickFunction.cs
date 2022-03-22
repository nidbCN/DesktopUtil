using System.Diagnostics;

namespace DesktopUtil.Core
{
    public class QuickFunction
    {
        public QuickFunction(string displayName, string command, string? icon = null, string? workDir = null)
        {
            DisplayName = displayName;
            Command = command;

            if (icon != null)
                IconName = icon;
            if (workDir != null)
                WorkingDirectory = workDir;

        }

        public string DisplayName { get; }

        public string Command { get; }

        public string IconName { get; } = "mdi-launch";

        public string WorkingDirectory { get; } = "scripts";

        public static async void Execute(QuickFunction function)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo(function.Command)
                {
                    WorkingDirectory = function.WorkingDirectory,
                }
            };

            process.Start();
            await process.WaitForExitAsync();
        }
    }
}