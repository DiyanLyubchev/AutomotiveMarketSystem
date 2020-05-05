using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomotiveMarketSystem.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementService advertisementService;
        private readonly IMapper mapper;

        public AdvertisementController(IAdvertisementService advertisementService, IMapper mapper)
        {
            this.advertisementService = advertisementService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreateAdvertisement(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id is not valid!");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = new AdvertisementDto { CarId = id, UserId = userId };
            await this.advertisementService.AddAdvertisement(dto);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var adVMDto = this.mapper.Map<AdvertisementViewModelDto>(advertisementViewModel);
                        
            await this.advertisementService.DeleteAd(id);
            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await this.advertisementService.DeleteAd(id);
        //    return Ok();
        //}
    }
}