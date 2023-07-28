using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilgiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dask",
                columns: table => new
                {
                    PolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanzimTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBaslangic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dask", x => x.PolId);
                });

            migrationBuilder.CreateTable(
                name: "Kasko",
                columns: table => new
                {
                    PolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanzimTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBaslangic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: false),
                    Aracmodel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aracmarka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasko", x => x.PolId);
                });

            migrationBuilder.CreateTable(
                name: "Policeler",
                columns: table => new
                {
                    PoliceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceGrup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SonTarih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliceDetay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KulId = table.Column<int>(type: "int", nullable: false),
                    TanzimTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBaslangic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teminatlar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SigortalananMulkiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policeler", x => x.PoliceId);
                });

            migrationBuilder.CreateTable(
                name: "Saglik",
                columns: table => new
                {
                    PolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanzimTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBaslangic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: false),
                    sagliksigorta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saglik", x => x.PolId);
                });

            migrationBuilder.CreateTable(
                name: "Trafik",
                columns: table => new
                {
                    PolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanzimTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBaslangic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VadeBitis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: false),
                    PlakaIlKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlakaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trafik", x => x.PolId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilgiler");

            migrationBuilder.DropTable(
                name: "Dask");

            migrationBuilder.DropTable(
                name: "Kasko");

            migrationBuilder.DropTable(
                name: "Policeler");

            migrationBuilder.DropTable(
                name: "Saglik");

            migrationBuilder.DropTable(
                name: "Trafik");
        }
    }
}
