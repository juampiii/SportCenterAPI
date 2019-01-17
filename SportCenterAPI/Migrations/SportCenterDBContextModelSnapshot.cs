﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportCenterAPI.Data;

namespace SportCenterAPI.Migrations
{
    [DbContext(typeof(SportCenterDBContext))]
    partial class SportCenterDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportCenterAPI.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<int>("CourtForeignKey");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("MemberForeignKey");

                    b.HasKey("Id");

                    b.HasAlternateKey("CourtForeignKey", "MemberForeignKey", "BookingDate");

                    b.HasIndex("MemberForeignKey");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingDate = new DateTime(2019, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            CourtForeignKey = 2,
                            CreatedDate = new DateTime(2019, 1, 17, 11, 22, 25, 561, DateTimeKind.Local).AddTicks(583),
                            MemberForeignKey = 2
                        },
                        new
                        {
                            Id = 2,
                            BookingDate = new DateTime(2019, 1, 17, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            CourtForeignKey = 3,
                            CreatedDate = new DateTime(2019, 1, 17, 11, 22, 25, 562, DateTimeKind.Local).AddTicks(8592),
                            MemberForeignKey = 3
                        });
                });

            modelBuilder.Entity("SportCenterAPI.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SportForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("SportForeignKey");

                    b.ToTable("Courts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Padel Court 1",
                            SportForeignKey = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Padel Court 2",
                            SportForeignKey = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Futbol Court 1",
                            SportForeignKey = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Futbol Court 2",
                            SportForeignKey = 2
                        });
                });

            modelBuilder.Entity("SportCenterAPI.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Padel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Futbol"
                        });
                });

            modelBuilder.Entity("SportCenterAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("SportCenterAPI.Models.Administrator", b =>
                {
                    b.HasBaseType("SportCenterAPI.Models.User");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            Password = "12341234"
                        });
                });

            modelBuilder.Entity("SportCenterAPI.Models.Member", b =>
                {
                    b.HasBaseType("SportCenterAPI.Models.User");

                    b.Property<string>("Phone");

                    b.HasDiscriminator().HasValue("Member");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Member1",
                            Password = "12341234"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Member2",
                            Password = "12341234"
                        });
                });

            modelBuilder.Entity("SportCenterAPI.Models.Booking", b =>
                {
                    b.HasOne("SportCenterAPI.Models.Court", "Court")
                        .WithMany("Bookings")
                        .HasForeignKey("CourtForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportCenterAPI.Models.Member", "Member")
                        .WithMany("Bookings")
                        .HasForeignKey("MemberForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportCenterAPI.Models.Court", b =>
                {
                    b.HasOne("SportCenterAPI.Models.Sport", "Sport")
                        .WithMany("Courts")
                        .HasForeignKey("SportForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
