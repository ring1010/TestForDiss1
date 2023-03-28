﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestForDiss.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230325125411_change_Country")]
    partial class change_Country
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webapi.Models.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RegionsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RegionsId");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("webapi.Models.Plants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TimeZone")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("plats");
                });

            modelBuilder.Entity("webapi.Models.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlantsId")
                        .HasColumnType("integer");

                    b.Property<string>("PprodArea")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PlantsId");

                    b.ToTable("Production");
                });

            modelBuilder.Entity("webapi.Models.Regions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("regoions");
                });

            modelBuilder.Entity("webapi.Models.Countries", b =>
                {
                    b.HasOne("webapi.Models.Regions", "Regions")
                        .WithMany("Countries")
                        .HasForeignKey("RegionsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_COUNTRY_REGION");

                    b.Navigation("Regions");
                });

            modelBuilder.Entity("webapi.Models.Plants", b =>
                {
                    b.HasOne("webapi.Models.Countries", "Country")
                        .WithMany("Plants")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_PLANT_COUNTRY");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("webapi.Models.Production", b =>
                {
                    b.HasOne("webapi.Models.Plants", "Plant")
                        .WithMany("Productions")
                        .HasForeignKey("PlantsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Production_PLANT");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("webapi.Models.Countries", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("webapi.Models.Plants", b =>
                {
                    b.Navigation("Productions");
                });

            modelBuilder.Entity("webapi.Models.Regions", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
