using System.Windows;
using PersonalFinanceTracker.ViewModels;
using PersonalFinanceTracker.Views;

namespace PersonalFinanceTracker
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            
            mainWindow.Show();
        }
    }
}