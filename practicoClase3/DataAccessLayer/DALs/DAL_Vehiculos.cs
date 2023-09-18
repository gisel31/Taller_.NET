using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Vehiculos : IDAL_Vehiculos
    {
        private string _connectionString = "Server=localhost,1400;Database=practico5;User Id=sa;Password=Abc*123!;Encrypt=False;";
        
        private DBContextCore _dbContext;
        public DAL_Vehiculos(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }
        List<Vehiculos> Get()
        {
       
            return new List<Vehiculos>();
        }

        Vehiculos Get(string documento)
        {
        
            return null;
        }

        void Insert(Vehiculos vehiculos)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Vehiculos(Marca, Modelo, Matricula, PropietarioId) VALUES(@marca, @modelo, @matricula, @propietarioId)", connection))
                {
                    command.Parameters.AddWithValue("@marca", vehiculos.Marca);
                    command.Parameters.AddWithValue("@modelo", vehiculos.Modelo);
                    command.Parameters.AddWithValue("@matricula", vehiculos.Matricula);
                    command.Parameters.AddWithValue("@propietarioId", vehiculos.PropietarioId);

                    command.ExecuteNonQuery();
                }
            }
        }

        void Update(Vehiculos vehiculos)
        {

        }

        void Delete(string documento)
        {

        }
    }
}
