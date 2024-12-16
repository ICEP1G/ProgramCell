using CSharpFunctionalExtensions;
using TicTacToe;

namespace ProgramCell
{
    public interface IPlayer
    {
        Result<PlayerMoves> GetNextMove();
        char Icon { get; }
    }
}
