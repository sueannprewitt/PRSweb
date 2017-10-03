﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSweb.Models
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(30)] //annotation to give a restriction to the amount of characters that a user is allowed to enter
        [Required] //annotation to require the user to enter something
        [Index(IsUnique = true)] //annotation to make the UserName unique. EF will tell SQL to put a unique identifier on this field
        public string UserName { get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(30)]
        [Required]
        public string LastName { get; set; }
        [StringLength(12)]
        [Required]
        public string Phone { get; set; }
        [StringLength(30)]
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsReviewer { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}