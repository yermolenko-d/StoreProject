using System.Data.Entity;
using StoreLogic.Entities;

namespace StoreLogic.Concrete
{
    public class EFDbContext : DbContext
    {
        /// <summary>
        /// Для представления строк в таблице Cakes, EF будет ползоваться моделью "Сake"
        /// </summary>
        public DbSet<Cake> Cakes { get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>().ToTable("Cakes");

            base.OnModelCreating(modelBuilder);
        }
    }
}
//fluent api entity framework