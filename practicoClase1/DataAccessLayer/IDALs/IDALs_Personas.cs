using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shared;

namespace DataAccessLayer.IDALs
{
    public interface IDALs_Personas
    {
        void Insert(Persona persona);

        List<Persona> GetPersonas();
            
    }
}
