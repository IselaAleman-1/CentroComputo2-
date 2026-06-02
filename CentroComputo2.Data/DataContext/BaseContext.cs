using EIN.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CentroComputo2.Data.DataContext
{
    public class BaseContext:DbContext
    {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options) 
        {

        }
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<GeneracionEntity> Generaciones { get; set; }
        public DbSet<GrupoEntity> Grupos { get; set; }
    }
}
