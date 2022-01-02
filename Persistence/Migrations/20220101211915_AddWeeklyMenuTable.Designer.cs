﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(RecipeBookContext))]
    [Migration("20220101211915_AddWeeklyMenuTable")]
    partial class AddWeeklyMenuTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Domain.Entities.WeeklyMenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Day")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DinnerRecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LunchRecipeId")
                        .HasColumnType("INTEGER");

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