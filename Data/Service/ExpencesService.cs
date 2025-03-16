using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service;

public class ExpencesService : IExpencesService
{
    private readonly FinanceAppContext _context;
    public ExpencesService(FinanceAppContext context)
    {
        _context = context;
    }
    public async Task Add(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

    }

    public async Task<IEnumerable<Expense>> GetAll()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return expenses;

    }
}
