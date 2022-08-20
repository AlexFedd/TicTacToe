using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1._1
{
    internal class Program
    {
        static bool GameResult(char[,] gameField)
        {
            if (((gameField[0, 0] == gameField[0, 1]) && (gameField[0, 0] == gameField[0, 2]) && (gameField[0, 0] != '#')) ||
                ((gameField[1, 0] == gameField[1, 1]) && (gameField[1, 0] == gameField[1, 2]) && (gameField[1, 0] != '#')) ||
                ((gameField[2, 0] == gameField[2, 1]) && (gameField[2, 0] == gameField[2, 2]) && (gameField[2, 0] != '#')) ||
                ((gameField[0, 0] == gameField[1, 0]) && (gameField[0, 0] == gameField[2, 0]) && (gameField[0, 0] != '#')) ||
                ((gameField[0, 1] == gameField[1, 1]) && (gameField[0, 1] == gameField[2, 1]) && (gameField[0, 1] != '#')) ||
                ((gameField[0, 2] == gameField[1, 2]) && (gameField[0, 2] == gameField[2, 2]) && (gameField[0, 2] != '#')) ||
                ((gameField[0, 0] == gameField[1, 1]) && (gameField[0, 0] == gameField[2, 2]) && (gameField[0, 0] != '#')) ||
                ((gameField[2, 0] == gameField[1, 1]) && (gameField[2, 0] == gameField[0, 2]) && (gameField[2, 0] != '#')))
            {
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t##TicTacToe##");
            Console.WriteLine("\t\t\t\t\tPress enter to start the game.");
            ConsoleKey key = Console.ReadKey().Key;
            char[,] gameField =
            {
                {'#','#','#'},
                {'#','#','#'},
                {'#','#','#'}
            };
            char curSign = 'X';
            int xCoordinate, yCoordinate;
            bool winFlag = false;
            if (key == ConsoleKey.Enter)
            {
                for (int turn = 0; turn < 9; turn++)
                {
                    Console.Clear();
                    Console.WriteLine();
                    for (int i = 0; i < gameField.GetLength(0); i++)
                    {
                        Console.Write("\t\t\t\t\t");
                        for (int j = 0; j < gameField.GetLength(1); j++)
                        {
                            Console.Write($"\t{gameField[i, j]}");
                        }
                        Console.WriteLine("\n");
                    }
                    if (curSign == 'X')
                    {
                        try
                        {
                            Console.WriteLine("FIRST player turn: ");
                            Console.Write("X-coordinate: ");
                            xCoordinate = int.Parse(Console.ReadLine());
                            Console.Write("Y-coordinate: ");
                            yCoordinate = int.Parse(Console.ReadLine());
                            if ((gameField[yCoordinate - 1, xCoordinate - 1] == 'X') || (gameField[yCoordinate - 1, xCoordinate - 1] == 'O'))
                            {
                                turn--;
                                continue;
                            }
                            gameField[yCoordinate - 1, xCoordinate - 1] = 'X';
                        }
                        catch (Exception)
                        {
                            turn--;
                            continue;
                        }
                        if (GameResult(gameField))
                        {
                            winFlag = true;
                            break;
                        }
                        curSign = 'O';
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("SECOND player turn: ");
                            Console.Write("X-coordinate: ");
                            xCoordinate = int.Parse(Console.ReadLine());
                            Console.Write("Y-coordinate: ");
                            yCoordinate = int.Parse(Console.ReadLine());
                            if ((gameField[yCoordinate - 1, xCoordinate - 1] == 'X') || (gameField[yCoordinate - 1, xCoordinate - 1] == 'O'))
                            {
                                turn--;
                                continue;
                            }
                            gameField[yCoordinate - 1, xCoordinate - 1] = 'O';
                        }
                        catch (Exception)
                        {
                            turn--;
                            continue;
                        }
                        if (GameResult(gameField))
                        {
                            winFlag = true;
                            break;
                        }
                        curSign = 'X';
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }
            Console.Clear();
            if (winFlag == true)
            {
                if (curSign == 'X')
                {
                    Console.WriteLine("\t\t\t\t\t      First player won!");
                }
                else Console.WriteLine("\t\t\t\t\t      Second player won");
            }
            else Console.WriteLine("\t\t\t\t\t\t      Draw!");
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                Console.Write("\t\t\t\t\t");
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    Console.Write($"\t{gameField[i, j]}");
                }
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
    }
}