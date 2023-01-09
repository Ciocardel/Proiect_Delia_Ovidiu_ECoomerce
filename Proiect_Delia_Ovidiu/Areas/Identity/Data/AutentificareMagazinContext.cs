using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Proiect_Delia_Ovidiu.Models;

namespace Proiect_Delia_Ovidiu.Data;

public class AutentificareMagazinContext : IdentityDbContext<IdentityUser>
{
    public AutentificareMagazinContext(DbContextOptions<AutentificareMagazinContext> options)
        : base(options)
    {
    }

    public DbSet<Produs> Produse { get; set; }
    public DbSet<Categorie> Categorii { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Cos> Cosuri { get; set; }
    public DbSet<CosProdus> CosProduse { get; set; }
    public DbSet<CategorieProdus> CategorieProdus { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Produs>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasMany(x => x.CategorieProdus).WithOne(x => x.Produs).HasForeignKey(x=>x.ProdusId);
            x.HasOne(x => x.Brand).WithMany(x=>x.Produs).HasForeignKey(x=>x.BrandId);
        });



        builder.Entity<Categorie>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasMany(x => x.CategorieProduse).WithOne(x => x.Categorie).HasForeignKey(x=>x.CategorieId);
        });


        builder.Entity<Cos>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasMany(x => x.CosProduse).WithOne(x => x.Cos).HasForeignKey(x=>x.CosId);
        });


        


        builder.Entity<CosProdus>(x =>
        {
            x.HasKey(x => x.Id);
            x.HasOne(x => x.Produs).WithMany(x => x.CosProduse).HasForeignKey(x => x.ProdusId);
        });


        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
