﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PadelBookingContext))]
    [Migration("20250712000312_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.DataModel.ClubDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Infrastructure.DataModel.CourtDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("BasePricePerHour")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("Infrastructure.DataModel.CourtTempDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("BasePricePerHour")
                        .HasColumnType("numeric");

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CourtsTemp");
                });

            modelBuilder.Entity("Infrastructure.DataModel.CourtTempDataModel", b =>
                {
                    b.OwnsOne("Domain.Models.TimePeriod", "TimePeriod", b1 =>
                        {
                            b1.Property<Guid>("CourtTempDataModelId")
                                .HasColumnType("uuid");

                            b1.Property<TimeOnly>("End")
                                .HasColumnType("time without time zone");

                            b1.Property<TimeOnly>("Start")
                                .HasColumnType("time without time zone");

                            b1.HasKey("CourtTempDataModelId");

                            b1.ToTable("CourtsTemp");

                            b1.WithOwner()
                                .HasForeignKey("CourtTempDataModelId");
                        });

                    b.Navigation("TimePeriod")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
