using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Inventory.Domain;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IAssetTypeRepository _assetTypeRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IDeviceRepository _deviceRepository;
        public AssetsController(IAssetRepository assetRepository, IAssetTypeRepository assetTypeRepository, ILocationRepository locationRepository, IDeviceRepository deviceRepository)
        {
            _assetRepository = assetRepository;
            _assetTypeRepository = assetTypeRepository;
            _locationRepository = locationRepository;
            _deviceRepository = deviceRepository;
        }

        //Http Get Index
        public IActionResult Index()
        {
            List<Asset> listAssets = _assetRepository.Asset();

            List<AssetDto> listAssetDto = new List<AssetDto>();

            foreach (var dto in listAssets)
            {
                var asset = new AssetDto()
                {
                    Id = dto.Id,
                    Description = dto.Description,
                    Device = new DeviceDto()
                    {
                        Serial = dto.Device.Serial,
                        Type = dto.Device.Type
                    },
                    Type = new AssetTypeDto()
                    {
                        AssetTypeId = dto.Type.AssetTypeId,
                        Description = dto.Type.Description
                    },
                    Location = new LocationDto()
                    {
                        City = dto.Location.City,
                        Country = dto.Location.Country,
                        Id = dto.Location.Id,
                        State = dto.Location.State
                    }
                };

                listAssetDto.Add(asset);
            }

            return View(listAssetDto);
        }


        //Http Get Create
        public IActionResult Create()
        {
            ViewBag.Type = _assetTypeRepository.AssetType();
            ViewBag.FullDescription = _locationRepository.Location().Select(l => new SelectListItem { 
            Text = string.Format("{0} {1} {2}", l.Country, l.State, l.City),
            Value = l.Id.ToString()
            });
            ViewBag.FullDevice = _deviceRepository.Device().Select(d => new SelectListItem
            {
                Text = string.Format("{0} {1}", d.Serial, d.Type),
                Value = d.Serial.ToString()
            }); ;
            ViewBag.Location = _locationRepository.Location();
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssetDto asset)
        {
            if (ModelState.IsValid)
            {             
                var assetNew = new Asset() {
                    Description = asset.Description,
                    Device = _deviceRepository.FindDevice(asset.Device.Serial),
                    Id = asset.Id,
                    Location = _locationRepository.FindLocation(asset.Location.Id),
                    Type = _assetTypeRepository.FindAssetType(asset.Type.AssetTypeId)
                };

                var result = _assetRepository.CreateAsset(assetNew);
                TempData["message"] = "The asset was created";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
