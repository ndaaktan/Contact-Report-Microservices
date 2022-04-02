﻿// <auto-generated />
using System;
using ContactService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ContactService.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    [Migration("20220402135717_CreateDB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ContactService.Entities.Contact", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Uuid");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactService.Entities.ContactInformation", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ContactInformationType")
                        .HasColumnType("integer");

                    b.Property<Guid>("ContactUuid")
                        .HasColumnType("uuid");

                    b.Property<string>("Information")
                        .HasColumnType("text");

                    b.HasKey("Uuid");

                    b.HasIndex("ContactUuid");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("ContactService.Entities.ContactInformation", b =>
                {
                    b.HasOne("ContactService.Entities.Contact", "Contact")
                        .WithMany("ContactInformations")
                        .HasForeignKey("ContactUuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("ContactService.Entities.Contact", b =>
                {
                    b.Navigation("ContactInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
