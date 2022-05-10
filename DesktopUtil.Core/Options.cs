using System.Text.Json;

namespace DesktopUtil.Core
{
    public class Options
    {
        private const string FilePath = "DesktopUtil/AppSettings.json";

        public IList<QuickFunction> Functions { get; set; } = new List<QuickFunction>();

        public static Options? Read()
        {
            var path = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               FilePath);

            var optionsJson = File.ReadAllText(path);

            return JsonSerializer.Deserialize<Options>(optionsJson);
        }

        public static bool TryRead(out Options? options)
        {
            options = null;

            var path = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               FilePath);

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

        public static void Save(Options options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                FilePath);
            var optionsJson = JsonSerializer.Serialize(options);
            File.WriteAllText(path, optionsJson);
        }
    }
}