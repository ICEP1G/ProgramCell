using CSharpFunctionalExtensions;
using System;
using System.Data.Common;

namespace TicTacToe;

internal class Program
{

    static async Task Main(string[] args)
    {
        Game game = new Game();
        game.Init();
        await game.Play();
    }

}
