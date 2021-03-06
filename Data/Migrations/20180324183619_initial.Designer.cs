﻿// <auto-generated />
using CourseProject.Data.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CourseProject.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180324183619_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseProject.Data.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("ConspectId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("ParentCommentId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConspectId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CourseProject.Data.Model.Conspect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SpecialityNumberId");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Conspects");
                });

            modelBuilder.Entity("CourseProject.Data.Model.ConspectTag", b =>
                {
                    b.Property<int>("ConspectId");

                    b.Property<int>("TagId");

                    b.HasKey("ConspectId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ConspectTag");
                });

            modelBuilder.Entity("CourseProject.Data.Model.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConspectId");

                    b.Property<int>("Mark");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ConspectId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("CourseProject.Data.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CourseProject.Data.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseProject.Data.Model.Comment", b =>
                {
                    b.HasOne("CourseProject.Data.Model.Conspect", "Conspect")
                        .WithMany("Comments")
                        .HasForeignKey("ConspectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseProject.Data.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CourseProject.Data.Model.Conspect", b =>
                {
                    b.HasOne("CourseProject.Data.Model.User", "User")
                        .WithMany("Conspects")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CourseProject.Data.Model.ConspectTag", b =>
                {
                    b.HasOne("CourseProject.Data.Model.Conspect", "Conspect")
                        .WithMany("ConspectTags")
                        .HasForeignKey("ConspectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseProject.Data.Model.Tag", "Tag")
                        .WithMany("ConspectTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseProject.Data.Model.Rating", b =>
                {
                    b.HasOne("CourseProject.Data.Model.Conspect")
                        .WithMany("Ratings")
                        .HasForeignKey("ConspectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseProject.Data.Model.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
