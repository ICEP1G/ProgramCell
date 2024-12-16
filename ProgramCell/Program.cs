﻿using CSharpFunctionalExtensions;
using System;
using System.Data.Common;

namespace TicTacToe;

internal class Program
{
    const char PlayerOne = 'O';
    const char PlayerTwo = 'X';

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toc");

        List<Cell> grid = new List<Cell>()
        {
            Cell.EmptyCell(1, 1),
            Cell.EmptyCell(1, 2),
            Cell.EmptyCell(1, 3),
            Cell.EmptyCell(2, 1),
            Cell.EmptyCell(2, 2),
            Cell.EmptyCell(2, 3),
            Cell.EmptyCell(3, 1),
            Cell.EmptyCell(3, 2),
            Cell.EmptyCell(3, 3),
        };
        char currentPlayer = PlayerOne;

        DisplayGameBoard(grid);
        while (true)
        {
            try
            {
                Console.WriteLine("To quit the game press 'q'");
                Console.WriteLine($"Player {currentPlayer} - Enter a row number between 1 to 3");
                string? inputRow = Console.ReadLine();
                Console.WriteLine($"Player {currentPlayer} - Enter a column number between 1 to 3");
                string? inputColumn = Console.ReadLine();

                if (inputRow == "q" || inputColumn == "q")
                    break;

                int rowInput = VerifyUserInput(inputRow);
                int ColumnInput = VerifyUserInput(inputColumn);
                if (rowInput == 0 || ColumnInput == 0)
                {
                    Console.WriteLine("At least one input is outside of it's range or is not even a number");
                    continue;
                }

                bool movePlayedSuccessfully = PlayOnGameBoard(grid, rowInput, ColumnInput, currentPlayer);
                if (movePlayedSuccessfully is false)
                {
                    Console.WriteLine("Invalid move");
                    continue;
                }

                Console.Clear();
                DisplayGameBoard(grid);

                if (IsGameBoardWin(grid))
                {
                    Console.WriteLine($"Player {currentPlayer} has won the game !!!!");
                    break;
                }
                if (IsGameBoardFull(grid))
                {
                    Console.WriteLine($"It's a draw");
                    break;
                }

                currentPlayer = currentPlayer == PlayerOne ? PlayerTwo : PlayerOne;

            }
            catch (Exception)
            {
                Console.WriteLine("A problem was encountered, it's possible that the input entered doesn't corresponding to the requirement. Try again");
                continue;
            }
        }
    }

    private static int VerifyUserInput(string? input)
    {
        if (int.TryParse(input, out int target) is false || target < 1 || target > 3)
            return 0;

        return target;
    }


    private static void DisplayGameBoard(List<Cell> grid)
    {
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.WriteLine(".NET MAUI".PadLeft(Console.WindowWidth / 2));
        Console.WriteLine(new string('=', Console.WindowWidth));

        Console.WriteLine($"|-----------------|");
        DisplayGameBoardLine(GetCellContent(grid, 1, 1), GetCellContent(grid, 1, 2), GetCellContent(grid, 1, 3));
        Console.WriteLine($"|-----|-----|-----|");
        DisplayGameBoardLine(GetCellContent(grid, 2, 1), GetCellContent(grid, 2, 2), GetCellContent(grid, 2, 3));
        Console.WriteLine($"|-----|-----|-----|");
        DisplayGameBoardLine(GetCellContent(grid, 3, 1), GetCellContent(grid, 3, 2), GetCellContent(grid, 3, 3));
        Console.WriteLine($"|-----------------|");
    }

    private static Cell? GetCell(List<Cell> grid, int row, int column)
        => grid
            .Where(cell => cell.Row == row)
            .Where(cell => cell.Column == column)
            .FirstOrDefault();

    private static char GetCellContent(List<Cell> grid, int row, int column)
        => GetCell(grid, row, column)?.Value ?? ' ';

    private static void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
    {
        Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");
    }

    private static bool PlayOnGameBoard(List<Cell> grid, int targetRow, int targetColumn, char currentPlayer)
    {
        Cell? cell = GetCell(grid, targetRow, targetColumn);

        if (cell == null || cell.Value == PlayerOne || cell.Value == PlayerTwo)
            return false;

        cell.UpdateValue(currentPlayer);
        return true;
    }

    public static bool IsGameBoardWin(List<Cell> grid)
    {
        IEnumerable<IGrouping<int, Cell>> rows = grid
            .GroupBy(cell => cell.Row);

        if (rows.Any(row => row.All(cell => cell.Value == PlayerOne) || row.All(cell => cell.Value == PlayerTwo)))
            return true;

        IEnumerable<IGrouping<int, Cell>> columns = grid
            .GroupBy(cell => cell.Column);

        if (columns.Any(column => column.All(cell => cell.Value == PlayerOne) || column.All(cell => cell.Value == PlayerTwo)))
            return true;

        IEnumerable<Cell> firstDiagonal = grid.Where(c => c.Row == c.Column);
        IEnumerable<Cell> secondDiagonal = grid.Where(c => (c.Row + c.Column) == 4);

        var diagonals = new List<IEnumerable<Cell>> { firstDiagonal, secondDiagonal };

        if (diagonals.Any(diagonal => diagonal.All(cell => cell.Value == PlayerOne) || diagonal.All(cell => cell.Value == PlayerTwo)))
            return true;

        return false;
    }

    private static bool IsGameBoardFull(List<Cell> grid)
        => grid.All(cell => cell.Value.HasValue);

}
