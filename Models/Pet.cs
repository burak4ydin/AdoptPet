﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdoptPetProject.Models
{
    public class Pet
    {
        [Key]
        public int id { get; set; }
        public Category catId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string province { get; set; }
        public string description { get; set; }
        public string photoLink { get; set; }

    }
}

