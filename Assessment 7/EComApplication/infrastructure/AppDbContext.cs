﻿using core.Interface;
using domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<domain.User> Users { get; set; }
        public DbSet<Otp> Otp { get; set; }

        public IDbConnection GetConnection()
        {
            return this.Database.GetDbConnection();
        }
    }
}
