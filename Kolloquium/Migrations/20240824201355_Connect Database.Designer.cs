﻿// <auto-generated />
using System;
using Kolloquium.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolloquium.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240824201355_Connect Database")]
    partial class ConnectDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolloquium.Models.Entities.Customer", b =>
                {
                    b.Property<Guid>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("c_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("c_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("c_newsletter")
                        .HasColumnType("bit");

                    b.Property<string>("c_phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("c_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Kolloquium.Models.Entities.Movie", b =>
                {
                    b.Property<Guid>("m_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("m_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("m_genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("m_releaseDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("m_showTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("m_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("m_id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Kolloquium.Models.Entities.Ticket", b =>
                {
                    b.Property<Guid>("t_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Customerc_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Moviem_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.Property<int>("m_id")
                        .HasColumnType("int");

                    b.Property<string>("t_seat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("t_id");

                    b.HasIndex("Customerc_id");

                    b.HasIndex("Moviem_id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Kolloquium.Models.Entities.Ticket", b =>
                {
                    b.HasOne("Kolloquium.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customerc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolloquium.Models.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("Moviem_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
