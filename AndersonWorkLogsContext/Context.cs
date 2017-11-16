using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AndersonWorkLogsEntity;

namespace AndersonWorkLogsContext
{
    public class Context : DbContext
    {
        public Context() : base("AndersonWorkLogs")
        {
            if (Database.Exists())
            {
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<EWorkingHours> WorkingHours { get; set; }

    }
}
