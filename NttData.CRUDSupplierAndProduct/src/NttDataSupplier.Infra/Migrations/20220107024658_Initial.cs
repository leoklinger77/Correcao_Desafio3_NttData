using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NttDataSupplier.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(256)", nullable: true),
                    Discriminator = table.Column<string>(type: "varchar(256)", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(256)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(type: "varchar(256)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(12)", nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    Street = table.Column<string>(type: "varchar(256)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(256)", nullable: true),
                    Reference = table.Column<string>(type: "varchar(256)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(256)", nullable: true),
                    City = table.Column<string>(type: "varchar(256)", nullable: false),
                    State = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Address_TB_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TB_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<Guid>(nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Email_TB_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TB_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<Guid>(nullable: false),
                    Ddd = table.Column<string>(type: "char(2)", nullable: false),
                    Number = table.Column<string>(type: "varchar(9)", nullable: false),
                    PhoneType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Phone_TB_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TB_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    BarCode = table.Column<string>(type: "varchar(14)", nullable: false),
                    QuantityStock = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PriceSales = table.Column<decimal>(nullable: false),
                    PricePurchase = table.Column<decimal>(nullable: false),
                    SupplierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Product_TB_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_Product_TB_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "TB_Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Image_TB_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Address_SupplierId",
                table: "TB_Address",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Email_SupplierId",
                table: "TB_Email",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Image_ProductId",
                table: "TB_Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Phone_SupplierId",
                table: "TB_Phone",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Product_CategoryId",
                table: "TB_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Product_SupplierId",
                table: "TB_Product",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Address");

            migrationBuilder.DropTable(
                name: "TB_Email");

            migrationBuilder.DropTable(
                name: "TB_Image");

            migrationBuilder.DropTable(
                name: "TB_Phone");

            migrationBuilder.DropTable(
                name: "TB_Product");

            migrationBuilder.DropTable(
                name: "TB_Category");

            migrationBuilder.DropTable(
                name: "TB_Supplier");
        }
    }
}
