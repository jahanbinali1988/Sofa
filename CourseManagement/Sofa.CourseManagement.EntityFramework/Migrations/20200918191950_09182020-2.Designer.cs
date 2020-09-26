﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sofa.CourseManagement.EntityFramework.Context;

namespace Sofa.CourseManagement.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200918191950_09182020-2")]
    partial class _091820202
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sofa.CourseManagement.Model.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RowVersion")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Institute");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("Sofa.CourseManagement.Model.LessonPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RowVersion")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_LessonPlan");

                    b.ToTable("LessonPlan");
                });

            modelBuilder.Entity("Sofa.CourseManagement.Model.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("LessonPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<int>("PostType")
                        .HasColumnType("int");

                    b.Property<int>("RowVersion")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnName("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Post");

                    b.HasIndex("LessonPlanId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Sofa.CourseManagement.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("RowVersion")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("731874e2-b89c-4509-819a-5b69396a336b"),
                            CreateDate = new DateTime(2020, 9, 18, 23, 49, 49, 475, DateTimeKind.Local).AddTicks(5188),
                            Description = "",
                            Email = "jahanbin.ali1988@gmail.com",
                            FirstName = "Ali",
                            IsActive = true,
                            LastName = "Jahanbin",
                            Level = 2,
                            ModifyDate = new DateTime(2020, 9, 18, 23, 49, 49, 476, DateTimeKind.Local).AddTicks(828),
                            PasswordHash = "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=",
                            PhoneNumber = "09224957626",
                            Role = 0,
                            RowVersion = 0,
                            UserName = "sysadmin"
                        },
                        new
                        {
                            Id = new Guid("253e472e-21ac-4864-b218-b364169d0611"),
                            CreateDate = new DateTime(2020, 9, 18, 23, 49, 49, 493, DateTimeKind.Local).AddTicks(8484),
                            Description = "",
                            Email = "jahanbinali88@yahoo.com",
                            FirstName = "Ali",
                            IsActive = true,
                            LastName = "Jahanbin",
                            Level = 2,
                            ModifyDate = new DateTime(2020, 9, 18, 23, 49, 49, 493, DateTimeKind.Local).AddTicks(8673),
                            PasswordHash = "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=",
                            PhoneNumber = "09224957626",
                            Role = 1,
                            RowVersion = 0,
                            UserName = "teacher"
                        },
                        new
                        {
                            Id = new Guid("50ecc8e1-5c5c-4a97-a5f5-af9e9eba1b70"),
                            CreateDate = new DateTime(2020, 9, 18, 23, 49, 49, 505, DateTimeKind.Local).AddTicks(3794),
                            Description = "",
                            Email = "jahanbin.ali1988@yahoo.com",
                            FirstName = "Ali",
                            IsActive = true,
                            LastName = "Jahanbin",
                            Level = 0,
                            ModifyDate = new DateTime(2020, 9, 18, 23, 49, 49, 505, DateTimeKind.Local).AddTicks(3830),
                            PasswordHash = "JB661pQ8yCirbaGKuNu8wIZjd7/lq74u5bDYUaX6GW0=",
                            PhoneNumber = "09224957626",
                            Role = 1,
                            RowVersion = 0,
                            UserName = "student"
                        });
                });

            modelBuilder.Entity("Sofa.CourseManagement.Model.Institute", b =>
                {
                    b.OwnsMany("Sofa.CourseManagement.Model.Address", "Addresses", b1 =>
                        {
                            b1.Property<Guid>("InstituteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("InstituteId", "Id");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("InstituteId");
                        });
                });

            modelBuilder.Entity("Sofa.CourseManagement.Model.Post", b =>
                {
                    b.HasOne("Sofa.CourseManagement.Model.LessonPlan", "LessonPlan")
                        .WithMany("Posts")
                        .HasForeignKey("LessonPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}