    using HikmetRecebli.Data;
using HikmetRecebli.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HikmetRecebli.Controllers
{
    [Authorize(Roles = AppDbIntailazer.DefaultRole)]
    public class PortfoliosController : Controller
    {
        private readonly PortfolioDbContext _dbContext;
        public PortfoliosController(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var portfolios = await _dbContext.Portfolios.ToListAsync();
            return View(portfolios);
        }

        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Portfolios.AddAsync(portfolio);
                await _dbContext.SaveChangesAsync();
                TempData["Messange"] = portfolio.Name + " Added";
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var prostfolio = await _dbContext.Portfolios.FirstOrDefaultAsync(x=>x.Id == id);
            return View(prostfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(portfolio);
                await _dbContext.SaveChangesAsync();
                TempData["Messange"] = portfolio.Name + "Changed!";
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var portfolio = await _dbContext.Portfolios.FirstOrDefaultAsync(x => x.Id == id);
            if(portfolio == null) return NotFound();
            _dbContext.Portfolios.Remove(portfolio);
            await _dbContext.SaveChangesAsync();
            TempData["Messange"] = portfolio.Name + " Deleted!";
            return RedirectToAction("Index");
        }

    }
}
