﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRSweb.Models
{
    public class PRSwebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PRSwebContext() : base("name=PRSwebContext")
        {
        }

        public System.Data.Entity.DbSet<PRSweb.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<PRSweb.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<PRSweb.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<PRSweb.Models.PurchaseRequest> PurchaseRequests { get; set; }

        public System.Data.Entity.DbSet<PRSweb.Models.PurchaseRequestLineItem> PurchaseRequestLineItems { get; set; }
    }
}
