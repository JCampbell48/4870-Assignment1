﻿// <auto-generated />
using System;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("BlogApp.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContributorUsername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ArticleId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            Body = "Artificial intelligence is evolving rapidly with new breakthroughs in deep learning...",
                            ContributorUsername = "c@c.c",
                            CreateDate = new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "New Advances in AI"
                        },
                        new
                        {
                            ArticleId = 2,
                            Body = "NASA and private companies are pushing the boundaries of space exploration...",
                            ContributorUsername = "b@b.b",
                            CreateDate = new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Future of Space Exploration"
                        },
                        new
                        {
                            ArticleId = 3,
                            Body = "Global temperatures continue to rise, leading to extreme weather patterns...",
                            ContributorUsername = "d@d.d",
                            CreateDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Climate Change and Its Effects"
                        },
                        new
                        {
                            ArticleId = 4,
                            Body = "The demand for programming languages changes over time, with Python, C#, and Rust gaining popularity...",
                            ContributorUsername = "c@c.c",
                            CreateDate = new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Top 10 Programming Languages in 2025"
                        },
                        new
                        {
                            ArticleId = 5,
                            Body = "With increasing environmental concerns, electric vehicles are becoming mainstream...",
                            ContributorUsername = "b@b.b",
                            CreateDate = new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Rise of Electric Vehicles"
                        });
                });

            modelBuilder.Entity("BlogApp.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Username = "a@a.a",
                            FirstName = "John",
                            LastName = "Smith",
                            Password = "P@$$w0rd",
                            Role = "Admin"
                        },
                        new
                        {
                            Username = "c@c.c",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Password = "P@$$w0rd",
                            Role = "Contributor"
                        },
                        new
                        {
                            Username = "b@b.b",
                            FirstName = "Michael",
                            LastName = "Brown",
                            Password = "P@$$w0rd",
                            Role = "Contributor"
                        },
                        new
                        {
                            Username = "d@d.d",
                            FirstName = "Emily",
                            LastName = "Davis",
                            Password = "P@$$w0rd",
                            Role = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
