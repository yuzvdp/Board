using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class advert_title_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Adverts",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CreatedAt_Id",
                table: "Adverts",
                columns: new[] { "CreatedAt", "Id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adverts_CreatedAt_Id",
                table: "Adverts");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Adverts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);
        }
    }
}
