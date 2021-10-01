using System.Collections.Generic;
using Inventory.Domain;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        //Http Get Index
        public IActionResult Index()
        {
            List<Location> listLocation = _locationRepository.Location();

            List<LocationDto> listLocationDto = new List<LocationDto>();

            foreach (var dto in listLocation)
            {
                var locationDto = new LocationDto()
                {
                    Id = dto.Id,
                    Country = dto.Country,
                    State = dto.State,
                    City = dto.City
                };

                listLocationDto.Add(locationDto);
            }

            return View(listLocationDto);
        }

        //Http Get Create
        public IActionResult Create()
        {
            ViewBag.Location = _locationRepository.Location();
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LocationDto location)
        {
            if (ModelState.IsValid)
            {
                var locationNew = new Location()
                {
                    Id = location.Id,
                    Country = location.Country,
                    State = location.State,
                    City = location.City
                };

                var result = _locationRepository.CreateLocation(locationNew);
                TempData["message"] = "The location was created";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
