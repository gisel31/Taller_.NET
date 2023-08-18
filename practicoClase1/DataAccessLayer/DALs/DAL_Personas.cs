using DataAccessLayer.IDALs;
using shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas : IDALs_Personas
    {
        private List<Persona> personas = new List<Persona>();
        public List<Persona> GetPersonas()
        {
            return personas;
        }

        public void Insert(Persona persona)
        {
            personas.Add(persona);
        }
    }
}
