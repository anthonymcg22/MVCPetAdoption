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
                if (search != "")
                {
                    if (type.dog.ToString().Contains(search.ToLower())) {
                        Pets = db.Pets.Where(x => x.type == type.dog || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList(); }
                    else if (type.cat.ToString().Contains(search.ToLower())) {
                        Pets = db.Pets.Where(x => x.type == type.cat || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList(); }
                    else if (type.bird.ToString().Contains(search.ToLower()))
                    {
                        Pets = db.Pets.Where(x => x.type == type.bird || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
                    else if (type.ferret.ToString().Contains(search.ToLower()))
                    {
                        Pets = db.Pets.Where(x => x.type == type.ferret || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
                    else if (type.fish.ToString().Contains(search.ToLower()))
                    {
                        Pets = db.Pets.Where(x => x.type == type.fish || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
                    else if (type.hamster.ToString().Contains(search.ToLower()))
                    {
                        Pets = db.Pets.Where(x => x.type == type.hamster || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
                    else if (type.rabbit.ToString().Contains(search.ToLower()))
                    {
                        Pets = db.Pets.Where(x => x.type == type.rabbit || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
                    else if (type.turtle.ToString().Contains(search.ToLower()))
                    {
                        Pets = db.Pets.Where(x => x.type == type.turtle || x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
                    else
                    {
                        Pets = db.Pets.Where(x => x.Name.ToLower().Contains(search.ToLower())
                            || x.Description.Contains(search.ToLower())).ToList();
                    }
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