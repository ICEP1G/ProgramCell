using CSharpFunctionalExtensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace ProgramCell.Tests
{
    public class BoardTests
    {
        [Fact]
        public void InitBoard_Default_ReturnAnEmptyGrid()
        {
            // Assign
            Board board = new();

            // Act
            board.Init();

            // Assert
            board.grid.Count.Should().Be(9);
            foreach (Cell cell in board.grid)
            {
                cell.Value.Should().BeNull();
                cell.Row.Should().BeInRange(1, 3);
                cell.Column.Should().BeInRange(1, 3);
            }
        }


        public static IEnumerable<object[]> GetBoardCells(string winSchema)
        {
            switch (winSchema)
            {
                case "horizontal":
                    List<Cell> horizontalCells = new()
                    {
                        new Cell(1, 1, 'O'),
                        new Cell(1, 2, 'O'),
                        new Cell(1, 3, 'O'),
                        new Cell(2, 1),
                        new Cell(2, 2),
                        new Cell(2, 3),
                        new Cell(3, 1),
                        new Cell(3, 2),
                        new Cell(3, 3),
                    };
                    yield return new object[] { horizontalCells, winSchema };
                    break;
                case "vertical":
                    List<Cell> verticalCells = new()
                    {
                        new Cell(1, 1, 'O'),
                        new Cell(2, 1, 'O'),
                        new Cell(3, 1, 'O'),
                        new Cell(1, 2),
                        new Cell(2, 2),
                        new Cell(3, 2),
                        new Cell(1, 3),
                        new Cell(2, 3),
                        new Cell(3, 3),
                    };
                    yield return new object[] { verticalCells, winSchema };
                    break;
                case "diagonal":
                    List<Cell> diagonalCells = new()
                    {
                        new Cell(1, 1, 'O'),
                        new Cell(2, 2, 'O'),
                        new Cell(3, 3, 'O'),
                    };
                    yield return new object[] { diagonalCells, winSchema };
                    break;
                default:
                    List<Cell> WrongCells = new()
                    {
                        new Cell(1, 1, 'O'),
                        new Cell(1, 2, 'O'),
                        new Cell(3, 3, 'O'),
                    };
                    yield return new object[] { WrongCells, winSchema };
                    break;
            }
        }

        [Theory]
        [MemberData(nameof(GetBoardCells), parameters: "horizontal")]
        [MemberData(nameof(GetBoardCells), parameters: "vertical")]
        [MemberData(nameof(GetBoardCells), parameters: "diagonal")]
        [MemberData(nameof(GetBoardCells), parameters: "failed")]
        public void IsGameBoardWin_Default_ShouldReturnTrue(IEnumerable<Cell> cells, string winSchema)
        {
            // Assign
            Board board = new();

            // Act
            bool expected = board.IsGameBoardWin();

            // Assert
            if (expected == false)
            {
                winSchema.Should().BeEquivalentTo(winSchema);
            }
        }

    }
}
