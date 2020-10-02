using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedQuizClass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_GetQuizzes_QuizId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetQuizzes",
                table: "GetQuizzes");

            migrationBuilder.RenameTable(
                name: "GetQuizzes",
                newName: "Quiz");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.RenameTable(
                name: "Quiz",
                newName: "GetQuizzes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetQuizzes",
                table: "GetQuizzes",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_GetQuizzes_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "GetQuizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
