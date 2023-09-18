using DataAccessLayer.EFModels;
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
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            throw new NotImplementedException();
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { Documento = p.Documento, Nombres = p.Nombres , Id = p.Id, Apellidos = p.Apellidos, Direccion = p.Direccion, Telefono
                              = p.Telefono})
                             .ToList();
        }

        public Persona Get(string documento)
        {
            var personaEntity = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);

            if (personaEntity == null)
            {
                return null; 
            }

            var persona = new Persona
            {
                Id = personaEntity.Id,
                Documento = personaEntity.Documento,
                Nombres = personaEntity.Nombres,
                Apellidos = personaEntity.Apellidos,
                Telefono = personaEntity.Telefono,
                Direccion = personaEntity.Direccion,
                FechaNacimiento = personaEntity.FechaNacimiento
            };

            return persona;
        }

        public void Insert(Persona persona)
        {
            var existingPerson = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if (existingPerson != null)
            {
                throw new Exception("La persona ya existe en la base de datos.");
            }

            var nuevaPersona = new Personas
            {
                Documento = persona.Documento,
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                Telefono = persona.Telefono,
                Direccion = persona.Direccion,
                FechaNacimiento = persona.FechaNacimiento
            };

            _dbContext.Personas.Add(nuevaPersona);

            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            throw new NotImplementedException();
        }

        public void InsertVehiculo(Vehiculos vehiculo)
        {
            // Verificar si el vehículo ya existe en la base de datos (por ejemplo, por matrícula)
            var existingVehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Matricula == vehiculo.Matricula);

            if (existingVehiculo != null)
            {
                throw new Exception("El vehículo ya existe en la base de datos.");
            }

            // Asignar la persona al vehículo (si es necesario)
            // vehiculo.Propietario = persona;

            // Agregar el vehículo a la lista de vehículos (si es necesario)
            // persona.Vehiculos.Add(vehiculo);

            // Agregar el vehículo a la tabla de vehículos
            _dbContext.Vehiculos.Add(vehiculo);

            // Guardar cambios en la base de datos
            _dbContext.SaveChanges();
        }

    }
}
