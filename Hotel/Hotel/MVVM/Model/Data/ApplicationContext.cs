﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.MVVM.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Clients> clients { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<Reservations> reservations { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = PC-232-11\SQLEXPRESS;initial Catalog=TermPaper; User ID=U-19;Password=19$RPEe");

        }
    }
}
