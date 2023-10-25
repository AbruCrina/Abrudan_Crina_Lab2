using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abrudan_Crina_Lab2.Models;

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
    }
}
