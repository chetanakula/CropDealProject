using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CropDealProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AdminPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    CropID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.CropID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropSaleID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    CropName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CropQty = table.Column<int>(type: "int", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    Review = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserPhoneNo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    UserAddress = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserAccNo = table.Column<long>(type: "bigint", nullable: false),
                    UserIFSC = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserBankName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('Active')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProf__1788CCAC3B13F0B3", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CropOnSale",
                columns: table => new
                {
                    CropSaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropID = table.Column<int>(type: "int", nullable: true),
                    CropName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CropType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CropQty = table.Column<int>(type: "int", nullable: false),
                    CropPrice = table.Column<double>(type: "float", nullable: false),
                    FarmerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CropOnSa__DA8EB9AF0354DD7A", x => x.CropSaleID);
                    table.ForeignKey(
                        name: "fk_CropID",
                        column: x => x.CropID,
                        principalTable: "Crop",
                        principalColumn: "CropID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_FarmerID",
                        column: x => x.FarmerID,
                        principalTable: "UserProfile",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropOnSale_CropID",
                table: "CropOnSale",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_CropOnSale_FarmerID",
                table: "CropOnSale",
                column: "FarmerID");

            migrationBuilder.CreateIndex(
                name: "UQ__UserProf__01507BF2C9C34348",
                table: "UserProfile",
                column: "UserAccNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__UserProf__687B5AF54D77F64F",
                table: "UserProfile",
                column: "UserPhoneNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__UserProf__9EB2242E612265E6",
                table: "UserProfile",
                column: "UserIFSC",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CropOnSale");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
