namespace FinanceApp.ViewModels;

public class IndexViewModel
{
    public List<ExpensesViewModel> Expenses { get; set; } = null!;

    public List<GroupExpensesViewModel> GroupExpenses { get; set; } = null!;
}

public class GroupExpensesViewModel
{
    public string Category { get; set; } = null!;
    public double TotalAmount { get; set; }
}
