using System;
using System.Collections.Generic;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data;

public static class SeedData {
    // Extension method for ModelBuilder
    public static void Seed(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasData(GetUsers());
        modelBuilder.Entity<Article>().HasData(GetArticles());
    }

    public static List<User> GetUsers() {
        return new List<User>() {
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
    }

    public static List<Article> GetArticles() {
        return new List<Article>() {
            new Article() {    
                ArticleId = 1, // ✅ Changed to int
                Title = "New Advances in AI",
                Body = "Artificial intelligence is evolving rapidly with new breakthroughs in deep learning...",
                CreateDate = new DateTime(2024, 2, 10),  // ✅ Hardcoded static date
                StartDate = new DateTime(2024, 2, 5),
                EndDate = new DateTime(2024, 3, 10),
                ContributorUsername = "c@c.c"
            },
            new Article() {    
                ArticleId = 2,
                Title = "The Future of Space Exploration",
                Body = "NASA and private companies are pushing the boundaries of space exploration...",
                CreateDate = new DateTime(2024, 2, 12),
                StartDate = new DateTime(2024, 2, 2),
                EndDate = new DateTime(2024, 3, 5),
                ContributorUsername = "b@b.b"
            },
            new Article() {    
                ArticleId = 3,
                Title = "Climate Change and Its Effects",
                Body = "Global temperatures continue to rise, leading to extreme weather patterns...",
                CreateDate = new DateTime(2024, 2, 15),
                StartDate = new DateTime(2024, 2, 8),
                EndDate = new DateTime(2024, 3, 20),
                ContributorUsername = "d@d.d"
            },
            new Article() {    
                ArticleId = 4,
                Title = "Top 10 Programming Languages in 2025",
                Body = "The demand for programming languages changes over time, with Python, C#, and Rust gaining popularity...",
                CreateDate = new DateTime(2024, 2, 18),
                StartDate = new DateTime(2024, 2, 6),
                EndDate = new DateTime(2024, 3, 15),
                ContributorUsername = "c@c.c"
            },
            new Article() {    
                ArticleId = 5,
                Title = "The Rise of Electric Vehicles",
                Body = "With increasing environmental concerns, electric vehicles are becoming mainstream...",
                CreateDate = new DateTime(2024, 2, 20),
                StartDate = new DateTime(2024, 2, 10),
                EndDate = new DateTime(2024, 3, 25),
                ContributorUsername = "b@b.b"
            }
        };
    }
}
