using System;
using System.Collections.Generic;

namespace SpaceGame
{
    public class MiniGame
    {
        public static Random randNum = new Random();
        public static bool Minigame()
        {
            int x = randNum.Next(100);
            bool gameWin = true;
            if (x > 70)
            {
                gameWin = PirateGame();
            }
            return gameWin;
        }

        public static bool PirateGame()
        {
            EnemyBulletInstance.AddList();

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
                DrawMiniGame(playerXCursor, playerYCursor, enemyActiveList, bulletList);
                ConsoleKey rKey = Console.ReadKey().Key;
                if (rKey == ConsoleKey.LeftArrow) { if (playerXCursor != 0) { playerXCursor--; } }
                if (rKey == ConsoleKey.RightArrow) { playerXCursor++; }
                if (rKey == ConsoleKey.UpArrow) { if (playerYCursor != 0) { playerYCursor--; } }
                if (rKey == ConsoleKey.DownArrow) { if (playerYCursor != Console.WindowHeight - 1) { playerYCursor++; } }

                if (enemyMoveCounter == 0)
                {
                    foreach (Enemy a in enemyActiveList)
                    {
                        a.enemyXCursor--;

                        if (playerYCursor == a.enemyYCursor && playerXCursor == a.enemyXCursor)
                        {
                            winGame = false;
                            gameFinish = true;
                            lives--;
                            playerYCursor = Console.BufferHeight / 2;
                            playerXCursor = 0;
                            enemyActiveList.RemoveRange(0, enemyActiveList.Count);
                            bulletList.RemoveRange(0, bulletList.Count);
                            enemyCreateCounter = 1;
                            enemyMoveCounter = 2;
                            enemyNumberCounter = 0;
                            shotcounter = 1;

                            DrawMiniGame(playerXCursor, playerYCursor, enemyActiveList, bulletList);
                        }
                        enemyMoveCounter = 1;
                    }
                }

                if (playerXCursor == Console.LargestWindowWidth - 1)
                {
                    winGame = true;
                    gameFinish = true;
                }

                if (winGame == true)
                {
                    Game.NewPlayer.wallet += randNum.Next(((int)Game.NewPlayer.wallet / 100));
                    winGame = null;
                }
                else if (winGame == false)
                {
                    if (Game.NewPlayer.wallet != 0)
                    {
                        Game.NewPlayer.wallet -= randNum.Next((int)Game.NewPlayer.wallet / 1000);
                    }
                    winGame = null;
                }

                if (enemyCreateCounter == 0)
                {
                    //Activator.CreateInstance(typeof(Enemy)); // HOOOOOOOOOOOOOOOOOWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW asdfgsafasefasFD AWFAWEFASFWR
                    enemyActiveList.Add(EnemyBulletInstance.eList[enemyNumberCounter]);
                    enemyNumberCounter++;
                    enemyCreateCounter = 2;
                }

                if (shotcounter == 0 && rKey == ConsoleKey.Spacebar)
                {

                    shotcounter = 5;
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

            }
            return gameWin;
        }
        public static void DrawMiniGame(int playerX, int playerY, List<Enemy> enemyList, List<Bullet> bulletList)
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
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(">");

        }


        public class Bullet
        {
            public int bulletYCursor;
            public int bulletXCursor;

        }

        public class Enemy
        {
            public int enemyXCursor = Console.BufferWidth - 1;
            public int enemyYCursor = randNum.Next(Console.BufferHeight - 1);
        }
    }
}

