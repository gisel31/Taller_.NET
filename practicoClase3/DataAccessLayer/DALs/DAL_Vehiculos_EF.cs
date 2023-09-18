using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Vehiculos_EF 
    {
        private DBContextCore _dbContext;

        public DAL_Vehiculos_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }
        public void Insert(Vehiculos vehiculo)
        {
            var existingVehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == vehiculo.Matricula);

            if (existingVehiculo != null)
            {
                throw new Exception("El vehículo ya existe en la base de datos.");
            }

            _dbContext.Vehiculos.Add(vehiculo);

            _dbContext.SaveChanges();
        }
    }
}
