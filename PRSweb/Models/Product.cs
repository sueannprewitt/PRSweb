using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSweb.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength (50)]
        [Required]
        public string VendorPartNumber { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(50)]
        [Required]
        public string Unit { get; set; }
        [StringLength(50)]
        [Required]
        public string PhotoPath { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}