using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain;
using Inventory.Domain.Repositories;

namespace Inventory.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public int CreateLocation(Location location)
        {
            _context.Location.Add(location);
            return _context.SaveChanges();
        }

        public Location FindLocation(int locationId)
        {
            return _context.Location.Find(locationId);
        }

        public int EditLocation(Location location)
        {
            _context.Location.Update(location);
            return _context.SaveChanges();
        }


        public int DeleteLocation(Location location)
        {
            _context.Location.Remove(location);
            return _context.SaveChanges();
        }

        public List<Location> Location()
        {
            return _context.Location.ToList();
        }
    }
}
