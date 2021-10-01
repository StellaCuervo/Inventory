using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} and maximum {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        public AssetType Type { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public Location Location { get; set; }

        [Required(ErrorMessage = "Device is required")]
        public Device Device { get; set; }


    }
}
