﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using my_resturant.Models;

#nullable disable

namespace my_resturant.Migrations
{
    [DbContext(typeof(resturantDbContext))]
    [Migration("20240622193142_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("my_resturant.Models.Menulist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Menulist");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fast food",
                            Name = "Pasta",
                            Price = 50m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fast food",
                            Name = "Pizza",
                            Price = 30m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fast food",
                            Name = "Burger",
                            Price = 25m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Family meal",
                            Name = "Grilled chicken with rice",
                            Price = 70m
                        });
                });

            modelBuilder.Entity("my_resturant.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MenulistId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenulistId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("my_resturant.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "roaaabuarra0@gmail.com",
                            Password = "00000",
                            username = "roaa"
                        });
                });

            modelBuilder.Entity("my_resturant.Models.Order", b =>
                {
                    b.HasOne("my_resturant.Models.Menulist", "Menulist")
                        .WithMany("Orders")
                        .HasForeignKey("MenulistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("my_resturant.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menulist");

                    b.Navigation("User");
                });

            modelBuilder.Entity("my_resturant.Models.Menulist", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("my_resturant.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
