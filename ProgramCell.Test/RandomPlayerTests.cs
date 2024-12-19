using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;

namespace ProgramCell.Test
{
    public class RandomPlayerTests
    {
        [Fact]
        public void GetNextMove_Default_ReturnsAValidPlayerMove()
        {
            // Assign
            RandomPlayer aiPlayer = new('O');

            // Act
            Result<PlayerMoves> move = aiPlayer.GetNextMove();

            // Assert
            move.IsSuccess
                .Should()
                .BeTrue();

            move.Value.Row
                .Should()
                .BeInRange(1, 3);

            move.Value.Column
                .Should()
                .BeInRange(1, 3);

        }
    }
}