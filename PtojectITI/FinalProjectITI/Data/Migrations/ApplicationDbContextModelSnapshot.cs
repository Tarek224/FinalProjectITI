﻿// <auto-generated />
using System;
using FinalProjectITI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProjectITI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalProjectITI.Models.Blog", b =>
                {
                    b.Property<int>("Blog_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Blog_Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Blog_Date")
                        .HasColumnType("date");

                    b.Property<string>("Blog_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Blog_Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Blog_ID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("FinalProjectITI.Models.BlogTags", b =>
                {
                    b.Property<int>("BlogTags_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Blog_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Tag_ID")
                        .HasColumnType("int");

                    b.HasKey("BlogTags_ID");

                    b.HasIndex("Blog_ID");

                    b.HasIndex("Tag_ID");

                    b.ToTable("BlogTags");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Category", b =>
                {
                    b.Property<int>("Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_Describtion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Category_ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Comment", b =>
                {
                    b.Property<int>("Comment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Blog_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Comment_Date")
                        .HasColumnType("date");

                    b.Property<string>("Customer_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Comment_ID");

                    b.HasIndex("Blog_ID");

                    b.HasIndex("Customer_ID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Images", b =>
                {
                    b.Property<int>("Images_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Image3")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Images_ID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Order", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Order_Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Order_Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Payment_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Shipping_ID")
                        .HasColumnType("int");

                    b.HasKey("Order_ID");

                    b.HasIndex("Customer_ID");

                    b.HasIndex("Payment_ID");

                    b.HasIndex("Shipping_ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("FinalProjectITI.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetails_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<int>("Product_Color")
                        .HasColumnType("int");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<int>("Product_Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Product_Size")
                        .HasColumnType("int");

                    b.Property<decimal>("Total_price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetails_ID");

                    b.HasIndex("Order_ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Payment", b =>
                {
                    b.Property<int>("Payment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.HasKey("Payment_ID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Product", b =>
                {
                    b.Property<int>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Adding_Date")
                        .HasColumnType("date");

                    b.Property<int?>("Category_ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Images_ID")
                        .HasColumnType("int");

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.Property<int>("Product_Color")
                        .HasColumnType("int");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Product_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Product_Size")
                        .HasColumnType("int");

                    b.Property<int>("Stored_Quantity")
                        .HasColumnType("int");

                    b.HasKey("Product_ID");

                    b.HasIndex("Category_ID");

                    b.HasIndex("Images_ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FinalProjectITI.Models.ProductTags", b =>
                {
                    b.Property<int>("ProductTags_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Product_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Tag_ID")
                        .HasColumnType("int");

                    b.HasKey("ProductTags_ID");

                    b.HasIndex("Product_ID");

                    b.HasIndex("Tag_ID");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Shipping", b =>
                {
                    b.Property<int>("Shipping_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int?>("Postal_Code")
                        .HasColumnType("int");

                    b.Property<string>("Shipper_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shipper_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Shipping_ID");

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Tags", b =>
                {
                    b.Property<int>("Tag_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tag_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Tag_ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FinalProjectITI.Models.UserWishList", b =>
                {
                    b.Property<int>("UserWishList_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.HasKey("UserWishList_ID");

                    b.HasIndex("Customer_ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("UserWishList");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("FinalProjectITI.Models.BlogTags", b =>
                {
                    b.HasOne("FinalProjectITI.Models.Blog", "Blog")
                        .WithMany("BlogTags")
                        .HasForeignKey("Blog_ID");

                    b.HasOne("FinalProjectITI.Models.Tags", "Tags")
                        .WithMany("BlogTags")
                        .HasForeignKey("Tag_ID");

                    b.Navigation("Blog");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Comment", b =>
                {
                    b.HasOne("FinalProjectITI.Models.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("Blog_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Order", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectITI.Models.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("Payment_ID");

                    b.HasOne("FinalProjectITI.Models.Shipping", "Shipping")
                        .WithMany("Orders")
                        .HasForeignKey("Shipping_ID");

                    b.Navigation("Customer");

                    b.Navigation("Payment");

                    b.Navigation("Shipping");
                });

            modelBuilder.Entity("FinalProjectITI.Models.OrderDetails", b =>
                {
                    b.HasOne("FinalProjectITI.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectITI.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Product", b =>
                {
                    b.HasOne("FinalProjectITI.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("Category_ID");

                    b.HasOne("FinalProjectITI.Models.Images", "Images")
                        .WithMany("Products")
                        .HasForeignKey("Images_ID");

                    b.Navigation("Category");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("FinalProjectITI.Models.ProductTags", b =>
                {
                    b.HasOne("FinalProjectITI.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("Product_ID");

                    b.HasOne("FinalProjectITI.Models.Tags", "Tags")
                        .WithMany("ProductTags")
                        .HasForeignKey("Tag_ID");

                    b.Navigation("Product");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("FinalProjectITI.Models.UserWishList", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectITI.Models.Product", "Product")
                        .WithMany("UserWishLists")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Blog", b =>
                {
                    b.Navigation("BlogTags");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Images", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductTags");

                    b.Navigation("UserWishLists");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Shipping", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FinalProjectITI.Models.Tags", b =>
                {
                    b.Navigation("BlogTags");

                    b.Navigation("ProductTags");
                });
#pragma warning restore 612, 618
        }
    }
}
