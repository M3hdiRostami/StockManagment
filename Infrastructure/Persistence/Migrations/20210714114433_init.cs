using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalKodu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MalAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STk", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemTur = table.Column<short>(type: "smallint", nullable: false),
                    EvrakNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Tarih = table.Column<int>(type: "int", nullable: false),
                    MalID = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(25,6)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(25,6)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(25,6)", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STI", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STI_STk_MalID",
                        column: x => x.MalID,
                        principalTable: "STk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STI_MalID",
                table: "STI",
                column: "MalID");

            migrationBuilder.CreateIndex(
                name: "IX_STk_MalKodu",
                table: "STk",
                column: "MalKodu",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STI");

            migrationBuilder.DropTable(
                name: "STk");
        }
    }
}
