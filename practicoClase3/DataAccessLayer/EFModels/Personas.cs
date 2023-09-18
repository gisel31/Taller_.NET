﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EFModels
{
    public class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(128), MinLength(3)]
        public string Documento { get; set; } = "";

        [MaxLength(128), MinLength(3)]
        public string Nombres { get; set; } = "";
        
        [MaxLength(128), MinLength(3)]
        public string Apellidos { get; set; } = "";

        public int Telefono { get; set; }

        [MaxLength(128), MinLength(3)]
        public string Direccion { get; set; } = "";

        public DateTime FechaNacimiento { get; set; }
        public ICollection<Vehiculos> Vehiculos { get; set; } = new List<Vehiculos>();

    }
}
