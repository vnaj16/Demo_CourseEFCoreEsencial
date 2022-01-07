using Demo_CourseEFCoreEsencial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_CourseEFCoreEsencial.DbContexts
{
    public class MoviesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = DESKTOP-BMLGOC8\SQLEXPRESS; Initial Catalog = Movies; Integrated Security = true");
        }
        public MoviesDbContext()
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
