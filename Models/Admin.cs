﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdoptPetProject.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}

