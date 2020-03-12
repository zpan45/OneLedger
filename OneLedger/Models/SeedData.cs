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
                            Price = 1M
                        },

                        new Product
                        {
                            Name = "Mini Wei Long",
                            Price = 0.5M
                        },
                        new Product
                        {
                            Name = "Da La Pian",
                            Price = 5M
                        }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
