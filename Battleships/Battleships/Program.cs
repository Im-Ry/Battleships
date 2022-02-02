using System;

namespace Battleships
{
    class Program
    {
        public struct Ship
        {
            public string shipType;
            public bool shipSunk;
            public ConsoleColor shipColor;
            

            public Ship(string t, bool s, ConsoleColor c)
            {
                this.shipType = t;
                this.shipSunk = s;
                this.shipColor = c;
            }
        }

        public const int x = 5;
        public const int y = 5;

        public static Ship[,] board = new Ship[x, y];


        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to Battleships");
            Console.WriteLine("");
            createShip1();
            displayBoard();
            Console.ReadKey();
            bool bContinue = true;
            int iCount = 0;
            int iGoes = 10;

            do
            {
                Console.Write("Enter the X Coordinate you wish to guess (0-4): "); string splayer1x = Console.ReadLine();
                Int32.TryParse(splayer1x, out Int32 iPlayer1x);
                Console.WriteLine();
                Console.Write("Enter the Y Coordinate you wish to guess (0-4): "); string splayer1y = Console.ReadLine();
                Int32.TryParse(splayer1y, out Int32 iPlayer1y);

                if (board[iPlayer1x, iPlayer1y].shipSunk == true)
                {
                    Console.WriteLine("You already hit that you goon");
                }

                if (board[iPlayer1x, iPlayer1y].shipType != "S")
                {
                    Console.WriteLine("Miss", Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                }

                else if (board[iPlayer1x, iPlayer1y].shipType == "S")
                {
                    Console.WriteLine("Hit!", Console.ForegroundColor = ConsoleColor.Green);
                    Console.ResetColor();
                    board[iPlayer1x, iPlayer1y].shipSunk  = true;
                }
               
                else
                {
                    Console.WriteLine("Miss",Console.ForegroundColor = ConsoleColor.Red);
                    Console.ResetColor();
                }

                displayBoard();
                Console.ReadKey();


                iCount = iCount + 1;
                int iGoesleft = iGoes - iCount;
                Console.Write("You have used: "); Console.Write(iCount); Console.WriteLine(" goes");
                Console.WriteLine();
                Console.Write("You have: "); Console.Write(iGoesleft); Console.WriteLine(" goes left");
            }
            while (iCount < 10);

            Console.WriteLine("You ran out of goes lul");
            Console.WriteLine();
           
        }

        static void createShip1()
        {
            Ship temp;
            Random number = new Random();
            int icoord1 = number.Next(0, 4);
            int icoord2 = number.Next(0, 4);
            int icoord3 = number.Next(0, 4);
            int icoord4 = number.Next(0, 4);
            if (icoord1 == icoord3)
            {
                if (icoord2 == icoord4)
                {
                    if (icoord1 > 4)
                    {
                        icoord3 = icoord3 - 1;
                    }
                    else if (icoord1 == 0)
                    {
                        icoord3 = icoord3 + 1;
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == icoord1)
                    {
                        if (j == icoord2)
                        {
                            temp = new Ship("S", false, ConsoleColor.Green);
                            board[i, j] = temp;
                        }

                    }
                    else if (i == icoord3)
                    {
                        if (j == icoord4)
                        {
                            temp = new Ship("S", false, ConsoleColor.Red);
                            board[i, j] = temp;
                        }
                    }
                    else
                    {
                        temp = new Ship(" ", false, ConsoleColor.White);
                        board[i, j] = temp;
                    }
                }
            }
        }


        static void displayBoard()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    if (board[i, j].shipType == "S")
                    {
                        if (board[i, j].shipSunk == true)
                        {
                            Console.Write("X",board[i, j].shipType, Console.ForegroundColor = ConsoleColor.Green);
                        }
                        else
                        {
                            Console.Write("?", Console.ForegroundColor = ConsoleColor.White);
                            Console.ResetColor();
                        }
                       
                    }
                    else
                    {
                        Console.Write("?", Console.ForegroundColor = ConsoleColor.White);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

    }
}