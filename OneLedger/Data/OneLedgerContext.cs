using System;
using Microsoft.EntityFrameworkCore;
using OneLedger.Models;

namespace OneLedger.Data
{
    public class OneLedgerContext : DbContext
    {
        public OneLedgerContext(DbContextOptions<OneLedgerContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

    }
}
