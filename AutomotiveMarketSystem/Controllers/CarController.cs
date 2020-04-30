using System;
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
        public IActionResult AddCar()
        {
            return View();
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
                return View(newCar);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}