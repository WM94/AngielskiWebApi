namespace Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Words> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Words>()
                .Property(e => e.PolishValue)
                .IsUnicode(false);

            modelBuilder.Entity<Words>()
                .Property(e => e.EnglishValue)
                .IsUnicode(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
                                                                                                 