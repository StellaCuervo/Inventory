using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Models
{
    public class LocationDto
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

    }
}
