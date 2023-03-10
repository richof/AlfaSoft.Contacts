// <auto-generated />
using System;
using AlfaSoft.Contacts.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlfaSoft.Contacts.DataAccess.Migrations
{
    [DbContext(typeof(MariaDbContext))]
    [Migration("20221227204843_ALterTable_Contacts_AddColumn_IsDeleted")]
    partial class ALterTable_Contacts_AddColumn_IsDeleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Contacts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a9627009-cb7e-4524-bac2-3608d7634dfe"),
                            ContactPhone = "234321234",
                            Email = "ozzy@devil.com",
                            IsDeleted = false,
                            Name = "Ozzy Orbourne"
                        },
                        new
                        {
                            Id = new Guid("f048eeca-7402-49ce-b731-fa1005b802fe"),
                            ContactPhone = "343234546",
                            Email = "david@spidersfrommars.com",
                            IsDeleted = false,
                            Name = "David Bowie"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
