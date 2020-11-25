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
                /*entity.Property(e => e.AuthorId).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);*/
            });

            /*modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.HasIndex(e => e.AuthorId);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId);*/
                /*entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Authors");
            });*/

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
