// <auto-generated />
using System;
using MeetingsApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingsApp.Migrations
{
    [DbContext(typeof(MeetingsAppContext))]
    partial class MeetingsAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetingsApp.Data.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.ItemStatus", b =>
                {
                    b.Property<int>("ItemStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemStatusId");

                    b.ToTable("ItemStatuses");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.Meeting", b =>
                {
                    b.Property<int>("MeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MeetingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MeetingTypeId")
                        .HasColumnType("int");

                    b.HasKey("MeetingId");

                    b.HasIndex("MeetingTypeId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.MeetingItem", b =>
                {
                    b.Property<int>("MeetingItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemStatusId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("MeetingItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemStatusId");

                    b.HasIndex("MeetingId");

                    b.HasIndex("StaffId");

                    b.ToTable("MeetingItems");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.MeetingType", b =>
                {
                    b.Property<int>("MeetingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingTypeId");

                    b.ToTable("MeetingTypes");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.StatusHistory", b =>
                {
                    b.Property<int>("StatusHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemStatusId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatusDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StatusHistoryId");

                    b.HasIndex("MeetingItemId");

                    b.ToTable("StatusHistory");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.Meeting", b =>
                {
                    b.HasOne("MeetingsApp.Data.Entities.MeetingType", "MeetingType")
                        .WithMany("Meetings")
                        .HasForeignKey("MeetingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeetingType");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.MeetingItem", b =>
                {
                    b.HasOne("MeetingsApp.Data.Entities.Item", "Item")
                        .WithMany("MeetingItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetingsApp.Data.Entities.ItemStatus", "ItemStatus")
                        .WithMany("MeetingItems")
                        .HasForeignKey("ItemStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetingsApp.Data.Entities.Meeting", "Meeting")
                        .WithMany("MeetingItems")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetingsApp.Data.Entities.Staff", "Staff")
                        .WithMany("MeetingItems")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ItemStatus");

                    b.Navigation("Meeting");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.StatusHistory", b =>
                {
                    b.HasOne("MeetingsApp.Data.Entities.MeetingItem", "MeetingItem")
                        .WithMany("StatusHistory")
                        .HasForeignKey("MeetingItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeetingItem");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.Item", b =>
                {
                    b.Navigation("MeetingItems");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.ItemStatus", b =>
                {
                    b.Navigation("MeetingItems");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.Meeting", b =>
                {
                    b.Navigation("MeetingItems");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.MeetingItem", b =>
                {
                    b.Navigation("StatusHistory");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.MeetingType", b =>
                {
                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("MeetingsApp.Data.Entities.Staff", b =>
                {
                    b.Navigation("MeetingItems");
                });
#pragma warning restore 612, 618
        }
    }
}
