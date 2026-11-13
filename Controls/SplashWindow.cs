using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KillerPDF;

namespace KillerPDF.Controls
{
    /// <summary>
    /// Simple startup splash window showing the KillerPDF name and version while
    /// App.OnStartup boots the main window. Kept intentionally minimal - no XAML,
    /// no theme dependencies, so it can appear before the theme system is ready.
    /// </summary>
    internal sealed class SplashWindow : Window
    {
        public SplashWindow()
        {
            Width = 460;
            Height = 260;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.NoResize;
            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Color.FromRgb(0x1c, 0x1c, 0x1c));
            ShowInTaskbar = false;
            Topmost = true;

            var root = new Grid
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1c, 0x1c, 0x1c))
            };
            root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // App icon
            var icon = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/kp-icon.png")),
                Width = 64,
                Height = 64,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 24, 0, 12)
            };
            Grid.SetRow(icon, 0);
            root.Children.Add(icon);

            // Name
            var name = new TextBlock
            {
                Text = "KillerPDF",
                Foreground = Brushes.White,
                FontSize = 32,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(name, 1);
            root.Children.Add(name);

            // Version + loading line
            var version = new TextBlock
            {
                Text = $"v{AppVersion.Display}   ·   Carregando…",
                Foreground = new SolidColorBrush(Color.FromRgb(0xa3, 0xa3, 0xa3)),
                FontSize = 12,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 24)
            };
            Grid.SetRow(version, 2);
            root.Children.Add(version);

            Content = root;
        }
    }
}
