using System;
using System.Windows;
using PersonalFinanceTracker.Helpers;
using PersonalFinanceTracker.ViewModels;

namespace PersonalFinanceTracker.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                Logger.Log("Initializing MainWindow");
                InitializeComponent();
                DataContext = new MainViewModel();
                Logger.Log("MainWindow initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error initializing MainWindow: {ex}");
                MessageBox.Show($"Error initializing application: {ex.Message}",
                    "Initialization Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}