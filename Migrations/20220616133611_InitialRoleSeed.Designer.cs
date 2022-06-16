﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PZ;

#nullable disable

namespace V1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220616133611_InitialRoleSeed")]
    partial class InitialRoleSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "87463c5a-795c-4df2-83a5-ef985f76c0d5",
                            ConcurrencyStamp = "a149d497-ca84-497a-a284-45ca624f2ab6",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = "ab662ea0-b950-4c0a-b9e1-cafd808bdd45",
                            ConcurrencyStamp = "d632246b-2571-4adb-be5c-1db2f6c754b8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "6d7db6be-65ee-442a-a795-b078d71c7e8b",
                            ConcurrencyStamp = "af016ff5-07c5-4b6e-88ec-318a9c10042d",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PZ.Models.Addresses", b =>
                {
                    b.Property<byte>("ID_Address")
                        .HasColumnType("smallint");

                    b.Property<long>("ID_Client")
                        .HasColumnType("bigint");

                    b.Property<int>("BlockNo")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Default")
                        .HasColumnType("boolean");

                    b.Property<int>("HouseNo")
                        .HasColumnType("integer");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Voivodeship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Address", "ID_Client");

                    b.HasIndex("ID_Client");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PZ.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PZ.Models.Brands", b =>
                {
                    b.Property<long>("ID_Brand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID_Brand"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Brand");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("PZ.Models.Clients", b =>
                {
                    b.Property<long>("ID_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID_Client"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Client");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PZ.Models.Items", b =>
                {
                    b.Property<string>("ID_Item")
                        .HasColumnType("text");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<long>("ID_Brand")
                        .HasColumnType("bigint");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("NettPrice")
                        .HasColumnType("real");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<float>("Size")
                        .HasColumnType("real");

                    b.Property<long>("Stock")
                        .HasColumnType("bigint");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("VAT")
                        .HasColumnType("real");

                    b.HasKey("ID_Item");

                    b.HasIndex("ID_Brand")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PZ.Models.OrderDates", b =>
                {
                    b.Property<long>("ID_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID_Date"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ID_Order")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("ID_Date");

                    b.HasIndex("ID_Order");

                    b.ToTable("OrderDates");
                });

            modelBuilder.Entity("PZ.Models.OrderQuantities", b =>
                {
                    b.Property<long>("ID_Order")
                        .HasColumnType("bigint");

                    b.Property<string>("ID_Item")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ID_Order", "ID_Item");

                    b.HasIndex("ID_Item");

                    b.ToTable("OrderQuantities");
                });

            modelBuilder.Entity("PZ.Models.Orders", b =>
                {
                    b.Property<long>("ID_Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID_Order"));

                    b.Property<long>("ID_Client")
                        .HasColumnType("bigint");

                    b.HasKey("ID_Order");

                    b.HasIndex("ID_Client");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PZ.Models.Pictures", b =>
                {
                    b.Property<int>("ID_Picture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Picture"));

                    b.Property<string>("ID_Item")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("ID_Picture");

                    b.HasIndex("ID_Item");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("PZ.Models.Reviews", b =>
                {
                    b.Property<long>("ID_Client")
                        .HasColumnType("bigint");

                    b.Property<string>("ID_Item")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Client", "ID_Item");

                    b.HasIndex("ID_Item");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PZ.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PZ.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PZ.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PZ.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PZ.Models.Addresses", b =>
                {
                    b.HasOne("PZ.Models.Clients", "Clients")
                        .WithMany("Addresses")
                        .HasForeignKey("ID_Client")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Addresses_Clients");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("PZ.Models.AppUser", b =>
                {
                    b.HasOne("PZ.Models.Clients", "Clients")
                        .WithOne("AppUser")
                        .HasForeignKey("PZ.Models.AppUser", "UserName")
                        .HasPrincipalKey("PZ.Models.Clients", "Login")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("PZ.Models.Items", b =>
                {
                    b.HasOne("PZ.Models.Brands", "Brands")
                        .WithOne("Items")
                        .HasForeignKey("PZ.Models.Items", "ID_Brand")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Items_Brands");

                    b.Navigation("Brands");
                });

            modelBuilder.Entity("PZ.Models.OrderDates", b =>
                {
                    b.HasOne("PZ.Models.Orders", "Orders")
                        .WithMany("OrderDates")
                        .HasForeignKey("ID_Order")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_OrderDates_Orders");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PZ.Models.OrderQuantities", b =>
                {
                    b.HasOne("PZ.Models.Items", "Items")
                        .WithMany("OrderQuantities")
                        .HasForeignKey("ID_Item")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_OrderQuantities_Items");

                    b.HasOne("PZ.Models.Orders", "Orders")
                        .WithMany("OrderQuantities")
                        .HasForeignKey("ID_Order")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_OrderQuantities_Orders");

                    b.Navigation("Items");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PZ.Models.Orders", b =>
                {
                    b.HasOne("PZ.Models.Clients", "Clients")
                        .WithMany("Orders")
                        .HasForeignKey("ID_Client")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Clients");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("PZ.Models.Pictures", b =>
                {
                    b.HasOne("PZ.Models.Items", "Items")
                        .WithMany("Pictures")
                        .HasForeignKey("ID_Item")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Pictures_Items");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("PZ.Models.Reviews", b =>
                {
                    b.HasOne("PZ.Models.Clients", "Clients")
                        .WithMany("Reviews")
                        .HasForeignKey("ID_Client")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Reviews_Clients");

                    b.HasOne("PZ.Models.Items", "Items")
                        .WithMany("Reviews")
                        .HasForeignKey("ID_Item")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Reviews_Items");

                    b.Navigation("Clients");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("PZ.Models.Brands", b =>
                {
                    b.Navigation("Items")
                        .IsRequired();
                });

            modelBuilder.Entity("PZ.Models.Clients", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("AppUser")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PZ.Models.Items", b =>
                {
                    b.Navigation("OrderQuantities");

                    b.Navigation("Pictures");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PZ.Models.Orders", b =>
                {
                    b.Navigation("OrderDates");

                    b.Navigation("OrderQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}