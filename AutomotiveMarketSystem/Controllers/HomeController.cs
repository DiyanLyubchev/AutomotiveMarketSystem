using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;

namespace AutomotiveMarketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var dto = new CarDto
            {
                AdvertisementId = 1,
                CarModel = "Polo",
                Door = 3,
                Engine = 1000,
                EngineTypeStatusId = 1,
                Make = "VW",
                Price = 22.50m,
                ProductionYear = DateTime.Now,
            };
            this.carService.AddCar(dto);

            //User.FindFirstValue(ClaimTypes.NameIdentifier)


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
