using System.Collections.Generic;

namespace Inventory.Domain.Repositories
{
    public interface IAssetTypeRepository
    {
        int CreateAssetType(AssetType assetType);

        AssetType FindAssetType(int assetTypeId);

        int EditAssetType(AssetType assetType);

        int DeleteAssetType(AssetType assetType);

        List<AssetType> AssetType();
    }
}
