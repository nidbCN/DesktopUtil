using System.Text.Json;

namespace DesktopUtil.Core
{
    public class Options
    {
        private const string FILE_PATH = "DesktopUtil/AppSettings.json";

        public IList<QuickFunction> Functions { get; set; } = new List<QuickFunction>();

        public static Options Read()
        {
            var path = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               FILE_PATH);

            var optionsJson = File.ReadAllText(path);

            var options = JsonSerializer.Deserialize<Options>(optionsJson);

            return options ?? new Options();
        }

        public static bool TryRead(out Options? options)
        {
            options = null;

            var path = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               FILE_PATH);

            // Validate file path
            if (!File.Exists(path))
                return false;

            try
            {
                var optionsJson = File.ReadAllText(path);
                options = JsonSerializer.Deserialize<Options>(optionsJson);
            }
            catch 
            {
                return false;
            }

            return true;
        }
    }
}