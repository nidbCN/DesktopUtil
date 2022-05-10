using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using DesktopUtil.Core;
using DesktopUtil.Models;

namespace DesktopUtil;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly MainWindowContext _context = new()
    {
        Clock = new(),
    };

    private readonly DispatcherTimer _timer = new()
    {
        Interval = new(0, 0, 1),
        IsEnabled = true,
    };

    private readonly Options? _options = Options.Read();

    public MainWindow()
    {
        InitializeComponent();

        _context.Functions = _options?.Functions ?? Array.Empty<QuickFunction>();

        DataContext = _context;

        _timer.Tick += (_, _) => _context.Clock.Update();
        _timer.Start();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var function = btn?.DataContext as QuickFunction;
        
    }

    private async void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var textBlock = sender as TextBlock;
        var function = textBlock?.DataContext as QuickFunction;
        await function!.Execute();
    }
}
