using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSweb.Models
{
    public class PurchaseRequestLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        public int PurhaseRequestId { get; set; }
        public PurchaseRequest PurchaseRequest { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}