using PersonalFinanceTracker.Commands;
using PersonalFinanceTracker.ViewModels.Base;
using System.Windows.Input;

namespace PersonalFinanceTracker.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isSidebarExpanded = true;
        private double _sidebarWidth = 250;
        private object? _currentView;

        public MainViewModel()
        {
            ToggleSidebarCommand = new RelayCommand(_ => ToggleSidebar());
            NavigateCommand = new RelayCommand(Navigate);
            
            // Set default view to Dashboard
            Navigate("Dashboard");
        }

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

        public ICommand ToggleSidebarCommand { get; }
        public ICommand NavigateCommand { get; }

        private void ToggleSidebar()
        {
            IsSidebarExpanded = !IsSidebarExpanded;
        }

        private void Navigate(object? parameter)
        {
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
            }
        }
    }
}