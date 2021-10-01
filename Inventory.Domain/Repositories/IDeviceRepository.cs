using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Models;

namespace Inventory.Domain.Repositories
{
    public interface IDeviceRepository
    {
        int CreateDevice(Device device);

        Device FindDevice(int deviceId);

        int EditDevice(Device device);

        int DeleteDevice(Device device);

        List<Device> Device();
    }
}
