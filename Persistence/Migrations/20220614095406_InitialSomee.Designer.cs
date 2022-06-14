﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(PostsDbContext))]
    [Migration("20220614095406_InitialSomee")]
    partial class InitialSomee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.EmailSubscription", b =>
                {
                    b.Property<Guid>("User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("User");

                    b.ToTable("EmailSubscriptions");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Audience")
                        .HasColumnType("int");

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostID");

                    b.HasIndex("Audience");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.PostAudienceGroup", b =>
                {
                    b.Property<int>("AudienceGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudienceGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyFilter")
                        .HasColumnType("int");

                    b.Property<int>("GenerationFilter")
                        .HasColumnType("int");

                    b.Property<int>("RoleFilter")
                        .HasColumnType("int");

                    b.HasKey("AudienceGroupID");

                    b.ToTable("AudienceGroups");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.HasOne("Domain.PostAudienceGroup", "AudienceGroup")
                        .WithMany("Posts")
                        .HasForeignKey("Audience")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AudienceGroup");
                });

            modelBuilder.Entity("Domain.PostAudienceGroup", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}