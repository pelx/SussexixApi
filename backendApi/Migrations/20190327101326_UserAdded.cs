using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendApi.Migrations
{
    public partial class UserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Notes",
            //    table: "Records");

            //migrationBuilder.RenameColumn(
            //    name: "Module",
            //    table: "Records",
            //    newName: "Segment");

            //migrationBuilder.RenameColumn(
            //    name: "Duration",
            //    table: "Records",
            //    newName: "Minuets");

            //migrationBuilder.RenameColumn(
            //    name: "Date",
            //    table: "Records",
            //    newName: "RecordDate");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Topic",
            //    table: "Records",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Teacher",
            //    table: "Records",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            //migrationBuilder.RenameColumn(
            //    name: "Segment",
            //    table: "Records",
            //    newName: "Module");

            //migrationBuilder.RenameColumn(
            //    name: "RecordDate",
            //    table: "Records",
            //    newName: "Date");

            //migrationBuilder.RenameColumn(
            //    name: "Minuets",
            //    table: "Records",
            //    newName: "Duration");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Topic",
            //    table: "Records",
            //    nullable: true,
            //    oldClrType: typeof(string));

            //migrationBuilder.AlterColumn<string>(
            //    name: "Teacher",
            //    table: "Records",
            //    nullable: true,
            //    oldClrType: typeof(string));

            //migrationBuilder.AddColumn<string>(
            //    name: "Notes",
            //    table: "Records",
            //    nullable: true);
        }
    }
}
