using System;
using System.ComponentModel.DataAnnotations;

namespace Emprender.Models
{
    
    public class Empresas
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string IngresosBrutos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> FechaInicio { get; set; }
        public string Logo { get; set; }
        public int User_Id { get; set; }
        public int Habilitado { get; set; }
    }
}
