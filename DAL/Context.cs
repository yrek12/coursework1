using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    internal class Context : DbContext
    {
        public Context() : base("name=ResumesAndVacancies")
        {
        }

        public IDbSet<Resume> Resumes { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Vacansy> Vacansies { get; set; }

        public IDbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>()
             .HasMany(s => s.Vacancies)
             .WithMany(c => c.Resumes)
             .Map(cs =>
             {
                 cs.MapLeftKey("ResumeFK");
                 cs.MapRightKey("VacansyFK");
                 cs.ToTable("ResumeVacansy");
             });
        }
    }
}

