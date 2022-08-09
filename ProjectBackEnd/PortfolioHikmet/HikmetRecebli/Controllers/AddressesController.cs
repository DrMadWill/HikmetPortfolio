using HikmetRecebli.Data;
using HikmetRecebli.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HikmetRecebli.Controllers
{
    [Authorize(Roles = AppDbIntailazer.DefaultRole)]
    public class AddressesController : Controller
    {
        private readonly PortfolioDbContext _dbContext;
        public AddressesController(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.Addresses.FirstOrDefaultAsync();
            if (data == null) return NotFound();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Address address)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(address);
                await _dbContext.SaveChangesAsync();
            }
            TempData["Messange"] = "Address Cahneged !";
            return View(address);
        }
    }
}
