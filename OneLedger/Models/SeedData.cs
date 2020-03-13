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


                //seed trans
                if (!context.Transaction.Any())
                {
                    var a = 10;
                    var p1 = context.Product.Find(1);
                    var p2 = context.Product.Find(2) == null ? p1 : context.Product.Find(2);
                    var p3 = context.Product.Find(3) == null ? p2 : context.Product.Find(3);

                    context.Transaction.AddRange(

                        new Transaction
                        {
                            Time = DateTime.Parse("1968-08-01"),
                            Product = p1,
                            Count = a,
                            PricePerUnit = p1.Price,
                            TotalCharge = a * p1.Price
                        },

                        new Transaction
                        {
                            Time = DateTime.Parse("1969-10-01"),
                            Product = p1,
                            Count = 2 * a,
                            PricePerUnit = p1.Price,
                            TotalCharge = 2 * a * p1.Price
                        },

                        new Transaction
                        {
                            Time = DateTime.Parse("1994-11-01"),
                            Product = p2,
                            Count = a,
                            PricePerUnit = p2.Price,
                            TotalCharge = a * p2.Price
                        },

                        new Transaction
                        {
                            Time = DateTime.Parse("2008-02-01"),
                            Product = p2,
                            Count = 4 * a,
                            PricePerUnit = p2.Price,
                            TotalCharge = 4 * a * p2.Price
                        },

                        new Transaction
                        {
                            Time = DateTime.Parse("1994-05-01"),
                            Product = p3,
                            Count = 5 * a,
                            PricePerUnit = p3.Price,
                            TotalCharge = 5* a * p3.Price
                        }



                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
