using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public class MiniGame
    {
        public static Random randNum = new Random ();
        public static bool Minigame ()
        {
            int x = randNum.Next (100);
            bool gameWin = true;
            if (x > 70)
            {
                Console.WriteLine("The Enforcement Agency has caught up with you.\n" +
                    "Use your arrow keys to navigate past them and your spacebar to shoot.");
                Console.ReadKey();
                gameWin = PirateGame ();
            }
            return gameWin;
        }

        public static bool PirateGame()
        {
            List<Enemy> enemyActiveList = new List<Enemy>();
            List<Bullet> bulletList = new List<Bullet>();
            bool gameWin = true;
            bool gameFinish = false;
            int lives = 3;
            int enemyCreateCounter = 0;
            int enemyMoveCounter = 1;
            int enemyNumberCounter = 0;
            int shotcounter = 1;
            bool? winGame = null;
            int playerXCursor = 0;
            int playerYCursor = Console.BufferHeight / 2;


            while (gameFinish == false)
            {
                //Thread.Sleep (5);
                DrawMiniGame(playerXCursor, playerYCursor, enemyActiveList, bulletList, lives);
                ConsoleKey rKey = Console.ReadKey().Key;
                if (rKey == ConsoleKey.LeftArrow)
                {
                    if (playerXCursor != 0)
                    {
                        playerXCursor--;
                    };
                }
                if (rKey == ConsoleKey.RightArrow) { playerXCursor++; };
                if (rKey == ConsoleKey.UpArrow)
                {
                    if (playerYCursor != 0) { playerYCursor--; };
                }
                if (rKey == ConsoleKey.DownArrow)
                {
                    if (playerYCursor != Console.WindowHeight - 1) { playerYCursor++; };
                }
                if (rKey == ConsoleKey.Spacebar && shotcounter == 0)
                {
                    bulletList.Add(new Bullet() { bulletXCursor = playerXCursor + 1, bulletYCursor = playerYCursor });
                    shotcounter = 4;
                }

                if (shotcounter == 0 && rKey == ConsoleKey.Spacebar)
                {
                    shotcounter = 20;
                }

                for (int y = 0; y < enemyActiveList.Count; y++)
                {
                    if (playerYCursor == enemyActiveList[y].enemyYCursor)
                    {
                        if (playerXCursor == enemyActiveList[y].enemyXCursor)
                        {
                            winGame = false;
                            lives--;
                            playerYCursor = Console.BufferHeight / 2;
                            playerXCursor = 0;
                            enemyActiveList.RemoveRange(0, enemyActiveList.Count);
                            bulletList.RemoveRange(0, bulletList.Count);
                            enemyCreateCounter = 0;
                            enemyMoveCounter = 2;
                            enemyNumberCounter = 0;
                            shotcounter = 1;

                            DrawMiniGame(playerXCursor, playerYCursor, enemyActiveList, bulletList, lives);
                            break;
                        }
                    }
                    for (int x = 0; x < bulletList.Count; x++)
                    {
                        if (bulletList[x].bulletXCursor == enemyActiveList[y].enemyXCursor && bulletList[x].bulletYCursor == enemyActiveList[y].enemyYCursor)
                        {
                            bulletList.RemoveAt(x);
                            enemyActiveList.RemoveAt(y);
                        }
                    }
                }


                for (int y = 0; y < enemyActiveList.Count; y++)
                {
                    enemyActiveList[y].enemyXCursor--;
                    if (enemyActiveList[y].enemyXCursor <= playerXCursor - 5 || enemyActiveList[y].enemyXCursor == 2)
                    {
                        enemyActiveList.RemoveAt(y);
                    }
                }

                for (int y = 0; y < bulletList.Count; y++)
                {
                    bulletList[y].bulletXCursor++;
                    if (bulletList[y].bulletXCursor == Console.LargestWindowWidth - 1)
                    {
                        bulletList.RemoveAt(y);
                    }
                }

                if (playerXCursor == Console.LargestWindowWidth - 5)
                {
                    winGame = true;
                    gameFinish = true;
                }

                if (winGame == true)
                {
                    int gain = randNum.Next((int)Game.NewPlayer.wallet / 10);
                    Game.NewPlayer.totalMoneyEarned += gain;
                    Game.NewPlayer.wallet += gain;
                    winGame = null;
                }
                else if (winGame == false)
                {
                    if (Game.NewPlayer.wallet != 0)
                    {
                        int loss = randNum.Next((int)Game.NewPlayer.wallet / 10);
                        Game.NewPlayer.totalMoneyStolen += loss;
                        Game.NewPlayer.wallet -= loss;
                    }
                    winGame = null;
                }

                if (enemyCreateCounter == 0)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        if (playerXCursor + 50 >= Console.LargestWindowWidth)
                        {
                            enemyActiveList.Add(new Enemy() { enemyXCursor = Console.LargestWindowWidth - 1 });
                        }
                        else
                        {
                            { enemyActiveList.Add(new Enemy() { enemyXCursor = playerXCursor + 50 }); }
                        }

                    }
                    enemyNumberCounter++;
                    enemyCreateCounter = 5;
                }

                if (lives == 0)
                {
                    gameFinish = true;
                    gameWin = false;
                }

                if (shotcounter > 0)
                {
                    shotcounter--;
                }
                if (enemyCreateCounter > 0)
                {
                    enemyCreateCounter--;
                }
                if (enemyMoveCounter > 0)
                {
                    enemyMoveCounter--;
                }
                else
                {
                    enemyMoveCounter = 2;
                }

            }
            if (gameWin == true) {Game.NewPlayer.totalPassedPirateAttacks++; }
            else { Game.NewPlayer.totalFailedPirateAttacks++; }

            return gameWin;
        }
        public static void DrawMiniGame (int playerX, int playerY, List<Enemy> enemyList, List<Bullet> bulletList, int lives)
        {
            Console.Clear ();

            foreach (Enemy a in enemyList)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition (a.enemyXCursor, a.enemyYCursor);
                Console.Write ("@");
            }
            foreach (Bullet a in bulletList)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition (a.bulletXCursor, a.bulletYCursor);
                Console.Write ("-");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition (0, 0);
            Console.Write ("Lives Remaining:" + lives);
            Console.Write ("    Galactic Credits: " + Game.NewPlayer.wallet.ToString ());
            Console.SetCursorPosition (playerX, playerY);
            Console.Write (">");

        }

        public class Bullet
        {
            public int bulletYCursor;
            public int bulletXCursor;

        }

        public class Enemy
        {
            public int enemyXCursor = randNum.Next (10, Console.BufferWidth - 1);
            public int enemyYCursor = randNum.Next (Console.BufferHeight - 1);
        }
    }
}