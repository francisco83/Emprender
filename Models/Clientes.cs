using System;
using System.ComponentModel.DataAnnotations;

namespace Emprender.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int ProvinciaId { get; set; }
        public string Direccion { get; set; }
        public int Habilitado { get; set; }
        public int EmpresaId { get; set; }
    }
}
