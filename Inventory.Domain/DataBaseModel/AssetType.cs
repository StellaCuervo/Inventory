using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class AssetType
    {
        [Key]
        public int AssetTypeId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(20, ErrorMessage = "{0} must be at least {2} and maximum {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}
