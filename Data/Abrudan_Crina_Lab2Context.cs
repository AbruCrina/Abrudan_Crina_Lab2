using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abrudan_Crina_Lab2.Models;
using Abrudan_Crina_Lab2.Models.ViewModels;

namespace Abrudan_Crina_Lab2.Data
{
    public class Abrudan_Crina_Lab2Context : DbContext
    {
        public Abrudan_Crina_Lab2Context (DbContextOptions<Abrudan_Crina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Abrudan_Crina_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Abrudan_Crina_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Abrudan_Crina_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Abrudan_Crina_Lab2.Models.Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
            .WithOne(e => e.Book)
                .HasForeignKey<Borrowing>("BookID");
        }

        public DbSet<Abrudan_Crina_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Abrudan_Crina_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
