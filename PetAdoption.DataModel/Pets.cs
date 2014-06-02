using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.DataModel
{
    public sealed class Pets
    {
        private static readonly Pets instance = new Pets();

        static Pets()
        {

        }
        public List<Pet> PetList = new List<Pet>();
        private Pets() { }
        public static Pets Instance
        {
            get { return instance;  }
        }
    }
}
