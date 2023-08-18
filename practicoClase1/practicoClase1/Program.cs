using System;
using System.Collections.Generic;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using shared;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDALs_Personas personas = new DAL_Personas();
            List<Persona> listaPersonas = new List<Persona>();

            string input;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese su nombre:");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese su apellido:");
                    string apellido = Console.ReadLine();

                    string documento;
                    Persona persona = new Persona();

                    while (true)
                    {
                        Console.WriteLine("Ingrese su documento:");
                        documento = Console.ReadLine();

                        if (documento.Length != 8)
                        {
                            Console.WriteLine("Documento debe tener exactamente 8 dígitos.");
                            continue;
                        }

                        if (!persona.verificar_cedula(int.Parse(documento)))
                        {
                            Console.WriteLine("Documento inválido.");
                            continue;
                        }

                        break;
                    }

                    DateTime fechaNacimiento;
                    while (true)
                    {
                        Console.WriteLine("Ingrese su fecha de nacimiento (formato: mm/dd/yyyy):");
                        if (DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Fecha de nacimiento inválida. Inténtelo nuevamente.");
                        }
                    }

                    persona = new Persona
                    {
                        nombre = nombre,
                        Apellido = apellido,
                        Documento = documento,
                        FechaNacimiento = fechaNacimiento
                    };

                    personas.Insert(persona);
                    listaPersonas.Add(persona);

                    Console.WriteLine("¿Desea salir?\n Si--> Ingrese la palabra EXIT \n No--> Presione la tecla Enter\n");
                    input = Console.ReadLine().Trim().ToLower();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    input = string.Empty;
                }
            } while (input != "exit");

            Console.WriteLine("\nPersonas registradas ordenadas por edad descendente:");
            var personasOrdenadasPorEdadDes = listaPersonas.OrderByDescending(p => p.FechaNacimiento);

            foreach (var persona in personasOrdenadasPorEdadDes)
            {
                persona.Print();
            }
        }
    }
}
