using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomotiveMarketSystem.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            this.advertisementService = advertisementService;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAdvertisement(int newCarId)
        {
            if (newCarId <= 0)
            {
                throw new ArgumentException("Id is not valid!");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new AdvertisementDto { CarId = newCarId, UserId = userId };
            var allAds = await this.advertisementService.AddAdvertisement(dto);
            return RedirectToAction("Index", "Home" );
        }
    }
}