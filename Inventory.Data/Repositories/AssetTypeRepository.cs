using System.Collections.Generic;
using System.Linq;
using Inventory.Domain;
using Inventory.Domain.Repositories;

namespace Inventory.Data.Repositories
{
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetTypeRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public int CreateAssetType(AssetType assetType)
        {
            _context.AssetType.Add(assetType);
            return _context.SaveChanges();
        }

        public AssetType FindAssetType(int assetTypeId)
        {
            return _context.AssetType.Find(assetTypeId);
        }

        public int EditAssetType(AssetType assetType)
        {
            _context.AssetType.Update(assetType);
            return _context.SaveChanges();
        }


        public int DeleteAssetType(AssetType assetType)
        {
            _context.AssetType.Remove(assetType);
            return _context.SaveChanges();
        }

        public List<AssetType> AssetType()
        {
            return _context.AssetType.ToList();
        }
    }
}
