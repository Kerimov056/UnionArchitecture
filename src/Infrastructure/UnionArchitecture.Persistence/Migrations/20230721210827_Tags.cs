using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnionArchitecture.Persistence.Migrations
{
    public partial class Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flower_Tag_Flowers_FlowersId",
                table: "Flower_Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Flower_Tag_Tags_TagsId",
                table: "Flower_Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flower_Tag",
                table: "Flower_Tag");

            migrationBuilder.DropIndex(
                name: "IX_Flower_Tag_FlowersId",
                table: "Flower_Tag");

            migrationBuilder.RenameTable(
                name: "Flower_Tag",
                newName: "Flower_Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Flower_Tag_TagsId",
                table: "Flower_Tags",
                newName: "IX_Flower_Tags_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flower_Tags",
                table: "Flower_Tags",
                columns: new[] { "FlowersId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flower_Tags_Flowers_FlowersId",
                table: "Flower_Tags",
                column: "FlowersId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flower_Tags_Tags_TagsId",
                table: "Flower_Tags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flower_Tags_Flowers_FlowersId",
                table: "Flower_Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Flower_Tags_Tags_TagsId",
                table: "Flower_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flower_Tags",
                table: "Flower_Tags");

            migrationBuilder.RenameTable(
                name: "Flower_Tags",
                newName: "Flower_Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Flower_Tags_TagsId",
                table: "Flower_Tag",
                newName: "IX_Flower_Tag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flower_Tag",
                table: "Flower_Tag",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flower_Tag_FlowersId",
                table: "Flower_Tag",
                column: "FlowersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flower_Tag_Flowers_FlowersId",
                table: "Flower_Tag",
                column: "FlowersId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flower_Tag_Tags_TagsId",
                table: "Flower_Tag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
