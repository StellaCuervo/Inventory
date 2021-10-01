using System.Collections.Generic;

namespace Inventory.Domain.Repositories
{
    public interface IAssetRepository
    {
        List<Asset> Asset();

        int CreateAsset(Asset asset);

        Asset FindAsset(int assetId);

        int EditAsset(Asset asset);

        int DeleteAsset(Asset asset);

        Asset EditAsset(int assetId);

    }
}
