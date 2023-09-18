using DataAccessLayer.DALs;
using DataAccessLayer.EFModels;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDALs
{
    public interface IDAL_Vehiculos
    {
        List<Vehiculos> Get();

        Vehiculos Get(string documento);

        void Insert(Vehiculos vehiculos);

        void Update(Vehiculos vehiculos);

        void Delete(string documento);
    }
}
