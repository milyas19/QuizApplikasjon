using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedQuizClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetQuizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetQuizzes", x => x.QuizId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_GetQuizzes_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "GetQuizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_GetQuizzes_QuizId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "GetQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuizId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Question");
        }
    }
}
