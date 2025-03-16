using FinanceApp.Models;
using FinanceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service;

public class ExpencesService : IExpencesService
{
    private readonly FinanceAppContext _context;
    public ExpencesService(FinanceAppContext context)
    {
        _context = context;
    }
    public async Task Add(ExpensesViewModel expense)
    {
        var model = new Expense
        {
            Amount = expense.Amount,
            Description = expense.Description,
            Date = expense.Date
        };
        _context.Expenses.Add(model);
        await _context.SaveChangesAsync();

    }

    public async Task<IndexViewModel> GetAll()
    {
        var expenses = await _context.Expenses
            .Select(e=>new ExpensesViewModel
            {
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date
            })
            .ToListAsync();

        var groupexpenses = await _context.Expenses.GroupBy(e => e.Category).Select(e => new GroupExpensesViewModel
        {
            Category = e.Key,
            TotalAmount = e.Sum(x => x.Amount)
        }).ToListAsync();

        var index = new IndexViewModel
        {
            Expenses = expenses,
            GroupExpenses = groupexpenses
        };
        return index;

    }
}
