﻿// <auto-generated />
using System;
using Mathesio.Discussion.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mathesio.Discussion.DAL.Migrations
{
    [DbContext(typeof(DiscussionContext))]
    partial class DiscussionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mathesio.Discussion.DAL.Author", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(56)")
                        .HasMaxLength(56);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Mathesio.Discussion.DAL.Thread", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Threads");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Thread");
                });

            modelBuilder.Entity("Mathesio.Discussion.DAL.Comment", b =>
                {
                    b.HasBaseType("Mathesio.Discussion.DAL.Thread");

                    b.Property<Guid?>("ParentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ParentID");

                    b.HasDiscriminator().HasValue("Comment");
                });

            modelBuilder.Entity("Mathesio.Discussion.DAL.Thread", b =>
                {
                    b.HasOne("Mathesio.Discussion.DAL.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mathesio.Discussion.DAL.Comment", b =>
                {
                    b.HasOne("Mathesio.Discussion.DAL.Comment", "Parent")
                        .WithMany("ChildrenComments")
                        .HasForeignKey("ParentID");
                });
#pragma warning restore 612, 618
        }
    }
}
