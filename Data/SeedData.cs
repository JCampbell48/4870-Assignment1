using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data;

public static class SeedData {
    // this is an extension to the ModelBuilder class
    public static void Seed(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasData(
            GetUsers()
        );
        modelBuilder.Entity<Article>().HasData(
            GetArticles()
        );
    }
    public static List<User> GetUsers() {
        List<User> Users = new List<User>() {
            new User() {    
                Username="a@a.a",
                Password="P@$$w0rd",
                FirstName="John",
                LastName ="Smith",
                Role="Admin",
            },
            new User() {   
            Username = "c@c.c",
            Password = "P@$$w0rd",
            FirstName = "Alice",
            LastName = "Johnson",
            Role = "Contributor",
        },
        new User() {    
            Username = "b@b.b",
            Password = "P@$$w0rd",
            FirstName = "Michael",
            LastName = "Brown",
            Role = "Contributor",
        },
        new User() {    
            Username = "d@d.d",
            Password = "P@$$w0rd",
            FirstName = "Emily",
            LastName = "Davis",
            Role = "Admin",
        },

        };

        return Users;
    }

    public static List<Article> GetArticles() {
    List<Article> Articles = new List<Article>() {
        new Article() {    // 1
            Title = "New Advances in AI",
            Body = "Artificial intelligence is evolving rapidly with new breakthroughs in deep learning...",
            StartDate = DateTime.UtcNow.AddDays(-5),
            EndDate = DateTime.UtcNow.AddDays(30),
            ContributorUsername = "c@c.c"
        },
        new Article() {    // 2
            Title = "The Future of Space Exploration",
            Body = "NASA and private companies are pushing the boundaries of space exploration...",
            StartDate = DateTime.UtcNow.AddDays(-10),
            EndDate = DateTime.UtcNow.AddDays(25),
            ContributorUsername = "b@b.b"
        },
        new Article() {    // 3
            Title = "Climate Change and Its Effects",
            Body = "Global temperatures continue to rise, leading to extreme weather patterns...",
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(45),
            ContributorUsername = "d@d.d"
        },
        new Article() {    // 4
            Title = "Top 10 Programming Languages in 2025",
            Body = "The demand for programming languages changes over time, with Python, C#, and Rust gaining popularity...",
            StartDate = DateTime.UtcNow.AddDays(-3),
            EndDate = DateTime.UtcNow.AddDays(20),
            ContributorUsername = "c@c.c"
        },
        new Article() {    // 5
            Title = "The Rise of Electric Vehicles",
            Body = "With increasing environmental concerns, electric vehicles are becoming mainstream...",
            StartDate = DateTime.UtcNow.AddDays(-7),
            EndDate = DateTime.UtcNow.AddDays(35),
            ContributorUsername = "b@b.b"
        }
    };

    return Articles;
}


}