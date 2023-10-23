﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231023200536_migracion")]
    partial class migracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Directory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Directory");
                });

            modelBuilder.Entity("WebApplication2.Models.DirectoryEmail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("directoryID")
                        .HasColumnType("integer");

                    b.Property<int>("emailID")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("directoryID");

                    b.HasIndex("emailID");

                    b.ToTable("DirectoryEmail");
                });

            modelBuilder.Entity("WebApplication2.Models.Email", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("WebApplication2.Models.DirectoryEmail", b =>
                {
                    b.HasOne("WebApplication2.Models.Directory", "directory")
                        .WithMany("directoryEmails")
                        .HasForeignKey("directoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Email", "email")
                        .WithMany("directoryEmails")
                        .HasForeignKey("emailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("directory");

                    b.Navigation("email");
                });

            modelBuilder.Entity("WebApplication2.Models.Directory", b =>
                {
                    b.Navigation("directoryEmails");
                });

            modelBuilder.Entity("WebApplication2.Models.Email", b =>
                {
                    b.Navigation("directoryEmails");
                });
#pragma warning restore 612, 618
        }
    }
}
