using System;
using Microsoft.EntityFrameworkCore;
using CasaMiro.frontend.Models;

namespace CasaMiro.frontend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

}
