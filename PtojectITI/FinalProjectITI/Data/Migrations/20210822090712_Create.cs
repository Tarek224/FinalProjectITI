using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectITI.Data.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Blog_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blog_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Blog_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blog_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Blog_Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Blog_ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category_Describtion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Images_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Images_ID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Payment_ID);
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    Shipping_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shipper_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipper_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postal_Code = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Shipping_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Tag_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tag_Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Tag_ID);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Comment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Blog_ID = table.Column<int>(type: "int", nullable: false),
                    Comment_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Comment_ID);
                    table.ForeignKey(
                        name: "FK_Comment_Blog_Blog_ID",
                        column: x => x.Blog_ID,
                        principalTable: "Blog",
                        principalColumn: "Blog_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_IdentityUser_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Images_ID = table.Column<int>(type: "int", nullable: true),
                    Product_Size = table.Column<int>(type: "int", nullable: false),
                    Product_Color = table.Column<int>(type: "int", nullable: false),
                    Adding_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    Stored_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Images_Images_ID",
                        column: x => x.Images_ID,
                        principalTable: "Images",
                        principalColumn: "Images_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Shipping_ID = table.Column<int>(type: "int", nullable: true),
                    Payment_ID = table.Column<int>(type: "int", nullable: true),
                    Order_Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_Order_IdentityUser_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment_Payment_ID",
                        column: x => x.Payment_ID,
                        principalTable: "Payment",
                        principalColumn: "Payment_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Shipping_Shipping_ID",
                        column: x => x.Shipping_ID,
                        principalTable: "Shipping",
                        principalColumn: "Shipping_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    BlogTags_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blog_ID = table.Column<int>(type: "int", nullable: true),
                    Tag_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => x.BlogTags_ID);
                    table.ForeignKey(
                        name: "FK_BlogTags_Blog_Blog_ID",
                        column: x => x.Blog_ID,
                        principalTable: "Blog",
                        principalColumn: "Blog_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogTags_Tags_Tag_ID",
                        column: x => x.Tag_ID,
                        principalTable: "Tags",
                        principalColumn: "Tag_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductTags_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<int>(type: "int", nullable: true),
                    Tag_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => x.ProductTags_ID);
                    table.ForeignKey(
                        name: "FK_ProductTags_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_Tag_ID",
                        column: x => x.Tag_ID,
                        principalTable: "Tags",
                        principalColumn: "Tag_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWishList",
                columns: table => new
                {
                    UserWishList_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWishList", x => x.UserWishList_ID);
                    table.ForeignKey(
                        name: "FK_UserWishList_IdentityUser_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWishList_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetails_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Product_Quantity = table.Column<int>(type: "int", nullable: false),
                    Product_Color = table.Column<int>(type: "int", nullable: false),
                    Product_Size = table.Column<int>(type: "int", nullable: true),
                    Total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetails_ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Order",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Product",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_Blog_ID",
                table: "BlogTags",
                column: "Blog_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTags_Tag_ID",
                table: "BlogTags",
                column: "Tag_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Blog_ID",
                table: "Comment",
                column: "Blog_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Customer_ID",
                table: "Comment",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_ID",
                table: "Order",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Payment_ID",
                table: "Order",
                column: "Payment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Shipping_ID",
                table: "Order",
                column: "Shipping_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Order_ID",
                table: "OrderDetails",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Product_ID",
                table: "OrderDetails",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_ID",
                table: "Product",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Images_ID",
                table: "Product",
                column: "Images_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_Product_ID",
                table: "ProductTags",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_Tag_ID",
                table: "ProductTags",
                column: "Tag_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishList_Customer_ID",
                table: "UserWishList",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWishList_Product_ID",
                table: "UserWishList",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "UserWishList");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
