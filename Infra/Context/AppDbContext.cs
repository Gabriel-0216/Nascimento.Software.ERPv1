using Domain.Entities.Buyer;
using Domain.Entities.Payments;
using Domain.Entities.Product;
using Domain.Entities.PurchaseRequest;
using Domain.Entities.Purchases;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Buyers> Buyers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CreditCartPayment> CreditCartPayments { get; set; }
        public DbSet<BoletoPayment> BoletoPayments { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Buyers>().OwnsOne(p => p.Name);
            builder.Entity<Buyers>().OwnsOne(p => p.Address);
            builder.Entity<Buyers>().OwnsMany(p => p.Emails);
            builder.Entity<Buyers>().OwnsMany(p => p.Phone);

            builder.Entity<Products>().OwnsOne(p => p.ProductName);


            builder.Entity<PurchaseProduct>().HasKey(p => new { p.ProductId, p.PurchaseId });
            
                
            
            builder.Entity<BoletoPayment>().OwnsOne(p => p.PaymentAddress);
            builder.Entity<CreditCartPayment>().OwnsOne(p => p.PaymentAddress);

            base.OnModelCreating(builder);
        }


    }
}
