using System.Collections.Generic;
using System.Linq;
using Inventory.Data;
using Inventory.Domain;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class AssetTypesController : Controller
    {
        private readonly IAssetTypeRepository _assetTypeRepository;

        public AssetTypesController(IAssetTypeRepository assetTypeRepository)
        {
            _assetTypeRepository = assetTypeRepository;
        }

        //Http Get Index
        public IActionResult Index()
        {
            List<AssetType> listAssetTypes = _assetTypeRepository.AssetType();

            List<AssetTypeDto> assetTypeDto = new List<AssetTypeDto>();

            foreach (var dto in listAssetTypes)
            {
                var assetType = new AssetTypeDto()
                {
                    AssetTypeId = dto.AssetTypeId,
                    Description = dto.Description
                };

                assetTypeDto.Add(assetType);
            }           
            return View(assetTypeDto);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssetTypeDto assetType)
        {
            if (ModelState.IsValid)
            {
                var assetTypeNew = new AssetType()
                {
                    AssetTypeId = assetType.AssetTypeId,
                    Description = assetType.Description
                };

                var result = _assetTypeRepository.CreateAssetType(assetTypeNew);
                TempData["message"] = "The asset type was created";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
