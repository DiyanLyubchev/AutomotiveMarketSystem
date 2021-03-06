﻿using AutoMapper;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace AutomotiveMarketSystem.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IAdvertisementService advertisementService;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public CarController(ICarService carService, IMapper mapper, IAdvertisementService advertisementService, IHostingEnvironment hostingEnvironment)
        {
            this.mapper = mapper;
            this.carService = carService;
            this.advertisementService = advertisementService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCar()
        {
            try
            {
                var car = await GetCarViewModel(new CarDto());

                return View(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCar(CarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (viewModel.Images != null && viewModel.Images.Count > 0)
                {
                    foreach (IFormFile image in viewModel.Images)
                    {

                        var (extension, isValid) = GetFileExtension(image.ContentType);

                        if (!isValid)
                        {
                            TempData["ErrorMessage"] = "Invalid file type, please upload image!";
                            return RedirectToAction("AddCar", "Car");
                        }
                        string destinationFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/cars");
                        string fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string imagePath = Path.Combine(destinationFolder, fileName);
                        image.CopyTo(new FileStream(imagePath, FileMode.Create));
                        if (viewModel.ImagePaths == null)
                        {
                            viewModel.ImagePaths = new List<string>();
                            viewModel.ImagePaths.Add($"/images/cars/" + fileName);
                        }
                        else
                        {
                            viewModel.ImagePaths.Add($"/images/cars/" + fileName);
                        }
                        // viewModel.CarImages.Add(new CarImageDto { ImagePath = viewModel.ImagePath });
                    }
                }

                var newCarfromUi = this.mapper.Map<CarDto>(viewModel);
                newCarfromUi.UserId = userId;
                //assign image path to DTO
                //newCarfromUi.ImagePath = viewModel.ImagePath;

                var newCar = await this.carService.AddCar(newCarfromUi);

                var newCarFromData = this.mapper.Map<CarViewModel>(newCar);
                newCarFromData.ImagePaths = viewModel.ImagePaths;
                newCarFromData.Images = viewModel.Images;

                newCarFromData.BrandName = await this.carService.GetBrandNameById(newCar.CarBrandId);
                newCarFromData.ModelName = await this.carService.GetModelNameById(newCar.CarModelId);

                return View("AddCarToAdvetisement", newCarFromData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private (string extension, bool isValid) GetFileExtension(string contentType)
        {
            if (contentType == "image/jpeg")
                return (".jpg", true);
            if (contentType == "image/png")
                return (".png", true);

            return (string.Empty, false);
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
                AdvertisementId = carDto.AdvertisementId,
                ProductionYear = carDto.ProductionYear,
                AllCarModel = allmodells,
                UserId = carDto.UserId,
                ImagePath = carDto.ImagePath,
                Images = carDto.Images,
                AllCarBrandByModel = carDto.CarBrandId == 0 ?
                    Enumerable.Empty<CarModelViewModel>() : carBrandView
            };

            return carViewModel;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var currentCar = await this.carService.GetCarBy(id);
                var carVm = await GetCarViewModel(currentCar);

                return View("Update", carVm);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(CarViewModel vm)
        {
            try
            {
                var currentCar = this.mapper.Map<CarDto>(vm);

                var updatedCar = await this.carService.UpdateCar(currentCar);
                var newCarFromData = this.mapper.Map<CarViewModel>(updatedCar);

                newCarFromData.BrandName = await this.carService.GetBrandNameById(updatedCar.CarBrandId);
                newCarFromData.ModelName = await this.carService.GetModelNameById(updatedCar.CarModelId);

                return View("AddCarToAdvetisement", newCarFromData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ShowMyCars()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var listOfMyCars = await this.carService.ShowMyCars(userId);
            var result = this.mapper.Map<List<CarViewModel>>(listOfMyCars);

            foreach (var item in result)
            {
                item.BrandName = await this.carService.GetBrandNameById(item.CarBrandId);
                item.ModelName = await this.carService.GetModelNameById(item.CarModelId);
            }

            return View(result);
        }
    }
}