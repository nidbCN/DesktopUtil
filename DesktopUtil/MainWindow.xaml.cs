using DesktopUtil.Core.Models;
using System;
using System.Windows;
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
