﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketAPI.Models;

namespace TicketAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180823213238_Ticket update")]
    partial class Ticketupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("TicketAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TicketAPI.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("TicketAPI.Models.SiteEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LongDetails");

                    b.Property<int>("PlaceId");

                    b.Property<string>("ShortDetails");

                    b.Property<double>("TicketPrice");

                    b.Property<int>("TicketsAmount");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("SiteEvents");
                });

            modelBuilder.Entity("TicketAPI.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Email");

                    b.Property<bool>("IsConfirmed");

                    b.Property<string>("Owner");

                    b.Property<double>("Price");

                    b.Property<int>("SiteEventId");

                    b.HasKey("Id");

                    b.HasIndex("SiteEventId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketAPI.Models.Place", b =>
                {
                    b.HasOne("TicketAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketAPI.Models.SiteEvent", b =>
                {
                    b.HasOne("TicketAPI.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketAPI.Models.Ticket", b =>
                {
                    b.HasOne("TicketAPI.Models.SiteEvent", "SiteEvent")
                        .WithMany("Tickets")
                        .HasForeignKey("SiteEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}