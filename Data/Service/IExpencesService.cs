using FinanceApp.Models;
using FinanceApp.ViewModels;

namespace FinanceApp.Data.Service;

public interface IExpencesService
{
    Task<IndexViewModel> GetAll();
    Task Add(ExpensesViewModel expense);
}
