using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using DataAccessLayer.EFModels;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;
        IBL_Vehiculos _vehiculosBL;
        public Commands(IBL_Personas personasBL, IBL_Vehiculos vehiculosBL)
        {
            _personasBL = personasBL;
            _vehiculosBL = vehiculosBL;
        }

        public void AddPersona()
        {
            Console.WriteLine("Ingrese el nombre de la persona: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido de la persona: ");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el documento de la persona: ");
            string documento = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección de la persona: ");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento de la persona (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento))
            {
                try
                {
                    Console.WriteLine("Ingrese el número de teléfono de la persona: ");
                    if (int.TryParse(Console.ReadLine(), out int telefono))
                    {
                        Persona persona = new Persona
                        {
                            Nombres = nombre,
                            Apellidos = apellido,
                            Documento = documento,
                            Direccion = direccion,
                            FechaNacimiento = fechaNacimiento,
                            Telefono = telefono
                        };

                        _personasBL.Insert(persona);
                        Console.WriteLine("Persona agregada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El número de teléfono ingresado no es válido.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar la persona:");
                    Console.WriteLine(ex.ToString()); 
                }
            }
            else
            {
                Console.WriteLine("La fecha de nacimiento ingresada no es válida.");
            }
        }



        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");

            foreach (Persona persona in personas)
            {
                persona.Print();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);

            Console.WriteLine("Persona eliminada correctamente.");
        }

        public void AddVehiculoToPersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a la que desea agregar un vehículo: ");
            string documento = Console.ReadLine();

            Persona persona = _personasBL.Get(documento);
            Console.WriteLine(persona.Nombres);
            Console.WriteLine(persona.Id);
            Console.WriteLine(persona.Direccion);
            if (persona == null)
            {
                Console.WriteLine("La persona no existe.");
                return;
            }

            Vehiculos vehiculo = new Vehiculos();
            Console.WriteLine("Ingrese la marca del vehículo: ");
            vehiculo.Marca = Console.ReadLine();
            Console.WriteLine("Ingrese el modelo del vehículo: ");
            vehiculo.Modelo = Console.ReadLine();
            Console.WriteLine("Ingrese la matrícula del vehículo: ");
            vehiculo.Matricula = Console.ReadLine();

            vehiculo.Propietario = persona;

            _vehiculosBL.Insert(vehiculo);

            Console.WriteLine("Vehículo agregado a la persona correctamente.");
        }




    }
}
