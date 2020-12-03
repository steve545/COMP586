using Microsoft.EntityFrameworkCore;
namespace CoreAngCombinedNew.Models
{
    public partial class BookDatabaseContext : DbContext
    {
        public BookDatabaseContext()
        {
        }

        public BookDatabaseContext(DbContextOptions<BookDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasIndex(e => e.AuthorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
