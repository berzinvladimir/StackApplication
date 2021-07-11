using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackApplication.Repositories
{
    public class StackContext<T> : DbContext
    {
        public StackContext(DbContextOptions<StackContext<T>> options) : base(options)
        {
        }

        public DbSet<StackItem<T>> StackItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StackItem<NameObject>>().Ignore(c => c.Value);
        }
    }
}
