using PetAdoption.Data;
using PetAdoption.DataModel;
using PetAdoption.Web.Adapters.DataAdapters;
using PetAdoption.Web.Adapters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAdoption.Web.Controllers
{
    public class HomeController : Controller
    {
        //declaring private interface called _adapter
        IShelterInterface _adapter;

        //home controller constructor that makes _adapter into a new ShelterAdapter()
        public HomeController()
        {
            _adapter = new ShelterAdapter();
        }

        //displays all pets
        [HttpGet]
        public ActionResult SeeAllPets()
        {
            List<Pet> Pets = _adapter.SeeAllPets();
            return View(Pets);
        }

        //see searched for pets
        [HttpPost]
        public ActionResult SeeAllPets(string Search, string order)
        {
            List<Pet> Pets = _adapter.FilterPets(Search, order);
            return View(Pets);
        }
        //display all shelters on home page
        public ActionResult Index()
        {
            List<Shelter> Shelters = _adapter.GetShelters();
            return View(Shelters);
        }

        //when loading the addshelter page, return a normal view
        [HttpGet]
        public ActionResult AddShelter()
        { 
            return View();
        }

        //when adding shelter, pass the shelter to the adapter function to add to database and return to Index page
        [HttpPost]
        public ActionResult AddShelter(Shelter shelter)
        {
            _adapter.AddShelter(shelter);
            return RedirectToAction("Index");
        }

        //shows pets from the shelter's property List<Pet> Pets
        [HttpGet]
        public ActionResult ShelterDetails(int id)
        {
            Shelter ShelterPets = _adapter.ShowPets(id);
            return View(ShelterPets);
        }

        //delete shelter on shelterdetails page and return to home page listing of shelters
        public ActionResult DeleteShelter(int id)
        {
            _adapter.DeleteShelter(id);
            return RedirectToAction("Index");
        }

        //when loading addpet page, take in shelter id for later use
        [HttpGet]
        public ActionResult AddPet(int id)
        {
            Pet pet = new Pet(); pet.ShelterId = id;
            return View(pet);
        }

        //add pet to correct shelter and return to correct shelter view
        [HttpPost]
        public ActionResult AddPet(Pet pet, type category)
        {
            
            _adapter.AddPet(pet, category);
            return RedirectToAction("ShelterDetails", new {Id = pet.ShelterId });
        }

        public ActionResult AdoptedPets(int id)    //[HttpGet] with parameter Search
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pet pet = db.Pets.Find(id);
                Pets.Instance.PetList.Add(pet);
                return View(Pets.Instance.PetList);
            }

        }
    }
}