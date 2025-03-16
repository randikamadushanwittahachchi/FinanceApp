using FinanceApp.Data;
using FinanceApp.Data.Service;
using FinanceApp.Models;
using FinanceApp.ViewModels;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var index = await _expencesService.GetAll();
            return View(index);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpensesViewModel expense)
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
