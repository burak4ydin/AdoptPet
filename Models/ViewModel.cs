using System;
namespace AdoptPetProject.Models
{
    public class ViewModel
    {
        
        public IEnumerable<Pet> Pets { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}

