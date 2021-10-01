using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Repositories
{
    public interface ILocationRepository
    {
        int CreateLocation(Location location);

        Location FindLocation(int locationId);

        int EditLocation(Location location);

        int DeleteLocation(Location location);

        List<Location> Location();
    }
}
