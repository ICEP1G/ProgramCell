using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace ProgramCell
{
    public class RandomPlayer : IPlayer
    {
        public RandomPlayer(char icon)
        {
            Icon = icon;
        }

        public char Icon { get; }

        public Result<PlayerMoves> GetNextMove()
        {
            Random random = new Random();
            int randomNumberRow = random.Next(1, 4);
            int randomNumberColumn = random.Next(1, 4);

            int[]? numbers = { randomNumberRow, randomNumberColumn };

            if (numbers[0] < 1 || numbers[0] > 3)
            {
                return Result.Failure<PlayerMoves>("Invalid target cell row must be betwen 1 and 3");
            }

            if (numbers[1] < 1 || numbers[1] > 3)
            {
                return Result.Failure<PlayerMoves>("Invalid target cell column must be betwen 1 and 3");
            }

            return Result.Success(new PlayerMoves(numbers[0], numbers[1]));
        }
    }
}
