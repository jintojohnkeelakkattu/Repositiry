﻿// <auto-generated />
using System;
using JobMaster.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobMaster.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180606133854_NewMigration8")]
    partial class NewMigration8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobMaster.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Description");

                    b.Property<string>("Experience");

                    b.Property<int>("SalaryFrom");

                    b.Property<int>("SalaryTo");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("JobMaster.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JobMaster.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobMaster.UserDetail", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("JobMaster.UserPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("PhoneType");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhones");
                });

            modelBuilder.Entity("JobMaster.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("JobMaster.Job", b =>
                {
                    b.HasOne("JobMaster.UserDetail", "UserDetail")
                        .WithMany("Jobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobMaster.UserDetail", b =>
                {
                    b.HasOne("JobMaster.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("JobMaster.UserDetail", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobMaster.UserPhone", b =>
                {
                    b.HasOne("JobMaster.User", "User")
                        .WithMany("UserPhones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobMaster.UserRole", b =>
                {
                    b.HasOne("JobMaster.Role", "Role")
                        .WithOne("UserRole")
                        .HasForeignKey("JobMaster.UserRole", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobMaster.User", "User")
                        .WithOne("UserRole")
                        .HasForeignKey("JobMaster.UserRole", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
