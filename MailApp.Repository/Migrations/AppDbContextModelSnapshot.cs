﻿// <auto-generated />
using System;
using MailApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MailApp.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MailApp.Core.Model.EmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("MailApp.Core.Model.EmailLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(20000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmailAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(20000)");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddressId");

                    b.ToTable("EmailLogs");
                });

            modelBuilder.Entity("MailApp.Core.Model.EmailLog", b =>
                {
                    b.HasOne("MailApp.Core.Model.EmailAddress", "EmailAddress")
                        .WithMany("EmailLogs")
                        .HasForeignKey("EmailAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailAddress");
                });

            modelBuilder.Entity("MailApp.Core.Model.EmailAddress", b =>
                {
                    b.Navigation("EmailLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
