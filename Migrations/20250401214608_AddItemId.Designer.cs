﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W9_assignment_template.Data;

#nullable disable

namespace w9_assignment_ksteph.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20250401214608_AddItemId")]
    partial class AddItemId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("w9_assignment_ksteph.Models.Combat.Stats", b =>
                {
                    b.Property<int>("StatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatsId"));

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<int>("Magic")
                        .HasColumnType("int");

                    b.Property<int>("MaxHitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Movement")
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("StatsId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Dungeons.Dungeon", b =>
                {
                    b.Property<int>("DungeonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DungeonId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartingRoomRoomId")
                        .HasColumnType("int");

                    b.HasKey("DungeonId");

                    b.HasIndex("StartingRoomRoomId");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Inventories.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");

                    b.HasAnnotation("Relational:JsonPropertyName", "Inventory");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Items.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Rooms.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Units.Abstracts.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentRoomRoomId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("UnitId");

                    b.HasIndex("CurrentRoomRoomId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("StatsId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Dungeons.Dungeon", b =>
                {
                    b.HasOne("w9_assignment_ksteph.Models.Rooms.Room", "StartingRoom")
                        .WithMany()
                        .HasForeignKey("StartingRoomRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StartingRoom");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Items.Item", b =>
                {
                    b.HasOne("w9_assignment_ksteph.Models.Inventories.Inventory", "Inventory")
                        .WithMany("Items")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Units.Abstracts.Unit", b =>
                {
                    b.HasOne("w9_assignment_ksteph.Models.Rooms.Room", "CurrentRoom")
                        .WithMany("Units")
                        .HasForeignKey("CurrentRoomRoomId");

                    b.HasOne("w9_assignment_ksteph.Models.Inventories.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("w9_assignment_ksteph.Models.Combat.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentRoom");

                    b.Navigation("Inventory");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Inventories.Inventory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("w9_assignment_ksteph.Models.Rooms.Room", b =>
                {
                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}
