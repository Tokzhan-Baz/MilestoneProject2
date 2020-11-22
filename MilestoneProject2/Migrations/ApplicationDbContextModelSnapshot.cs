﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilestoneProject2.Data;

namespace MilestoneProject2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MilestoneProject2.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Poster")
                        .HasColumnType("TEXT");

                    b.Property<string>("text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MilestoneProject2.Models.Investor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Poster")
                        .HasColumnType("TEXT");

                    b.Property<int>("budget")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Investors");
                });

            modelBuilder.Entity("MilestoneProject2.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Information")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("MilestoneProject2.Models.NewsN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NewsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NewsId")
                        .IsUnique();

                    b.ToTable("NewsNs");
                });

            modelBuilder.Entity("MilestoneProject2.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Poster")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MilestoneProject2.Models.Startups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AboutProject")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Poster")
                        .HasColumnType("TEXT");

                    b.Property<string>("Texts")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Startups");
                });

            modelBuilder.Entity("MilestoneProject2.Models.StartupsNews", b =>
                {
                    b.Property<int>("StartupsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NewsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StartupsId", "NewsId");

                    b.HasIndex("NewsId");

                    b.ToTable("StartupsNews");
                });

            modelBuilder.Entity("MilestoneProject2.Models.News", b =>
                {
                    b.HasOne("MilestoneProject2.Models.Projects", "Projects")
                        .WithMany("News")
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("MilestoneProject2.Models.NewsN", b =>
                {
                    b.HasOne("MilestoneProject2.Models.News", "News")
                        .WithOne("NewsN")
                        .HasForeignKey("MilestoneProject2.Models.NewsN", "NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });

            modelBuilder.Entity("MilestoneProject2.Models.StartupsNews", b =>
                {
                    b.HasOne("MilestoneProject2.Models.News", "News")
                        .WithMany("StartupsNews")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilestoneProject2.Models.Startups", "Startups")
                        .WithMany("StartupsNews")
                        .HasForeignKey("StartupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("Startups");
                });

            modelBuilder.Entity("MilestoneProject2.Models.News", b =>
                {
                    b.Navigation("NewsN");

                    b.Navigation("StartupsNews");
                });

            modelBuilder.Entity("MilestoneProject2.Models.Projects", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("MilestoneProject2.Models.Startups", b =>
                {
                    b.Navigation("StartupsNews");
                });
#pragma warning restore 612, 618
        }
    }
}
