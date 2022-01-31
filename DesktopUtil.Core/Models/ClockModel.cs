namespace DesktopUtil.Core.Models;

#nullable disable
public class ClockModel
{
    public ClockModel()
        => Update();


    public void Update()
        => Update(DateTime.Now);

    public void Update(DateTime dateTime)
    {
        Time = dateTime.ToLongTimeString();
        Date = dateTime.ToLongDateString();
    }

    public string Time { get; set; }
    public string Date { get; set; }
}
#nullable restore