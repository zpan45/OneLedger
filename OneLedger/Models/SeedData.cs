using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneLedger.Data;

namespace OneLedger.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OneLedgerContext(
                serviceProvider.GetRequiredService<DbContextOptions<OneLedgerContext>>()))
            {
                //seed products
                if (!context.Product.Any())
                {
                    context.Product.AddRange(

                        new Product
                        {
                            Name = "Lg Wei Long",
                            Price = 1M,
                            NumOnHand = 15
                        },

                        new Product
                        {
                            Name = "Mini Wei Long",
                            Price = 0.5M,
                            NumOnHand = 25
                        },
                        new Product
                        {
                            Name = "Da La Pian",
                            Price = 5M,
                            NumOnHand = 50
                        }
                        );
                    context.SaveChanges();
                }

                //seed wallet
                if (!context.Wallet.Any())
                {
                    context.Wallet.AddRange(

                        new Wallet
                        {
                            Cash = 100
                        }

                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
