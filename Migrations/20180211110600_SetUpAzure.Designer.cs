﻿// <auto-generated />
using Brezelapp.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace privatebrezelapp.Migrations
{
    [DbContext(typeof(BrezelMSSqlContext))]
    [Migration("20180211110600_SetUpAzure")]
    partial class SetUpAzure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Brezelapp.Models.Brezel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Price");

                    b.Property<int>("Rating");

                    b.Property<int?>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Brezels");
                });

            modelBuilder.Entity("Brezelapp.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Brezelapp.Models.Brezel", b =>
                {
                    b.HasOne("Brezelapp.Models.Store", "Store")
                        .WithMany("Brezels")
                        .HasForeignKey("StoreId");
                });
#pragma warning restore 612, 618
        }
    }
}
