using DiceRollGame;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

var game = new Game();
game.GameOn();


class Game
{
    private static int _numberOfChances = 3;
    private static  int _randomNumber;
    public Game()
    {
        _randomNumber = new NumberGenerator().RandomNumber();
    }

    public void GameOn()
    {
        if (_numberOfChances == 0)
        {
            Console.WriteLine("You lost the game");
            return;
        }

        Console.WriteLine($"Dice rolled number between 1 - 6. Guess what number it shows in {_numberOfChances} tries: ");
        var numberGenerator = new NumberGenerator();
        int userNumber = numberGenerator.UserNumber();

        if (userNumber == 0)
        {
            GameOn();
            return;
        }

        _numberOfChances--;

        if (_randomNumber == userNumber)
        {
            Console.WriteLine("You win the game");
        }
        else
        {
            GameOn();

        }

        return;
    }
}