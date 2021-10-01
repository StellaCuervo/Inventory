using System.Collections.Generic;
using System.Linq;
using Inventory.Domain;
using Inventory.Domain.Models;
using Inventory.Domain.Repositories;

namespace Inventory.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public int CreateDevice(Device device)
        {
            _context.Device.Add(device);
            return _context.SaveChanges();
        }

        public Device FindDevice(int deviceId)
        {
            return _context.Device.Find(deviceId);
        }

        public int EditDevice(Device device)
        {
            _context.Device.Update(device);
            return _context.SaveChanges();
        }


        public int DeleteDevice(Device device)
        {
            _context.Device.Remove(device);
            return _context.SaveChanges();
        }

        public List<Device> Device()
        {
            return _context.Device.ToList();
        }
    }
}
