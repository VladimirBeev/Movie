﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieTickets.Data;

#nullable disable

namespace MovieTickets.Data.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20230723152721_AddCorectImagesForProducers")]
    partial class AddCorectImagesForProducers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is the description of the first Actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-1.jpeg",
                            Name = "Actor 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is the description of the first Actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-2.jpeg",
                            Name = "Actor 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This is the description of the first Actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-3.jpeg",
                            Name = "Actor 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This is the description of the first Actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-4.jpeg",
                            Name = "Actor 4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "This is the description of the first Actor",
                            ImageUrl = "http://dotnethow.net/images/actors/actor-5.jpeg",
                            Name = "Actor 5"
                        });
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.ActorMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorMovies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            ActorId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            ActorId = 3
                        },
                        new
                        {
                            MovieId = 2,
                            ActorId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            ActorId = 4
                        },
                        new
                        {
                            MovieId = 3,
                            ActorId = 1
                        },
                        new
                        {
                            MovieId = 3,
                            ActorId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            ActorId = 5
                        },
                        new
                        {
                            MovieId = 4,
                            ActorId = 2
                        },
                        new
                        {
                            MovieId = 4,
                            ActorId = 3
                        },
                        new
                        {
                            MovieId = 4,
                            ActorId = 4
                        },
                        new
                        {
                            MovieId = 5,
                            ActorId = 2
                        },
                        new
                        {
                            MovieId = 5,
                            ActorId = 3
                        },
                        new
                        {
                            MovieId = 5,
                            ActorId = 4
                        },
                        new
                        {
                            MovieId = 5,
                            ActorId = 5
                        },
                        new
                        {
                            MovieId = 6,
                            ActorId = 3
                        },
                        new
                        {
                            MovieId = 6,
                            ActorId = 4
                        },
                        new
                        {
                            MovieId = 6,
                            ActorId = 5
                        });
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Sofia",
                            Country = "Bulgaria",
                            Description = "This is my first Cinema in Sofia",
                            LogoUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Name = "Cinema Sofiq",
                            Street = "ul.Bulgaria 10"
                        },
                        new
                        {
                            Id = 2,
                            City = "Plovdiv",
                            Country = "Bulgaria",
                            Description = "This is my first Cinema in Plovdiv",
                            LogoUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Name = "Cinema Plovdiv",
                            Street = "ul.Plovdiv 10"
                        },
                        new
                        {
                            Id = 3,
                            City = "Varna",
                            Country = "Bulgaria",
                            Description = "This is my first Cinema in Varna",
                            LogoUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Name = "Cinema Varna",
                            Street = "ul.Varna 10"
                        },
                        new
                        {
                            Id = 4,
                            City = "Burgas",
                            Country = "Bulgaria",
                            Description = "This is my first Cinema in Burgas",
                            LogoUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Name = "Cinema Burgas",
                            Street = "ul.Burgas 10"
                        },
                        new
                        {
                            Id = 5,
                            City = "Smolyan",
                            Country = "Bulgaria",
                            Description = "This is my first Cinema in Smolyan",
                            LogoUrl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Name = "Cinema Smolyan",
                            Street = "ul.Smolyan 10"
                        });
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("MovieCategory")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CinemaId = 3,
                            Description = "This is the Life movie description",
                            EndDate = new DateTime(2023, 8, 2, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3771),
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            MovieCategory = 4,
                            Price = 39m,
                            ProducerId = 3,
                            StartDate = new DateTime(2023, 7, 13, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3733),
                            Title = "Life"
                        },
                        new
                        {
                            Id = 2,
                            CinemaId = 1,
                            Description = "This is the Shawshank Redemption movie description",
                            EndDate = new DateTime(2023, 7, 26, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3781),
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            MovieCategory = 1,
                            Price = 29m,
                            ProducerId = 1,
                            StartDate = new DateTime(2023, 7, 23, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3778),
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = 3,
                            CinemaId = 4,
                            Description = "This is the Ghost movie description",
                            EndDate = new DateTime(2023, 7, 30, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3787),
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            MovieCategory = 7,
                            Price = 19m,
                            ProducerId = 4,
                            StartDate = new DateTime(2023, 7, 23, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3785),
                            Title = "Ghost"
                        },
                        new
                        {
                            Id = 4,
                            CinemaId = 1,
                            Description = "This is the Race movie description",
                            EndDate = new DateTime(2023, 7, 18, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3794),
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            MovieCategory = 4,
                            Price = 49m,
                            ProducerId = 2,
                            StartDate = new DateTime(2023, 7, 13, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3791),
                            Title = "Race"
                        },
                        new
                        {
                            Id = 5,
                            CinemaId = 1,
                            Description = "This is the Scoob movie description",
                            EndDate = new DateTime(2023, 7, 21, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3799),
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            MovieCategory = 2,
                            Price = 59m,
                            ProducerId = 3,
                            StartDate = new DateTime(2023, 7, 13, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3797),
                            Title = "Scoob"
                        },
                        new
                        {
                            Id = 6,
                            CinemaId = 1,
                            Description = "This is the Cold Soles movie description",
                            EndDate = new DateTime(2023, 8, 12, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3810),
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            MovieCategory = 3,
                            Price = 79m,
                            ProducerId = 5,
                            StartDate = new DateTime(2023, 7, 26, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3808),
                            Title = "Cold Soles"
                        });
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Producers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is the description of the first Producer",
                            ImageUrl = "http://dotnethow.net/images/producers/producer-1.jpeg",
                            Name = "Producer 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is the description of the Second Producer",
                            ImageUrl = "http://dotnethow.net/images/producers/producer-2.jpeg",
                            Name = "Producer 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This is the description of the thurd Producer",
                            ImageUrl = "http://dotnethow.net/images/producers/producer-3.jpeg",
                            Name = "Producer 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This is the description of the forth Producer",
                            ImageUrl = "http://dotnethow.net/images/producers/producer-4.jpeg",
                            Name = "Producer 4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "This is the description of the fifth Producer",
                            ImageUrl = "http://dotnethow.net/images/producers/producer-5.jpeg",
                            Name = "Producer 5"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.ActorMovie", b =>
                {
                    b.HasOne("MovieTickets.Data.EntityModels.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTickets.Data.EntityModels.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Movie", b =>
                {
                    b.HasOne("MovieTickets.Data.EntityModels.Cinema", "Cinema")
                        .WithMany("Movies")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTickets.Data.EntityModels.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Cinema", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Movie", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("MovieTickets.Data.EntityModels.Producer", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}