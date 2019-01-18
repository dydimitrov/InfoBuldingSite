using System;
using System.Collections.Generic;
using System.Text;
using gsg.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gsg.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
