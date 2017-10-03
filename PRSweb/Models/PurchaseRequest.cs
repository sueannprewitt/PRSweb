using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSweb.Models
{
    public class PurchaseRequest
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        [Index(IsUnique = true)]
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
        public virtual User User { get; set; }

        public void Clone(PurchaseRequest pr)
        {
            Description = pr.Description;
            Justification = pr.Justification;
            DateNeeded = pr.DateNeeded;
            DeliveryMode = pr.DeliveryMode;
            Status = pr.Status;
            Total = pr.Total;
            UserId = pr.UserId;
        }
    }
}