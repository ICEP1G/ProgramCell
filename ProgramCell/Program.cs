using CSharpFunctionalExtensions;
using System;
using System.Data.Common;

namespace TicTacToe;

internal class Program
{

    static void Main(string[] args)
    {
        Game game = new Game();
        game.Init();
        game.Play();
    }

}
