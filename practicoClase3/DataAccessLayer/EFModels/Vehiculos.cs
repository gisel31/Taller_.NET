using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataAccessLayer.EFModels
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(128), MinLength(3)]
        public string Marca { get; set; } = "";

        [MaxLength(128), MinLength(3)]
        public string Modelo { get; set; } = "";

        [MaxLength(128), MinLength(3)]
        public string Matricula { get; set; } = "";

        public int PropietarioId { get; set; } 
        public Persona Propietario { get; set; } 

        public ICollection<Vehiculos> Vehiculo { get; set; } = new List<Vehiculos>();
    }
}
