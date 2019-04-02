﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Switch.Infra.Data.Context;

namespace Switch.Infra.Data.Migrations
{
    [DbContext(typeof(SwitchContext))]
    [Migration("20190402000358_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Switch.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<DateTime>("PublishDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Switch.Domain.Entities.EducationalInstitution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("GraduateYear");

                    b.Property<string>("NameInstitution")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("StillStudying");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EducationalInstitutions");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Friend", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<int>("UserFriendId");

                    b.Property<Guid?>("UserFriendId1");

                    b.HasKey("UserId", "UserFriendId");

                    b.HasIndex("UserFriendId1");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Identification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<int>("TipoDocumento");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Identifications");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentUrl");

                    b.Property<int>("GroupId");

                    b.Property<Guid?>("GroupId1");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId1");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Switch.Domain.Entities.RelationshipStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("RelationshipStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "NotSpecified"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Single"
                        },
                        new
                        {
                            Id = 3,
                            Description = "RelationShip"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Maried"
                        });
                });

            modelBuilder.Entity("Switch.Domain.Entities.SearchFor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("SearchFor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "NotSpecified"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Date"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Friendship"
                        },
                        new
                        {
                            Id = 4,
                            Description = "RelationShip"
                        });
                });

            modelBuilder.Entity("Switch.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("Mobile")
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<int?>("RelationshipStatusId");

                    b.Property<int?>("SearchForId");

                    b.Property<int>("Sexo");

                    b.HasKey("Id");

                    b.HasIndex("RelationshipStatusId");

                    b.HasIndex("SearchForId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Switch.Domain.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<int>("GroupId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid?>("GroupId1");

                    b.Property<bool>("IsAdmin");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId1");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Switch.Domain.Entities.WorkCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<bool>("CurrentJob");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime?>("OutDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkCompanies");
                });

            modelBuilder.Entity("Switch.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.EducationalInstitution", b =>
                {
                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithMany("EducationalInstitutions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Friend", b =>
                {
                    b.HasOne("Switch.Domain.Entities.User", "UserFriend")
                        .WithMany()
                        .HasForeignKey("UserFriendId1");

                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Identification", b =>
                {
                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithOne("Identification")
                        .HasForeignKey("Switch.Domain.Entities.Identification", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.Post", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId1");

                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.User", b =>
                {
                    b.HasOne("Switch.Domain.Entities.RelationshipStatus", "RelationshipStatus")
                        .WithMany()
                        .HasForeignKey("RelationshipStatusId");

                    b.HasOne("Switch.Domain.Entities.SearchFor", "SearchFor")
                        .WithMany()
                        .HasForeignKey("SearchForId");

                    b.OwnsOne("Switch.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(160)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Switch.Domain.Entities.User")
                                .WithOne("Email")
                                .HasForeignKey("Switch.Domain.ValueObjects.Email", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Switch.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasColumnType("varchar(60)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasColumnType("varchar(60)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Switch.Domain.Entities.User")
                                .WithOne("Name")
                                .HasForeignKey("Switch.Domain.ValueObjects.Name", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Switch.Domain.Entities.UserGroup", b =>
                {
                    b.HasOne("Switch.Domain.Entities.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId1");

                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Switch.Domain.Entities.WorkCompany", b =>
                {
                    b.HasOne("Switch.Domain.Entities.User", "User")
                        .WithMany("WorkCompanies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}