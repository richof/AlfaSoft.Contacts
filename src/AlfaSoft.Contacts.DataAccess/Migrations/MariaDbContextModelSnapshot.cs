﻿// <auto-generated />
using System;
using AlfaSoft.Contacts.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlfaSoft.Contacts.DataAccess.Migrations
{
    [DbContext(typeof(MariaDbContext))]
    partial class MariaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AlfaSoft.Contacts.Business.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Contacts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d9968de0-88a9-43d6-9b6c-95417823f307"),
                            ContactPhone = "234321234",
                            Email = "ozzy@devil.com",
                            Name = "Ozzy Orbourne"
                        },
                        new
                        {
                            Id = new Guid("dc040d27-8fa9-4ebb-8ec4-c14b2fb08e03"),
                            ContactPhone = "343234546",
                            Email = "david@spidersfrommars.com",
                            Name = "David Bowie"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
