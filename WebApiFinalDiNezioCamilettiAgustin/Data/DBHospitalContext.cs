using Microsoft.EntityFrameworkCore;
using WebApiFinalDiNezioCamilettiAgustin.Models;

namespace WebApiFinalDiNezioCamilettiAgustin.Data
{
    public class DBHospitalContext:DbContext
    {
        public DBHospitalContext(DbContextOptions<DBHospitalContext>options):base(options) { }


        public DbSet<Hospital> Hospitales { get; set; }
        
        public DbSet<Doctor> Doctores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Nombre de las tablas
            modelBuilder.Entity<Hospital>().ToTable("Hospital");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");

            //PK
            modelBuilder.Entity<Hospital>().HasKey(x => x.HospitalId);
            modelBuilder.Entity<Doctor>().HasKey(x => x.DoctorId);

            //Propiedades Hospital
            modelBuilder.Entity<Hospital>().Property(h => h.Nombre).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.Direccion).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.Telefono).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.NumeroCama).HasColumnType("int");

            //Propiedades Doctor
            modelBuilder.Entity<Doctor>().Property(h => h.Apellido).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Doctor>().Property(h => h.Especialidad).HasColumnType("varchar(50)").IsRequired();
            
        }
    }
}
