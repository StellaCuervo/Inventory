using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public int CreateAsset(Asset asset)
        {
            _context.Asset.Add(asset);
            return _context.SaveChanges();
        }

        public Asset FindAsset(int assetId)
        {
            return _context.Asset.Find(assetId);
        }

        public int EditAsset(Asset asset)
        {
            _context.Asset.Update(asset);
            return _context.SaveChanges();
        }


        public Asset EditAsset(int assetId)
        {
            return _context.Asset.Find(assetId);
        }

        public int DeleteAsset(Asset asset)
        {
            _context.Asset.Remove(asset);
            return _context.SaveChanges();
        }

        public List<Asset> Asset()
        {
            return _context.Asset.Include(l => l.Location).Include(d => d.Device).Include(t => t.Type).ToList();
        }

    }
}
