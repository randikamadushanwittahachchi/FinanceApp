using FinanceApp.Data;
using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpencesService _expencesService;

        public ExpensesController(IExpencesService expencesService)
        {
            _expencesService = expencesService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expencesService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expencesService.Add(expense);
                return Redirect("Index");
            }
            return View(expense);
        }
    }
}
