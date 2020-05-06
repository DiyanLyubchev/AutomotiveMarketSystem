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
        private readonly ICarService carService;
        private readonly IAdvertisementService advertisementService;

        private readonly IMapper mapper;

        public AdvertisementController(ICarService carService, IMapper mapper, IAdvertisementService advertisementService)
        {
            this.mapper = mapper;
            this.carService = carService;
            this.advertisementService = advertisementService;
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
        private async Task<CarViewModel> GetCarViewModel(CarDto carDto)
        {

            var models = await this.carService.GetAllModelAsync();
            var allmodells = this.mapper.Map<List<CarBrandViewModel>>(models);

            var carBrand = await this.carService.GetModelByBrandIdAsync(carDto.CarBrandId);
            var carBrandView = this.mapper.Map<List<CarModelViewModel>>(carBrand);

            var carViewModel = new CarViewModel
            {
                Id = carDto.Id,
                Door = carDto.Door,
                EngineTypeId = carDto.EngineTypeId,
                CarBrandId = carDto.CarBrandId,
                CarModelId = carDto.CarModelId,
                Price = carDto.Price,
                ProductionYear = carDto.ProductionYear,
                AllCarModel = allmodells,
                UserId = carDto.UserId,
                ImagePath = carDto.ImagePath,
                Image = carDto.Image,
                AllCarBrandByModel = carDto.CarBrandId == 0 ?
                    Enumerable.Empty<CarModelViewModel>() : carBrandView
            };

            return carViewModel;
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateAdvertisement(int id)
        {
            try
            {
                var carId = await this.advertisementService.GetAdById(id);
                var currentCar = await this.carService.GetCarBy(carId);
                var carVm = await GetCarViewModel(currentCar);

                return View(carVm);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateAdvertisement(CarViewModel vm)
        {
            try
            {
                var currentCar = this.mapper.Map<CarDto>(vm);

                await this.carService.UpdateCar(currentCar);

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}