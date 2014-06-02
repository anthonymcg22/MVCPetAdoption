using PetAdoption.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Web.Adapters.Interfaces
{
    public interface IShelterInterface
    {
        List<Shelter> GetShelters();
        Shelter ShowPets(int id);
        void AddPet(Pet pet, type category);
        void AddShelter(Shelter shelter);
        void DeleteShelter(int id);
        List<Pet> SeeAllPets();
        List<Pet> FilterPets(string search, string order);
    }
}
