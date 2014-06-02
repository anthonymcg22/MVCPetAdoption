using PetAdoption.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace PetAdoption.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext context, bool createShelters = true, bool createPets = true)
        {
            if (createShelters)
                CreateShelters(context);
            if (createPets)
                CreatePets(context);
        }
        //create shelters
        private static void CreateShelters(ApplicationDbContext context)
        {
            context.Shelters.AddOrUpdate(new Shelter { Name = "Rainbow Village", Location = "Austin", Image = "http://tx-desoto2.civicplus.com/images/pages/N357//Animal%20shelter.JPG" },
                new Shelter { Name = "Love And Care", Location = "Orlando", Image = "http://www.dodgecity.org/images/pages/N174/Animal%20Shelter%20Pic.JPG" },
                new Shelter { Name = "Coast Animals", Location = "Huntington Beach", Image = "http://www.adoptny.org/wp-content/Cimy_User_Extra_Fields/hempsteadanimalshelter/Animal%20Shelter%20logo2.jpg" });
            context.SaveChanges();
        }
        //create pets
        private static void CreatePets(ApplicationDbContext context)
        {
            context.Pets.AddOrUpdate(new Pet { Name = "Buddy", type = type.cat, Image = "http://www.listchallenges.com/f/items/6055d26b-1ffe-4881-8220-f3aee9c7dcd7.jpg", ShelterId = 1, Description = "fun little affectionate kitten" },
                new Pet { Name = "Tinker", type = type.ferret, Image = "http://images.nationalgeographic.com/wpf/media-live/photos/000/004/cache/black-footed-ferret_465_600x450.jpg", ShelterId = 3, Description = "hard-headed playful fuzzball" },
                new Pet { Name = "Jasonian", type = type.dog, Image = "http://0.tqn.com/d/friendship/1/0/K/-/-/-/dogs.jpg", ShelterId = 2, Description = "friendliest and most loyal dog you will find" });
            context.SaveChanges();
        }
    }
}
