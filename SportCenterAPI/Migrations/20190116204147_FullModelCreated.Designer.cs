﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportCenterAPI.Data;

namespace SportCenterAPI.Migrations
{
    [DbContext(typeof(SportCenterDBContext))]
    [Migration("20190116204147_FullModelCreated")]
    partial class FullModelCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("CourtId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("MemberForeignKey");

                    b.Property<int?>("MemberId");

                    b.HasKey("Id");

                    b.HasAlternateKey("CourtForeignKey", "MemberForeignKey", "BookingDate");

                    b.HasIndex("CourtId");

                    b.HasIndex("MemberForeignKey");

                    b.HasIndex("MemberId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("SportCenterAPI.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SportForeignKey");

                    b.Property<int?>("SportId");

                    b.HasKey("Id");

                    b.HasIndex("SportForeignKey");

                    b.HasIndex("SportId");

                    b.ToTable("Courts");
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
                });

            modelBuilder.Entity("SportCenterAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("SportCenterAPI.Models.Administrator", b =>
                {
                    b.HasBaseType("SportCenterAPI.Models.User");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("SportCenterAPI.Models.Member", b =>
                {
                    b.HasBaseType("SportCenterAPI.Models.User");

                    b.Property<string>("Phone");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("SportCenterAPI.Models.Booking", b =>
                {
                    b.HasOne("SportCenterAPI.Models.Court")
                        .WithMany("Bookings")
                        .HasForeignKey("CourtForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportCenterAPI.Models.Court", "Court")
                        .WithMany()
                        .HasForeignKey("CourtId");

                    b.HasOne("SportCenterAPI.Models.Member")
                        .WithMany("Bookings")
                        .HasForeignKey("MemberForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportCenterAPI.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("SportCenterAPI.Models.Court", b =>
                {
                    b.HasOne("SportCenterAPI.Models.Sport")
                        .WithMany("Courts")
                        .HasForeignKey("SportForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportCenterAPI.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId");
                });
#pragma warning restore 612, 618
        }
    }
}
