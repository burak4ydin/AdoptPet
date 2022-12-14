using System;
using System.ComponentModel.DataAnnotations;

namespace AdoptPetProject.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string catName { get; set; }
    }
}

