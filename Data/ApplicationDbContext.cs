using System;
using System.Collections.Generic;
using System.Text;
using BoardGameLogger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGameLogger.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
