using Microsoft.EntityFrameworkCore;
using Services_Repos.Models.Data_Classes;

namespace Services_Repos.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

            entity.HasOne(d => d.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId);
        });
   
}
