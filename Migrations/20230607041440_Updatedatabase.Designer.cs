﻿// <auto-generated />
using APIAssignment1.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIAssignment1.Migrations
{
    [DbContext(typeof(EF_DataContext))]
    [Migration("20230607041440_Updatedatabase")]
    partial class Updatedatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("APIAssignment1.EFCore.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Emp_Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Emp_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Emp_Number")
                        .HasColumnType("integer");

                    b.Property<decimal>("Emp_Salary")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("employee");
                });
#pragma warning restore 612, 618
        }
    }
}
