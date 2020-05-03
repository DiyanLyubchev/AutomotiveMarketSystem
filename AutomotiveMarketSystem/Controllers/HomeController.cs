using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AutomotiveMarketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;
        private readonly IAdvertisementService advertisementService;

        public HomeController(ICarService carService, IAdvertisementService advertisementService)
        {
            this.carService = carService;
            this.advertisementService = advertisementService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var allAds = await this.advertisementService.GetAds();
            //return View(allAds);

            return View();
        }

    

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetModels(int brandId)
        {
            var brand = await this.carService.GetModelByBrandIdAsync(brandId);

            return new JsonResult(brand);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
