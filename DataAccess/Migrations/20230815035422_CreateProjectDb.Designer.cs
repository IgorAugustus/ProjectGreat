﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(LeaveDbContext))]
    [Migration("20230815035422_CreateProjectDb")]
    partial class CreateProjectDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Model.ClassLeave", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("ClassLeaves");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            Name = "Class .NET01"
                        },
                        new
                        {
                            ClassId = 2,
                            Name = "Class .NET02"
                        },
                        new
                        {
                            ClassId = 3,
                            Name = "Class .JAVA01"
                        },
                        new
                        {
                            ClassId = 4,
                            Name = "Class .JAVA02"
                        });
                });

            modelBuilder.Entity("DataAccess.Model.LeaveType", b =>
                {
                    b.Property<int>("LeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveId"));

                    b.Property<string>("LeaveName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveId");

                    b.ToTable("LeaveTypes");

                    b.HasData(
                        new
                        {
                            LeaveId = 1,
                            LeaveName = "Late Coming"
                        },
                        new
                        {
                            LeaveId = 2,
                            LeaveName = "Early Leave"
                        },
                        new
                        {
                            LeaveId = 3,
                            LeaveName = "Leave a haft of day"
                        },
                        new
                        {
                            LeaveId = 4,
                            LeaveName = "Leave one day"
                        });
                });

            modelBuilder.Entity("DataAccess.Model.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeaveId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("LeaveId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            ClassId = 1,
                            LeaveDate = new DateTime(2019, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveId = 1,
                            Reason = "No way",
                            Status = "Nothing",
                            StudentName = "Phan Anh",
                            Title = "AAA"
                        },
                        new
                        {
                            StudentId = 2,
                            ClassId = 2,
                            LeaveDate = new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveId = 2,
                            Reason = "No way",
                            Status = "Nothing",
                            StudentName = "La Tuan",
                            Title = "AAC"
                        },
                        new
                        {
                            StudentId = 3,
                            ClassId = 3,
                            LeaveDate = new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveId = 2,
                            Reason = "No way",
                            Status = "Nothing",
                            StudentName = "Ton Nguyen",
                            Title = "BBB"
                        },
                        new
                        {
                            StudentId = 4,
                            ClassId = 4,
                            LeaveDate = new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveId = 3,
                            Reason = "No way",
                            Status = "Nothing",
                            StudentName = "Luu Bi",
                            Title = "CCC"
                        },
                        new
                        {
                            StudentId = 5,
                            ClassId = 1,
                            LeaveDate = new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveId = 4,
                            Reason = "No money",
                            Status = "Nothing",
                            StudentName = "Tao Thao",
                            Title = "DDD"
                        },
                        new
                        {
                            StudentId = 6,
                            ClassId = 4,
                            LeaveDate = new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaveId = 3,
                            Reason = "No time",
                            Status = "Nothing",
                            StudentName = "Bang Thong",
                            Title = "EEE"
                        });
                });

            modelBuilder.Entity("DataAccess.Model.Student", b =>
                {
                    b.HasOne("DataAccess.Model.ClassLeave", "ClassLeave")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Model.LeaveType", "LeaveType")
                        .WithMany("Students")
                        .HasForeignKey("LeaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassLeave");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("DataAccess.Model.ClassLeave", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DataAccess.Model.LeaveType", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
