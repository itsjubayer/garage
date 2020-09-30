using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetGarage.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Manufacturer Name cannot exceed 250 characters")]
        public string Manufacturer { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Model { get; set; }
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Year { get; set; }
        [Required]
        [Display(Name = "Product Region") ]
        [MaxLength(50, ErrorMessage = "Product Region cannot exceed 50 characters")]
        public string ProductRegion { get; set; }

    }
}
