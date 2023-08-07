using System;
using System.Windows;

namespace WpfUiAutomationWithGu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e is { Args: { Length: 1 } args })
            {
                var window = args[0];
                this.StartupUri = new Uri($"{window}.xaml", UriKind.Relative);
            }

            base.OnStartup(e);
        }
    }
}
