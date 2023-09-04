using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {

        private string _connectionString = "Server=localhost,1400;Database=practico2;User Id=sa;Password=Abc*123!;Encrypt=False;";

        public void Delete(string documento)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                String sql = "DELETE FROM Personas WHERE Documento=" + documento + ";";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                
                sqlDataAdapter.DeleteCommand = new SqlCommand(sql, connection);
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            }
        }

        public List<Persona> Get()
        {
            List<Persona> personas = new List<Persona>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Personas", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Persona persona = new Persona();
                            persona.Documento = reader["Documento"].ToString();
                            persona.Nombre = reader["Nombre"].ToString();
                            personas.Add(persona); 
                        }
                    }
                }
            }
            return personas;
        }

        public Persona Get(string documento)
        {
            Persona persona = new Persona();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Personas p WHERE p.Documento= @documento", connection))
                {
                    command.Parameters.AddWithValue("documento", documento);
                    //no sabemos si va @ o si va probar @documento

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                          
                            persona.Documento = reader["Documento"].ToString();
                            persona.Nombre = reader["Nombre"].ToString();                           
                        }
                    }
                }
            }
            return persona;
        }

        public void Insert(Persona persona)
        {      
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                String nom = persona.Nombre;
                String doc = persona.Documento;
                String sql = "INSERT INTO Personas (Nombre, Documento) VALUES('"+nom+"', '"+doc+"');";
                
                SqlCommand command = new SqlCommand(sql, connection);                   
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                
                sqlDataAdapter.InsertCommand = new SqlCommand(sql, connection);
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
            }
        }

        public void Update(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                String sql = "UPDATE Personas SET Nombre=" + persona.Nombre + "WHERE Documento="+persona.Documento+";";
              
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                
                sqlDataAdapter.UpdateCommand = new SqlCommand(sql, connection);
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
            }
        }
    }
}
