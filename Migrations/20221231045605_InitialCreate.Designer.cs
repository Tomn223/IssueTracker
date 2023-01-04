﻿// <auto-generated />
using System;
using IssueTracker.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IssueTracker.Migrations
{
    [DbContext(typeof(IssueTrackerContext))]
    [Migration("20221231045605_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("IssueManager", b =>
                {
                    b.Property<int>("IssuesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManagersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IssuesId", "ManagersId");

                    b.HasIndex("ManagersId");

                    b.ToTable("IssueManager");
                });

            modelBuilder.Entity("IssueMember", b =>
                {
                    b.Property<int>("IssuesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IssuesId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("IssueMember");
                });

            modelBuilder.Entity("IssueTracker.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("IssueTracker.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FoundAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("IssueTracker.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("IssueTracker.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("IssueTracker.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("MemberId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("IssueTracker.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ManagerMember", b =>
                {
                    b.Property<int>("ManagersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ManagersId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("ManagerMember");
                });

            modelBuilder.Entity("IssueManager", b =>
                {
                    b.HasOne("IssueTracker.Models.Issue", null)
                        .WithMany()
                        .HasForeignKey("IssuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.Manager", null)
                        .WithMany()
                        .HasForeignKey("ManagersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IssueMember", b =>
                {
                    b.HasOne("IssueTracker.Models.Issue", null)
                        .WithMany()
                        .HasForeignKey("IssuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IssueTracker.Models.Admin", b =>
                {
                    b.HasOne("IssueTracker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IssueTracker.Models.Issue", b =>
                {
                    b.HasOne("IssueTracker.Models.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("IssueTracker.Models.Manager", b =>
                {
                    b.HasOne("IssueTracker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IssueTracker.Models.Member", b =>
                {
                    b.HasOne("IssueTracker.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IssueTracker.Models.Project", b =>
                {
                    b.HasOne("IssueTracker.Models.Manager", null)
                        .WithMany("Projects")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.Member", null)
                        .WithMany("Projects")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManagerMember", b =>
                {
                    b.HasOne("IssueTracker.Models.Manager", null)
                        .WithMany()
                        .HasForeignKey("ManagersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IssueTracker.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IssueTracker.Models.Manager", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("IssueTracker.Models.Member", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("IssueTracker.Models.Project", b =>
                {
                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}
