
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EIN.Entidades
{
    [Table("Grupo")]
    public class GrupoEntity
    {
        [Key]public int Id { get; set; }
        [Required]public int IdGeneracion { get; set; }
        [Required, StringLength(12)]public string Nombre { get; set; } = string.Empty;
        [Required] public bool EstaActivo { get; set; }

        [ForeignKey("IdGeneracion")] public GeneracionEntity Generacion { get; set; }
        
    }
}
