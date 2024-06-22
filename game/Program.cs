using System;
public class Game
{
    const char player = 'P';
    const char treasure = 'T';
    const char trap = 'X';
    const char exit = 'E';
    const char empty = '.';
    const int size = 5;
    static char[,] field = new char[size, size];
    static int playerx = 0;
    static int playery = 0;
    static int score = 0;
    static bool gameduration = true;
    static Random rnd = new Random();
    static void initializeField()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                field[i, j] = empty;
            }
        }

        for (int i = 0; i  < rnd.Next(2, 10); i++)
        {
            field[rnd.Next(0, 4), rnd.Next(0, 4)] = trap;
        }
        for (int i = 0; i < rnd.Next(2, 10); i++)
        {
            field[rnd.Next(0, 4), rnd.Next(0, 4)] = treasure;
        }
        field[0, 0] = player;
        field[4, 4] = exit;
    }
    static void displayfield()
    {
        Console.Clear();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{ field[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static void playerMovement(char direction)
    {
        field[playerx, playery] = empty;
        switch (direction){
            case 'W':
                if (playerx > 0)
                {
                    playerx--;
                }
                break;

            case 'S': 
                if (playerx < size - 1)
                {
                    playerx++;
                }
                break;

            case 'A':
                if (playery > 0)
                {
                    playery--;
                }
                break;

            case 'D':
                if (playery < size - 1)
                {
                    playery++;
                }
                break;
        }

        switch (field[playerx,playery])
        {
            case treasure:
                score++;
                break;

            case exit:
                gameduration = false;
                Console.WriteLine("Congratulations you have won the game!");
                break;
            case trap:
                gameduration = false;
                Console.WriteLine("You stepped on a trap, and lost!");
                break;
        }
        field[playerx, playery] = player;
    }
    
    static void startGame()
    {
        initializeField();
        while (gameduration)
        {
            displayfield();
            Console.WriteLine($"Your score is: {score}");
            Console.WriteLine("Press a key on your keyboard to control the player (W, A, S, D):");
            char command = Console.ReadKey().KeyChar;
            playerMovement(command);
            Console.WriteLine();
        }
    }

    static void Main()
    {
        startGame();
    }
}
