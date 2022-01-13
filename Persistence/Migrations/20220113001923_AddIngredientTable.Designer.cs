﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(RecipeBookContext))]
    [Migration("20220113001923_AddIngredientTable")]
    partial class AddIngredientTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.WeeklyMenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Day")
                        .HasColumnType("text");

                    b.Property<int?>("DinnerRecipeId")
                        .HasColumnType("integer");

                    b.Property<int?>("LunchRecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DinnerRecipeId");

                    b.HasIndex("LunchRecipeId");

                    b.ToTable("WeeklyMenu");
                });

            modelBuilder.Entity("Domain.Entities.WeeklyMenuItem", b =>
                {
                    b.HasOne("Domain.Entities.Recipe", "DinnerRecipe")
                        .WithMany()
                        .HasForeignKey("DinnerRecipeId");

                    b.HasOne("Domain.Entities.Recipe", "LunchRecipe")
                        .WithMany()
                        .HasForeignKey("LunchRecipeId");

                    b.Navigation("DinnerRecipe");

                    b.Navigation("LunchRecipe");
                });
#pragma warning restore 612, 618
        }
    }
}