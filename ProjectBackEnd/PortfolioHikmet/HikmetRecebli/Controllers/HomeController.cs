using HikmetRecebli.Data;
using HikmetRecebli.Models;
using HikmetRecebli.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HikmetRecebli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortfolioDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, PortfolioDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM indexVM = new IndexVM
            {
                Portfolios = await _dbContext.Portfolios.ToListAsync(),
                Addresses = await _dbContext.Addresses
                .Include(x => x.OnlineAddresses)
                .ToListAsync()
            };  
            return View(indexVM);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Messenge", new MessengeVM { Mesange = "Opps Something Wrong" ,PageTitle = "Error" });
        }
    }
}
