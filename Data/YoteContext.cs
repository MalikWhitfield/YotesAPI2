using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class YoteContext : DbContext
    {
        public YoteContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
