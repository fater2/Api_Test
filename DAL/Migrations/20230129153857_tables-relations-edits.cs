using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class tablesrelationsedits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValue_CustomField1",
                table: "CustomFieldValue");

            migrationBuilder.RenameColumn(
                name: "CustomFieldId",
                table: "CustomFieldValue",
                newName: "ProductCustomFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFieldValue_CustomFieldId",
                table: "CustomFieldValue",
                newName: "IX_CustomFieldValue_ProductCustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValue_ProductCustomField",
                table: "CustomFieldValue",
                column: "ProductCustomFieldId",
                principalTable: "ProductCustomField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldValue_ProductCustomField",
                table: "CustomFieldValue");

            migrationBuilder.RenameColumn(
                name: "ProductCustomFieldId",
                table: "CustomFieldValue",
                newName: "CustomFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFieldValue_ProductCustomFieldId",
                table: "CustomFieldValue",
                newName: "IX_CustomFieldValue_CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValue_CustomField1",
                table: "CustomFieldValue",
                column: "CustomFieldId",
                principalTable: "CustomField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
