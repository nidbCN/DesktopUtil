using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopUtil.Core.Models;

#nullable disable
public class ClockModel : INotifyPropertyChanged
{
    public ClockModel()
        => Update();

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void Update()
        => Update(DateTime.Now);

    public void Update(DateTime dateTime)
    {
        Time = dateTime.ToString("HH:mm:ss");
        Date = dateTime.ToLongDateString();
    }

    private string _time;
    public string Time
    {
        get => _time;
        private set
        {
            _time = value;
            NotifyPropertyChanged(nameof(Time));
        }
    }

    private string _date;
    public string Date
    {
        get => _date;
        private set
        {
            _date = value;
            NotifyPropertyChanged(nameof(Date));
        }
    }
}
#nullable restore