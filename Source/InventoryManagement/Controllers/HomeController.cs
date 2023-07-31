using InventoryManagement.Data;
using InventoryManagement.Data.Models;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryManagementContext _inventoryManagementContext;

        public HomeController(ILogger<HomeController> logger, InventoryManagementContext inventoryManagementContext)
        {
            _logger = logger;
            _inventoryManagementContext = inventoryManagementContext;
        }

        public IActionResult Index()
        {
            List<Item> items = GetInventory();

            return View(items);
        }

        private List<Item> GetInventory()
        {
            return _inventoryManagementContext.Items.ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}