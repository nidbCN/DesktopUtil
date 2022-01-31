using DesktopUtil.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesktopUtil;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ClockModel _clockModel = new();

    private readonly DispatcherTimer _timer = new()
    {
        Interval = new TimeSpan(0, 0, 1),
        IsEnabled = true
    };

    public MainWindow()
    {
        InitializeComponent();

        DataContext = _clockModel;

        _timer.Tick += new EventHandler((s, e) => _clockModel.Update());

        _timer.Start();
    }
}
