using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class Device
    {
        [Key]
        public int Serial { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(2, ErrorMessage = "{0} must be at least {2} and maximum {1} characters", MinimumLength = 1)]
        public string Type { get; set; }
    }
}
