﻿// <auto-generated />
using System;
using BeltExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeltExam.Migrations
{
    [DbContext(typeof(BeltExamContext))]
    partial class BeltExamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeltExam.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatorUserId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<string>("Length")
                        .IsRequired();

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ActivityId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("BeltExam.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("EventId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BeltExam.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeltExam.Models.Activity", b =>
                {
                    b.HasOne("BeltExam.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");
                });

            modelBuilder.Entity("BeltExam.Models.Event", b =>
                {
                    b.HasOne("BeltExam.Models.Activity", "Activity")
                        .WithMany("Events")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeltExam.Models.User", "Attendee")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
