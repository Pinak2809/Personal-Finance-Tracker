using System;
using PersonalFinanceTracker.Commands;
using PersonalFinanceTracker.ViewModels.Base;
using PersonalFinanceTracker.Helpers;
using System.Windows.Input;
using System.Windows;

namespace PersonalFinanceTracker.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isSidebarExpanded = true;
        private double _sidebarWidth = 250;
        private object? _currentView;

        // Initialize ICommands in the declaration
        public ICommand ToggleSidebarCommand { get; }
        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            try
            {
                Logger.Log("Initializing MainViewModel");
                
                // Initialize commands
                ToggleSidebarCommand = new RelayCommand(_ => ToggleSidebar());
                NavigateCommand = new RelayCommand(Navigate);

                // Set default view
                Navigate("Dashboard");

                Logger.Log("MainViewModel initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error in MainViewModel constructor: {ex}");
                MessageBox.Show($"Error initializing main view: {ex.Message}", 
                    "Initialization Error", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        // Properties
        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set
            {
                if (SetProperty(ref _isSidebarExpanded, value))
                {
                    SidebarWidth = value ? 250 : 50;
                }
            }
        }

        public double SidebarWidth
        {
            get => _sidebarWidth;
            set => SetProperty(ref _sidebarWidth, value);
        }

        public object? CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        // Private methods
        private void ToggleSidebar()
        {
            try
            {
                Logger.Log($"Toggling sidebar. Current state: {IsSidebarExpanded}");
                IsSidebarExpanded = !IsSidebarExpanded;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error toggling sidebar: {ex}");
            }
        }

        private void Navigate(object? parameter)
        {
            try
            {
                Logger.Log($"Navigating to: {parameter}");

                switch (parameter?.ToString())
                {
                    case "Dashboard":
                        CurrentView = new DashboardViewModel();
                        break;
                    case "Budget":
                        CurrentView = new BudgetViewModel();
                        break;
                    case "Goals":
                        CurrentView = new GoalsViewModel();
                        break;
                    case "Assets":
                        CurrentView = new AssetsViewModel();
                        break;
                    default:
                        Logger.Log($"Unknown navigation parameter: {parameter}");
                        return;
                }

                Logger.Log($"Successfully navigated to {parameter}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error during navigation: {ex}");
                MessageBox.Show($"Error navigating to {parameter}: {ex.Message}", 
                    "Navigation Error", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }
    }
}