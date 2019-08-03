using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceGame
{
    public class MiniGame
    {
        public Random randNum = new Random ();
        public bool gameFinish = false;
        static void Main (string [] args)
        {
            bool traveling = true;
        }
        public void Minigame (bool traveling)
        {
            bool pirateAttack = false;

            int x = randNum.Next (1 - 100);

            if (x > 70)
            {
                Game ();
            }

        }


        void Game ()
        {

            int yRand = randNum.Next (Console.BufferHeight - 1);
            int lives = 3;
            int enemyCreateCounter = 0;
            int enemyMoveCounter = 0;
            int enemyNumberCounter = 0;
            int shotcounter = 0;
            bool? winGame = null;
            int playerXCursor = 0;
            int playerYCursor = Console.BufferHeight / 2;

            while (gameFinish == false)
            {

                //if (IsKeyAvailable.DownArrow) { playerYCursor--; }
                //etc.
                for (int i = 0; i == 2; i++)
                {

                    //enemy#XCursor--;
                    //i = 0;
                }
                //if (playerYCursor == enemyYCursor && playerXCursor == enemyXCursor)
                //   {
                //    winGame = false;
                //    gameFinish = true;
                //    lives--;
                //}


                if (playerYCursor == Console.BufferWidth - 1)
                {
                    winGame = true;
                    gameFinish = true;
                }

                //if (winGame == true)
                //{
                //    NewPlayer.wallet += randomNum (15 - 1000)
                //        }
                //else if (winGame == false)
                //{
                //    NewPlayer.wallet -= randomNum (15 - 1000);
                //}

                // Help needed starts here
                if (enemyCreateCounter == 0)
                {
                    //enemy{ enemyNumberCounter} (randNum);
                    enemyNumberCounter++;
                    enemyCreateCounter = 10;
                }
                //class enemy0 : enemy(yRand);
                //class enemy1 : enemy(yRand)
                //class enemy2 : enemy(yRand)
                //class enemy3 : enemy(yRand)
                //class enemy4 : enemy(yRand)
                //class enemy5 : enemy(yRand)
                //class enemy6 : enemy(yRand)
                //class enemy7 : enemy(yRand)
                //...
                if (enemyMoveCounter == 0)
                {
                    //foreach (object a in Enemy)
                    //{
                    //    enemy#.enemyXCursor--;
                    //    }
                    enemyMoveCounter = 2;
                }

                //similar loop for bullets fired^ except

                if (shotcounter == 0)
                {
                    //            if (iskeyavailable.spacebar == true)
                    //            {
                    //                int bullet#X = currentX = playerXCursor;
                    // int bullet#Y = int currentY = playerYCursor;
                    //setcursorposition (bullet#X,bullet#Y)
                    //cw ("--");
                    //                setcursorposition (currentX, currentY)
                    //                shotcounter = 5;
                    //            }
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

                foreach (/*Bullet a in bulletList*/)
                {
                    //bullet#XCursor++;
                }

            }
        } while (gameFinish == false) ;
        
    }

    class Bullet
    {
        int bulletXCursor;
        int bulletYCursor;

    }

    class Enemy
    {
        int enemyXCursor = Console.BufferWidth - 1;
        public int enemyYCursor = YCursor;
    }
    //void Print (int enemyXCursor, int enemyYCursor)
    //{

    //    int currentX = Console.CursorLeft;
    //    int currentY = Console.CursorTop;

    //    Console.SetCursorPosition (enemyXCursor, enemyYCursor);
    //    Console.Write ('@');
    //    Console.SetCursorPosition (currentX, currentY);

    //}
}
}
