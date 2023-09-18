namespace Shared
{
    public class Persona
    {
      public string Nombre { get; set; } = "-- Sin Nombre --";

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length >= 7)
                {
                    documento = value;
                }
                else
                {
                    throw new Exception("El formato del documento no es correcto.");
                }
            }
        }
        // public int Id { get; set; }

        public int Id { get; set; }

        public string Nombres { get; set; } = ""; 
        public string Apellidos { get; set; } = ""; 
        public string Direccion { get; set; } = ""; 
        public DateTime FechaNacimiento { get; set; } 
        public int Telefono { get; set; } 
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Documento: " + Documento);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Fecha de Nacimiento: " + FechaNacimiento);
            Console.WriteLine("Teléfono: " + Telefono);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Documento + " | " + Nombres + " |" + Telefono + " |" + Direccion + " |");
        }
    
}
}