using BusinessLayer.IBLs;
using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLs
{
    public class BL_Vehiculos : IBL_Vehiculos
    {
        private IDAL_Vehiculos _vehiculos;

        public BL_Vehiculos(IDAL_Vehiculos vehiculos)
        {
            _vehiculos =vehiculos;
        }

        public List<Vehiculos> Get()
        {
            return _vehiculos.Get();
        }

        public Vehiculos Get(string documento)
        {
            return _vehiculos.Get(documento);
        }

        public void Insert(Vehiculos vehiculos)
        {
            _vehiculos.Insert(vehiculos);
        }

        public void Update(Vehiculos vehiculos)
        {
            _vehiculos.Update(vehiculos);
        }

        public void Delete(string documento)
        {
            _vehiculos.Delete(documento);
        }
    }
}
