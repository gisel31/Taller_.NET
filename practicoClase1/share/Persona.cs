namespace shared
{
    public class Persona
    {
        public string nombre { get; set; }

        private string documento;
        public string Documento
        {
            get { return documento; }
            set
            {
                if (value.Length != 8 && documento.Length < 9) 
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            }
        }

        public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }

            public void Print()
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("NOMBRE: " + nombre);
                Console.WriteLine("APELLIDO: " + Apellido);
                Console.WriteLine("DOCUMENTO: " + Documento);
                Console.WriteLine("FECHA DE NACIMIENTO: " + FechaNacimiento.ToString("dd/MM/yyyy"));
                Console.WriteLine("--------------------------------------------");
        }

        public bool verificar_cedula(int ci)
        {
            int a, b, c, d, e, f, g, h, s, M;

            a = (ci / 10000000);
            b = (ci / 1000000) % 10;
            c = (ci / 100000) % 10;
            d = (ci / 10000) % 10;
            e = (ci / 1000) % 10;
            f = (ci / 100) % 10;
            g = (ci / 10) % 10;
            h = (ci / 1) % 10;

            s = 2 * a + 9 * b + 8 * c + 7 * d + 6 * e + 3 * f + 4 * g;
            M = s % 10;

            int candidato = (10 - M) % 10;

            return candidato == h;
        }

    }
}