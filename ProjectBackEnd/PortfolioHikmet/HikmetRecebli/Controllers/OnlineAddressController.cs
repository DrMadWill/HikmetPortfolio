using HikmetRecebli.Data;
using HikmetRecebli.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HikmetRecebli.Controllers
{
    [Authorize(Roles = AppDbIntailazer.DefaultRole)]
    public class OnlineAddressController : Controller
    {
        private readonly PortfolioDbContext _dbContext;
        public OnlineAddressController(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var onlAdres = await _dbContext.OnlineAddresses.ToListAsync();
            return View(onlAdres);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OnlineAddress onlineAddress)
        {
            if (ModelState.IsValid)
            {
                onlineAddress.AddressId = (await _dbContext.Addresses.FirstOrDefaultAsync()).Id;
                await _dbContext.OnlineAddresses.AddAsync(onlineAddress);
                await _dbContext.SaveChangesAsync();
                TempData["Messange"] = onlineAddress.Name + " Added";
                return RedirectToAction("Index");
            }
            return View(onlineAddress);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var prostfolio = await _dbContext.OnlineAddresses.FirstOrDefaultAsync(x => x.Id == id);
            return View(prostfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OnlineAddress onlineAddress)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(onlineAddress);
                await _dbContext.SaveChangesAsync();
                TempData["Messange"] = onlineAddress.Name + "Changed!";
                return RedirectToAction("Index");
            }
            return View(onlineAddress);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var onlieadres = await _dbContext.OnlineAddresses.FirstOrDefaultAsync(x => x.Id == id);
            if (onlieadres == null) return NotFound();
            _dbContext.OnlineAddresses.Remove(onlieadres);
            await _dbContext.SaveChangesAsync();
            TempData["Messange"] = onlieadres.Name + " Deleted!";
            return RedirectToAction("Index");
        }
    }
}
