using OneHourChallengeFlappySpace;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        Game game = new Game();
        game.Run();

        Console.ReadLine();
    }
}
