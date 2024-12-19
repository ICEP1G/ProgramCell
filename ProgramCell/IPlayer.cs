using CSharpFunctionalExtensions;
using TicTacToe;

namespace ProgramCell
{
    public interface IPlayer
    {
        Task<Result<PlayerMoves>> GetNextMove();
        char Icon { get; }
    }
}
