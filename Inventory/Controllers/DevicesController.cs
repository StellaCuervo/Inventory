using System.Collections.Generic;
using Inventory.Domain;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        //Http Get Index
        public IActionResult Index()
        {
            List<Device> listDevice = _deviceRepository.Device();

            List<DeviceDto> listDeviceDto = new List<DeviceDto>();

            foreach (var dto in listDevice)
            {
                var deviceDto = new DeviceDto()
                {
                    Serial = dto.Serial,
                    Type = dto.Type
                };

                listDeviceDto.Add(deviceDto);
            }
                
            return View(listDeviceDto);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceDto device)
        {
            if (ModelState.IsValid)
            {
                var deviceNew = new Device()
                {
                    Serial = device.Serial,
                    Type = device.Type
                };

                var result = _deviceRepository.CreateDevice(deviceNew);
                TempData["message"] = "The device was created";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
