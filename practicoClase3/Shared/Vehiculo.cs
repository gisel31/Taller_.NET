using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public string Marca { get; set; } = "";
        public string Modelo { get; set; } = "";
        public string Matricula { get; set; } = "";

        public long PropietarioId { get; set; } 
        public Persona Propietario { get; set; } 

        public void Print()
        {
            Console.WriteLine("-- Vehículo --");
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Matrícula: " + Matricula);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Marca + " | " + Modelo + " | " + Matricula + " |");
        }
    }
}
