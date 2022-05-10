using System.Collections.Generic;
using DesktopUtil.Core;
using DesktopUtil.Core.Models;

namespace DesktopUtil.Models;
#nullable disable
public class MainWindowContext
{
    public ClockModel Clock { get; set; }
    public IList<QuickFunction> Functions { get; set; }
}
#nullable restore