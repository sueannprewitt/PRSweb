using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSweb.Models
{
    public class PurchaseRequest
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        public string Description { get; set; }
        [StringLength(50)]
        [Required]
        public string Justification { get; set; }
        [Required]
        public DateTime DateNeeded { get; set; }
        [StringLength(50)]
        [Required]
        public string DeliveryMode { get; set; }
        [StringLength(50)]
        [Required]
        public string Status { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public DateTime SubmittedDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}