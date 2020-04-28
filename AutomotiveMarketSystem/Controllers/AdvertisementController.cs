using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
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

        public async Task<IActionResult> GetAllAds()
        {
            var allAds = await this.advertisementService.GetAds();
            return View(allAds);
        }
    }
}