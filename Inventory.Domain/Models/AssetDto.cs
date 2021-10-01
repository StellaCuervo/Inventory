using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Models
{
    public class AssetDto
    {
     
        public int Id { get; set; }

        public string Description { get; set; }

        public AssetTypeDto Type { get; set; }


        public LocationDto Location { get; set; }


        public DeviceDto Device { get; set; }

    }
}
