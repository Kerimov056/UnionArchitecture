using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnionArchitecture.Persistence.Migrations
{
    public partial class TagsAndUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowersImages_FlowersDetails_FlowersDetailsId",
                table: "FlowersImages");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "FlowersDetails");

            migrationBuilder.RenameColumn(
                name: "FlowersDetailsId",
                table: "FlowersImages",
                newName: "FlowersId");

            migrationBuilder.RenameIndex(
                name: "IX_FlowersImages_FlowersDetailsId",
                table: "FlowersImages",
                newName: "IX_FlowersImages_FlowersId");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "FlowersImages",
                type: "nvarchar(504)",
                maxLength: 504,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PowerFlowers",
                table: "FlowersDetails",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FlowersDetails",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flowers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Flowers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flower_Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flower_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flower_Tag_Flowers_FlowersId",
                        column: x => x.FlowersId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flower_Tag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flower_Tag_FlowersId",
                table: "Flower_Tag",
                column: "FlowersId");

            migrationBuilder.CreateIndex(
                name: "IX_Flower_Tag_TagsId",
                table: "Flower_Tag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowersImages_Flowers_FlowersId",
                table: "FlowersImages",
                column: "FlowersId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowersImages_Flowers_FlowersId",
                table: "FlowersImages");

            migrationBuilder.DropTable(
                name: "Flower_Tag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.RenameColumn(
                name: "FlowersId",
                table: "FlowersImages",
                newName: "FlowersDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_FlowersImages_FlowersId",
                table: "FlowersImages",
                newName: "IX_FlowersImages_FlowersDetailsId");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "FlowersImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(504)",
                oldMaxLength: 504);

            migrationBuilder.AlterColumn<string>(
                name: "PowerFlowers",
                table: "FlowersDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FlowersDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(280)",
                oldMaxLength: 280);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "FlowersDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowersImages_FlowersDetails_FlowersDetailsId",
                table: "FlowersImages",
                column: "FlowersDetailsId",
                principalTable: "FlowersDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
