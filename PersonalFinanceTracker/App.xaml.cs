using System;
using System.Windows;
using System.Windows.Threading;
using PersonalFinanceTracker.Helpers;

namespace PersonalFinanceTracker
{
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Log($"Unhandled exception: {e.Exception}");
            MessageBox.Show($"An error occurred: {e.Exception.Message}\n\nCheck the log file for more details.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}