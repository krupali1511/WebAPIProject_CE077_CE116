using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowTogether.Models
{
    public class GrowDbContext : DbContext
    {
        public GrowDbContext(DbContextOptions<GrowDbContext> options) : base(options)
        {

        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Material> Material { get; set; }
       public DbSet<Maths> Maths { get; set; }
        public DbSet<ComputerScience> computerScience { get; set; }
        public DbSet<Science> Science { get; set; }
        public DbSet<JEE> JEE { get; set; }
        public DbSet<Medical> Medical { get; set; }
        public DbSet<User> User { get; set; }


    }
}
