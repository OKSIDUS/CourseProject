using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserCollection.Services.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomIntField1State = table.Column<bool>(type: "bit", nullable: false),
                    CustomIntField1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomIntField2State = table.Column<bool>(type: "bit", nullable: false),
                    CustomIntField2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomIntField3State = table.Column<bool>(type: "bit", nullable: false),
                    CustomIntField3Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomStringField1State = table.Column<bool>(type: "bit", nullable: false),
                    CustomStringField1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomStringField2State = table.Column<bool>(type: "bit", nullable: false),
                    CustomStringField2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomStringField3State = table.Column<bool>(type: "bit", nullable: false),
                    CustomStringField3Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTextField1State = table.Column<bool>(type: "bit", nullable: false),
                    CustomTextField1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTextField2State = table.Column<bool>(type: "bit", nullable: false),
                    CustomTextField2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTextField3State = table.Column<bool>(type: "bit", nullable: false),
                    CustomTextField3Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDateTimeField1State = table.Column<bool>(type: "bit", nullable: false),
                    CustomDateTimeField1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDateTimeField2State = table.Column<bool>(type: "bit", nullable: false),
                    CustomDateTimeField2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDateTimeField3State = table.Column<bool>(type: "bit", nullable: false),
                    CustomDateTimeField3Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomBoolField1State = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomBoolField2State = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomBoolField3State = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField3Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CustomIntField1Data = table.Column<int>(type: "int", nullable: false),
                    CustomIntField2Data = table.Column<int>(type: "int", nullable: false),
                    CustomIntField3Data = table.Column<int>(type: "int", nullable: false),
                    CustomStringField1Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomStringField2Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomStringField3Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTextField1Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTextField2Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomTextField3Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDateTimeField1Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomDateTimeField2Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomDateTimeField3Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomBoolField1Data = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField2Data = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField3Data = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionId",
                table: "Items",
                column: "CollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
