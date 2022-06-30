using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoppingCartAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Access_Levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    access_level_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access_Levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cat_desc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    modified = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    deleted = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product_Inventories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Inventories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_login = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_login = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                    table.ForeignKey(
                        name: "FK_Admins_Access_Levels_access_level",
                        column: x => x.access_level,
                        principalTable: "Access_Levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    product_desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    inventory_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    img1_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img2_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img3_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Product_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Product_Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Product_Inventories_inventory_id",
                        column: x => x.inventory_id,
                        principalTable: "Product_Inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Details_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_Addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    address_line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shipping_Addresses_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carts_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Items_Order_Details_order_id",
                        column: x => x.order_id,
                        principalTable: "Order_Details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Items_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    payment_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    provider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_Details", x => x.id);
                    table.ForeignKey(
                        name: "FK_payment_Details_Order_Details_order_id",
                        column: x => x.order_id,
                        principalTable: "Order_Details",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_payment_Details_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_access_level",
                table: "Admins",
                column: "access_level");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_product_id",
                table: "Carts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_user_id",
                table: "Carts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_user_id",
                table: "Order_Details",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_order_id",
                table: "Order_Items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_product_id",
                table: "Order_Items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_Details_order_id",
                table: "payment_Details",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_Details_user_id",
                table: "payment_Details",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_inventory_id",
                table: "Products",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Addresses_user_id",
                table: "Shipping_Addresses",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "payment_Details");

            migrationBuilder.DropTable(
                name: "Shipping_Addresses");

            migrationBuilder.DropTable(
                name: "Access_Levels");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Product_Categories");

            migrationBuilder.DropTable(
                name: "Product_Inventories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
