using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public class MiniGame
    {
        public Random randNum = new Random();
        public void Minigame()
        {
            int x = randNum.Next(1 - 100);

            if (x > 70)
            {
                PirateGame();
            }
        }

        public void PirateGame()
        {
            List<Enemy> enemyList = new List<Enemy>();
            List<Bullet> bulletList = new List<Bullet>();

            bool gameFinish = false;
            int lives = 3;
            int enemyCreateCounter = 0;
            int enemyMoveCounter = 1;
            int enemyNumberCounter = 0;
            int shotcounter = 0;
            bool? winGame = null;
            int playerXCursor = 0;
            int playerYCursor = Console.BufferHeight / 2;

            while (gameFinish == false)
            {
                DrawMiniGame(playerXCursor, playerYCursor, enemyList, bulletList);
                int yRand = randNum.Next(Console.BufferHeight - 1);
                ConsoleKey rKey = Console.ReadKey().Key;
                if (rKey == ConsoleKey.LeftArrow) { playerXCursor--; }
                if (rKey == ConsoleKey.RightArrow) { playerXCursor++; }
                if (rKey == ConsoleKey.UpArrow) { playerYCursor--; }
                if (rKey == ConsoleKey.DownArrow) { playerYCursor++; }

                if (enemyMoveCounter == 0)
                {
                    foreach (Enemy a in enemyList)
                    {
                        a.enemyXCursor--;

                        if (playerYCursor == a.enemyYCursor && playerXCursor == a.enemyXCursor)
                        {
                            winGame = false;
                            gameFinish = true;
                            lives--;
                            playerYCursor = Console.BufferHeight / 2;
                            playerXCursor = 0;
                            enemyList.RemoveRange(0, enemyList.Count);
                            bulletList.RemoveRange(0, bulletList.Count);
                            enemyCreateCounter = 1;
                            enemyMoveCounter = 2;
                            enemyNumberCounter = 1;
                            shotcounter = 1;

                            DrawMiniGame(playerXCursor, playerYCursor, enemyList, bulletList);
                        }
                    }
                }

                if (playerYCursor == Console.BufferWidth - 1)
                {
                    winGame = true;
                    gameFinish = true;
                }

                if (winGame == true)
                {
                    Game.NewPlayer.wallet += randNum.Next(1000);
                    winGame = null;
                }
                else if (winGame == false)
                {
                    Game.NewPlayer.wallet -= randNum.Next(1000);
                    winGame = null;
                }

                if (enemyCreateCounter == 0)
                {
                    string numb = "enemy" + enemyNumberCounter.ToString();
                    Activator.CreateInstance(typeof(Enemy), numb);
                    enemyNumberCounter++;
                    enemyCreateCounter = 10;
                }


                //foreach (/*Bullet a in bulletList*/)
                //{
                //    bullet#XCursor++;
                //}

                //if (shotcounter == 0)
                //{
                //    if (iskeyavailable.spacebar == true)
                //    {
                //        int bullet#X = currentX = playerXCursor;
                //     int bullet#Y = int currentY = playerYCursor;
                //    setcursorposition(bullet#X,bullet#Y)
                //    cw("--");
                //        setcursorposition(currentX, currentY)
                //                    shotcounter = 5;
                //    }
                //}

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

            }
        }
        public void DrawMiniGame(int playerX, int playerY, List<Enemy> enemyList, List<Bullet> bulletList)
        {
            Console.Clear();

            foreach (Enemy a in enemyList)
            {
                Console.SetCursorPosition(a.enemyXCursor, a.enemyYCursor);
                Console.Write("@");
            }
            foreach (Bullet a in bulletList)
            {
                Console.SetCursorPosition(a.bulletXCursor, a.bulletYCursor);
                Console.Write("-");
            }

        }


        public class Bullet
        {
            public int bulletYCursor;
            public int bulletXCursor;

        }

        public class Enemy
        {
            public int enemyXCursor;
            public int enemyYCursor;
        }
    }
}

