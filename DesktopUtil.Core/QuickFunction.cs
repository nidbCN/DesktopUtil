namespace DesktopUtil.Core
{
    public class QuickFunction
    {
        public QuickFunction(string displayName, string command, string icon)
        {
            DisplayName = displayName;
            Command = command;
            IconName = icon;
        }

        public string DisplayName { get; set; }
        public string Command { get; set; }
        public string IconName { get; set; }
    }
}
