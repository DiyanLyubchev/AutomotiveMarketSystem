﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutomotiveMarketSystem.Models;
using AutomotiveMarketSystem.Service.Contracts;
using AutomotiveMarketSystem.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomotiveMarketSystem.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly IMapper mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            this.carService = carService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async  Task<IActionResult> AddCar()
        {
            try
            {
                var car = await GetOfficeViewModelAsync(new CarDto());

                return View(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private async Task<CarViewModel> GetOfficeViewModelAsync(CarDto carDto)
        {

            var models = await this.carService.GetAllModelAsync();
            var allmodells = this.mapper.Map<List<CarBrandViewModel>>(models);

            var carBrand = await this.carService.GetModelByBrandIdAsync(carDto.CarModelId);
            var carBrandView = this.mapper.Map<List<CarModelViewModel>>(carBrand);

            var carViewModel = new CarViewModel
            {
                Id = carDto.Id,
                Door = carDto.Door,
                EngineTypeStatusId = carDto.EngineTypeStatusId,
                CarBrandId  = carDto.CarBrandId,
                CarModelId = carDto.CarModelId,
                Price = carDto.Price,
                ProductionYear = carDto.ProductionYear,
                AllCarModel = allmodells,
                AllCarBrandByModel = carDto.CarBrandId == 0 ?
                    Enumerable.Empty<CarModelViewModel>() : carBrandView
                   
            };

            return carViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newCarfromUi = this.mapper.Map<CarDto>(viewModel);
                var newCar = await this.carService.AddCar(newCarfromUi);

                var newCarFromData = this.mapper.Map<CarViewModel>(newCar);
              
                return View("AddCarToAdvetisement" ,newCarFromData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}