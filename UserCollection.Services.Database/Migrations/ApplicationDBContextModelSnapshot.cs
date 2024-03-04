﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserCollection.Services.Database;

#nullable disable

namespace UserCollection.Services.Database.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserCollection.Services.Database.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("UserCollection.Services.Database.Entities.CollectionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CustomBoolField1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomBoolField1State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomBoolField2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomBoolField2State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomBoolField3Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomBoolField3State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomDateTimeField1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomDateTimeField1State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomDateTimeField2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomDateTimeField2State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomDateTimeField3Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomDateTimeField3State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomIntField1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomIntField1State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomIntField2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomIntField2State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomIntField3Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomIntField3State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomStringField1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomStringField1State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomStringField2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomStringField2State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomStringField3Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomStringField3State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomTextField1Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomTextField1State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomTextField2Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomTextField2State")
                        .HasColumnType("bit");

                    b.Property<string>("CustomTextField3Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomTextField3State")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("UserCollection.Services.Database.Entities.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<bool>("CustomBoolField1Data")
                        .HasColumnType("bit");

                    b.Property<bool>("CustomBoolField2Data")
                        .HasColumnType("bit");

                    b.Property<bool>("CustomBoolField3Data")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CustomDateTimeField1Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CustomDateTimeField2Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CustomDateTimeField3Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomIntField1Data")
                        .HasColumnType("int");

                    b.Property<int>("CustomIntField2Data")
                        .HasColumnType("int");

                    b.Property<int>("CustomIntField3Data")
                        .HasColumnType("int");

                    b.Property<string>("CustomStringField1Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomStringField2Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomStringField3Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomTextField1Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomTextField2Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomTextField3Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("UserCollection.Services.Database.Entities.CollectionEntity", b =>
                {
                    b.HasOne("UserCollection.Services.Database.Entities.CategoryEntity", "Category")
                        .WithMany("UserCollections")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("UserCollection.Services.Database.Entities.ItemEntity", b =>
                {
                    b.HasOne("UserCollection.Services.Database.Entities.CollectionEntity", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("UserCollection.Services.Database.Entities.CategoryEntity", b =>
                {
                    b.Navigation("UserCollections");
                });

            modelBuilder.Entity("UserCollection.Services.Database.Entities.CollectionEntity", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
