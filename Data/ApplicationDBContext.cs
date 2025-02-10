using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}


    public DbSet<Article>? Articles { get; set; }
    public DbSet<User>? Users { get; set; }
}
