using PetAdoption.Data;
using PetAdoption.DataModel;
using PetAdoption.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdoption.Web.Adapters.DataAdapters
{
    public class ShelterAdapter : IShelterInterface
    {
        //display shelters on index page
        public List<Shelter> GetShelters()
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) {
                List<Shelter> shelters = db.Shelters.Include("Pets").ToList();
                return shelters;
            }

        }

        //shows pets of a certain shelter
        public Shelter ShowPets(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Shelter ShelterPets = db.Shelters.Include("Pets").Where(x => x.Id == id).FirstOrDefault();
                return ShelterPets;
            }
        }

        //Adds pets to certain shelter
        public void AddPet(Pet pet, type category)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pet MyPet = pet;
                MyPet.type = category;
                db.Pets.Add(MyPet);
                db.SaveChanges();
                
            }
        }

        //add shelter to list of shelters
        public void AddShelter(Shelter shelter)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Shelters.Add(shelter);
                db.SaveChanges();
            }
        }


        public void DeleteShelter(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                while (db.Pets.Where(x => x.ShelterId == id).Count() != 0)
                {
                    Pet pet = db.Pets.Where(x => x.ShelterId == id).FirstOrDefault();
                    db.Pets.Remove(pet);
                    db.SaveChanges();
                }
                Shelter shelter = db.Shelters.Find(id);
                db.Shelters.Remove(shelter);
                db.SaveChanges();
            }
        }


        public List<Pet> SeeAllPets()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Pet> Pets = db.Pets.OrderBy(x => x.Name).ToList();
                return Pets;
            }
        }


        public List<Pet> FilterPets(string search, string order)
        {

             
            List<Pet> Pets = new List<Pet>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    string s = search.ToLower();
                    Pets = db.Pets.Where(p => p.type.ToString().ToLower().Contains(s) || p.Name.ToLower().Contains(s) || p.Description.ToLower().Contains(s)).ToList();
                }
                else
                {
                    Pets = db.Pets.ToList();
                }
                
            }
            return Pets;
        }
    }
}