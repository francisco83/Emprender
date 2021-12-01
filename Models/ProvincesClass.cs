using System;
using System.ComponentModel.DataAnnotations;

namespace Emprender.Models
{
    public class ProvincesClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
