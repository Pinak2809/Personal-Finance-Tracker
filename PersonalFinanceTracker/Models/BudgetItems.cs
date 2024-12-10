namespace PersonalFinanceTracker.Models
{
    public class IncomeItem
    {
        public string Source { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }

    public class SavingsItem
    {
        public string Goal { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }

    public class InvestmentItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal ExpectedReturn { get; set; }
        public decimal Amount { get; set; }
    }

    public class DebtItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }

    public class BillItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsSubscription { get; set; }
    }

    public class OtherExpenseItem
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}