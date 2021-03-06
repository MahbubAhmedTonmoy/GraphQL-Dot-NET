﻿// <auto-generated />
using System;
using GQL_DOT_NET_CORE.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GQL_DOT_NET_CORE.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GQL_DOT_NET_CORE.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89a62d63-102c-4898-9410-35a47979b348"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("dee50489-98d1-4709-8762-59787df65b29"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("c58ded14-1935-4a61-8a4d-0bb9370b518d"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("501e264c-9e7d-4d6d-9035-7b05f71f3cd6"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GQL_DOT_NET_CORE.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dee50489-98d1-4709-8762-59787df65b29"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("GQL_DOT_NET_CORE.Entities.Account", b =>
                {
                    b.HasOne("GQL_DOT_NET_CORE.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
