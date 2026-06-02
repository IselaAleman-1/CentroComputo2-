
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EIN.Enumeradores;


namespace EIN.Entidades
{
    [Table("Alumno")]
    public class AlumnoEntity
    {
        [Key]public int Id { get; set; }
        [Required,StringLength(8)]public string NumeroCuenta { get; set; } = string.Empty;
        [Required, StringLength(30)] public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(30)] public string ApellidoPaterno { get; set; } = string.Empty;
        [StringLength(30)] public string ApellidoMaterno { get; set; } = string.Empty;
        [StringLength(10)] public string Telefono { get; set; } = string.Empty;
        public SexoEnum Sexo { get; set; } 
        public int IdGrupo { get; set; }
        public bool EstaActivo { get; set; }

        [ForeignKey("IdGrupo")]public virtual GrupoEntity Grupo { get; set; } 

    }
}
