using System;
using System.Windows.Controls;

namespace PersonalFinanceTracker.Views
{
    public partial class BudgetView : UserControl
    {
        public BudgetView()
        {
            try
            {
                InitializeComponent();
                System.Diagnostics.Debug.WriteLine("BudgetView initialized successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error initializing BudgetView: {ex}");
                throw; // Re-throw to see the error
            }
        }
    }
}