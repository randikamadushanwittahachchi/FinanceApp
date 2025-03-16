using FinanceApp.Models;

namespace FinanceApp.Data.Service;

public interface IExpencesService
{
    Task<IEnumerable<Expense>> GetAll();
    Task Add(Expense expense);
}
