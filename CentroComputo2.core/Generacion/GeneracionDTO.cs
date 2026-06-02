using EIN.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Ein.DTOS
{
    public class GeneracionSetDTO
    {
        [Required, StringLength(20)] public string Nombre { get; set; } = string.Empty;
    }

    public class GeneracionGetDTO
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public object NombreGeneracion { get; set; }
    }
}
