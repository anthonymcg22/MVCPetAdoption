using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataModel
{
    public class Pet
    {
        //primary key
        public int Id { get; set; }
        //type of pet
        public type type { get; set; }
        //name of pet
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        //foreign shelter key and virtual shelter
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
    public enum type
    {
        cat,
        dog,
        bird,
        ferret,
        rabbit,
        turtle,
        hamster,
        fish
    }
}
