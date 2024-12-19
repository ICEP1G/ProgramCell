using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace ProgramCell.Tests
{
    public class GameTests
    {
        [Fact]
        public void GetNextMove_Default_ReturnsAValidPlayerMove()
        {
            // Assign
            RandomPlayer aiPlayer = new('O');

            // Act
            Result<PlayerMoves> move = aiPlayer.GetNextMove();

            // Assert

        }
    }
}
