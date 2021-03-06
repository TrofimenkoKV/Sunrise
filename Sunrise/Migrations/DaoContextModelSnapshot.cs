﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sunrise.Config;

namespace sunrise.Migrations
{
    [DbContext(typeof(DaoContext))]
    partial class DaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sunrise.Database.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnName("city_name")
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Latitude")
                        .HasColumnName("latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnName("longitude")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("city");
                });
#pragma warning restore 612, 618
        }
    }
}
