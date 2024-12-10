using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Commands;
using PersonalFinanceTracker.ViewModels.Base;
using PersonalFinanceTracker.Helpers;
using System.Windows;

namespace PersonalFinanceTracker.ViewModels
{
    public class BudgetViewModel : ViewModelBase
    {
        private int _selectedYear;
        private int _selectedMonth;
        private readonly ObservableCollection<IncomeItem> _incomeItems;
        private readonly ObservableCollection<SavingsItem> _savingsItems;
        private readonly ObservableCollection<InvestmentItem> _investmentItems;
        private readonly ObservableCollection<DebtItem> _debtItems;
        private readonly ObservableCollection<BillItem> _billItems;
        private readonly ObservableCollection<OtherExpenseItem> _otherExpenses;
        private decimal _totalIncome;
        private decimal _totalSavings;
        private decimal _totalInvestments;
        private decimal _totalDebt;
        private decimal _totalBills;
        private decimal _totalOtherExpenses;
        private decimal _cashLeftover;

        // Initialize ICommands in the declaration
        public ICommand AddIncomeCommand { get; }
        public ICommand AddSavingsCommand { get; }
        public ICommand AddInvestmentCommand { get; }
        public ICommand AddDebtCommand { get; }
        public ICommand AddBillCommand { get; }
        public ICommand AddOtherExpenseCommand { get; }

        public BudgetViewModel()
        {
            try
            {
                Logger.Log("Initializing BudgetViewModel");

                // Initialize collections in the constructor
                _incomeItems = new ObservableCollection<IncomeItem>();
                _savingsItems = new ObservableCollection<SavingsItem>();
                _investmentItems = new ObservableCollection<InvestmentItem>();
                _debtItems = new ObservableCollection<DebtItem>();
                _billItems = new ObservableCollection<BillItem>();
                _otherExpenses = new ObservableCollection<OtherExpenseItem>();

                // Initialize commands
                AddIncomeCommand = new RelayCommand(_ => AddIncome());
                AddSavingsCommand = new RelayCommand(_ => AddSavings());
                AddInvestmentCommand = new RelayCommand(_ => AddInvestment());
                AddDebtCommand = new RelayCommand(_ => AddDebt());
                AddBillCommand = new RelayCommand(_ => AddBill());
                AddOtherExpenseCommand = new RelayCommand(_ => AddOtherExpense());

                // Set current date
                _selectedYear = DateTime.Now.Year;
                _selectedMonth = DateTime.Now.Month;

                // Setup collection change handlers
                SetupCollectionChangeHandlers();

                // Add sample data
                AddSampleData();

                Logger.Log("BudgetViewModel initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error in BudgetViewModel constructor: {ex}");
                MessageBox.Show($"Error initializing budget view: {ex.Message}", 
                    "Initialization Error", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }
        }

        // Properties
        public decimal TotalIncome
        {
            get => _totalIncome;
            private set => SetProperty(ref _totalIncome, value);
        }

        public decimal TotalSavings
        {
            get => _totalSavings;
            private set => SetProperty(ref _totalSavings, value);
        }

        public decimal TotalInvestments
        {
            get => _totalInvestments;
            private set => SetProperty(ref _totalInvestments, value);
        }

        public decimal TotalDebt
        {
            get => _totalDebt;
            private set => SetProperty(ref _totalDebt, value);
        }

        public decimal TotalBills
        {
            get => _totalBills;
            private set => SetProperty(ref _totalBills, value);
        }

        public decimal TotalOtherExpenses
        {
            get => _totalOtherExpenses;
            private set => SetProperty(ref _totalOtherExpenses, value);
        }

        public decimal TotalExpenses => TotalSavings + TotalInvestments + TotalDebt + TotalBills + TotalOtherExpenses;

        public decimal CashLeftover
        {
            get => _cashLeftover;
            private set => SetProperty(ref _cashLeftover, value);
        }

        public int SelectedYear
        {
            get => _selectedYear;
            set => SetProperty(ref _selectedYear, value);
        }

        public int SelectedMonth
        {
            get => _selectedMonth;
            set => SetProperty(ref _selectedMonth, value);
        }

        // Collection Properties
        public ObservableCollection<IncomeItem> IncomeItems => _incomeItems;
        public ObservableCollection<SavingsItem> SavingsItems => _savingsItems;
        public ObservableCollection<InvestmentItem> InvestmentItems => _investmentItems;
        public ObservableCollection<DebtItem> DebtItems => _debtItems;
        public ObservableCollection<BillItem> BillItems => _billItems;
        public ObservableCollection<OtherExpenseItem> OtherExpenses => _otherExpenses;

        // Private methods
        private void SetupCollectionChangeHandlers()
        {
            try
            {
                IncomeItems.CollectionChanged += (s, e) => UpdateTotals();
                SavingsItems.CollectionChanged += (s, e) => UpdateTotals();
                InvestmentItems.CollectionChanged += (s, e) => UpdateTotals();
                DebtItems.CollectionChanged += (s, e) => UpdateTotals();
                BillItems.CollectionChanged += (s, e) => UpdateTotals();
                OtherExpenses.CollectionChanged += (s, e) => UpdateTotals();
            }
            catch (Exception ex)
            {
                Logger.Log($"Error setting up collection handlers: {ex}");
            }
        }

        private void UpdateTotals()
        {
            try
            {
                TotalIncome = IncomeItems.Sum(i => i.Amount);
                TotalSavings = SavingsItems.Sum(s => s.Amount);
                TotalInvestments = InvestmentItems.Sum(i => i.Amount);
                TotalDebt = DebtItems.Sum(d => d.Amount);
                TotalBills = BillItems.Sum(b => b.Amount);
                TotalOtherExpenses = OtherExpenses.Sum(o => o.Amount);
                CashLeftover = TotalIncome - TotalExpenses;

                OnPropertyChanged(nameof(TotalExpenses));
            }
            catch (Exception ex)
            {
                Logger.Log($"Error updating totals: {ex}");
            }
        }

        private void AddIncome()
        {
            try
            {
                IncomeItems.Add(new IncomeItem());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding income: {ex}");
            }
        }

        private void AddSavings()
        {
            try
            {
                SavingsItems.Add(new SavingsItem());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding savings: {ex}");
            }
        }

        private void AddInvestment()
        {
            try
            {
                InvestmentItems.Add(new InvestmentItem());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding investment: {ex}");
            }
        }

        private void AddDebt()
        {
            try
            {
                DebtItems.Add(new DebtItem());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding debt: {ex}");
            }
        }

        private void AddBill()
        {
            try
            {
                BillItems.Add(new BillItem());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding bill: {ex}");
            }
        }

        private void AddOtherExpense()
        {
            try
            {
                OtherExpenses.Add(new OtherExpenseItem());
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding other expense: {ex}");
            }
        }

        private void AddSampleData()
        {
            try
            {
                IncomeItems.Add(new IncomeItem { Source = "Salary", Amount = 5000 });
                SavingsItems.Add(new SavingsItem { Goal = "Emergency Fund", Amount = 500 });
                InvestmentItems.Add(new InvestmentItem 
                { 
                    Name = "Stock Market Index Fund", 
                    ExpectedReturn = 7, 
                    Amount = 400 
                });
                DebtItems.Add(new DebtItem { Name = "Student Loan", Amount = 300 });
                BillItems.Add(new BillItem 
                { 
                    Name = "Netflix Subscription", 
                    Amount = 15, 
                    IsSubscription = true 
                });
            }
            catch (Exception ex)
            {
                Logger.Log($"Error adding sample data: {ex}");
            }
        }
    }
}