using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication2.Models;
using Directory = WebApplication2.Models.Directory;

namespace WebApplication2.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Directory> Directory { get; set; }
    public DbSet<Email> Email { get; set; } 
    public DbSet<DirectoryEmail> DirectoryEmail { get; set; }
}