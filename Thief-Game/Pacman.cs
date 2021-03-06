﻿using System.Drawing;
using System.IO;
using System;

namespace Thief_Game
{

    /// <summary>
    /// Class for player object (Playable character)
    /// </summary>
    class Pacman : MovableGameObject, IMovable
    {
        private int Speed;
        private int Lifes;

        public int previousX;
        public int previousY;

        public static int StartX;
        public static int StartY;

        public int DirectionX;
        public int DirectionY;

        public int CurrentSpeed => Speed;
        public int CurrentLifes => Lifes;

        /// <summary>
        /// Init player with certain parameters
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="speed"></param>
        public Pacman(int startX, int startY, int speed): base(Path.Combine(PathInfo.PlayerSpritesDir, "Pacman.png"))
        {
            Lifes = 3;
            X = startX;
            Y = startY;

            this.Speed = speed;

            DirectionX = 0;
            DirectionY = 0;
        }

        public void MoveDown()
        {
            previousX = X;
            previousY = Y;
            Y += 1;
        }

        public void MoveLeft()
        {
            previousX = X;
            previousY = Y;
            X -= 1;
            if (X < 0)
                X = Dimensions.WindowWidthPixels / Dimensions.SpriteWidthPixels - 1;
        }

        public void MoveRight()
        {
            previousX = X;
            previousY = Y;
            X += 1;
            if (X > Dimensions.WindowWidthPixels / Dimensions.SpriteWidthPixels - 1)
                X = 0;
        }

        public void MoveUp()
        {
            previousX = X;
            previousY = Y;
            Y -= 1;
        }

        public void Redraw(Graphics graphics)
        {
            graphics.DrawImage(View, CurrentPositionX * Dimensions.SpriteWidthPixels, CurrentPositionY * Dimensions.SpriteHeightPixels + Dimensions.LifeBarHeight, 30, 30);
        }

        public void Respawn()
        {
            // TODO: if Lifes == 0, then...
            Lifes -= 1;
            X = StartX;
            Y = StartY;

        }
    }
}
