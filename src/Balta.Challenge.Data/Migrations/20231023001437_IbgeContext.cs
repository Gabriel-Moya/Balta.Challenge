using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Balta.Challenge.Data.Migrations
{
    /// <inheritdoc />
    public partial class IbgeContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IBGEcode",
                table: "Locales");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Locales",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Locales",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locales",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Locales",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "state",
                table: "Locales",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Locales",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Locales",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Locales",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "IBGEcode",
                table: "Locales",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
