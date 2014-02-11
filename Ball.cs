using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameBreakoutClone.GameFramework;

namespace MonoGameBreakoutClone
{
    class Ball : SpriteObject
    {
        private Score score;
        private float _VelocityX = 4f;
        private float _VelocityY = -4f;

         public Ball(GameHost game)
            : base(game)
        {
            // Set the default scale and color
            ScaleX = 1;
            ScaleY = 1;
            SpriteColor = Color.White;
        }

        public Ball(GameHost game, Vector2 position)
            : this(game)
        {
            // Store the provided position
            Position = position;
        }

        public Ball(GameHost game, Vector2 position, Texture2D texture, Score score)
            : this(game, position)
        {
            // Store the provided texture
            SpriteTexture = texture;
            this.score = score;
        }

        public override void Update(GameTime gameTime)
        {
            //collison detection
            Point ballCornerA = new Point((int)PositionX, (int)PositionY);
            Point ballCornerB = new Point((int)PositionX + (int)BoundingBox.Width, (int)PositionY);
            Point ballCornerC = new Point((int)PositionX, (int)PositionY + BoundingBox.Height);
            Point ballCornerD = new Point((int)PositionX + (int)BoundingBox.Width,(int)PositionY + (int)BoundingBox.Height);
            
                for (int i = 0; i < Game.GameObjects.Count; i++)
                {
                    SpriteObject spriteObject = (SpriteObject)Game.GameObjects[i];
                    if (spriteObject.BoundingBox.Contains(ballCornerA) ||
                        spriteObject.BoundingBox.Contains(ballCornerB) ||
                        spriteObject.BoundingBox.Contains(ballCornerC) ||
                        spriteObject.BoundingBox.Contains(ballCornerD))
                    {
                        if (spriteObject.GetType() == typeof (Player))
                            _VelocityY *= -1;

                        if (spriteObject.GetType() == typeof (Block))
                        {
                            _VelocityY *= -1;
                            Game.GameObjects.Remove(spriteObject);
                            score.IncrementScore();
                        }
                        
                    }

                }
                
            
            if (PositionX < 0) _VelocityX *= -1;
            if (PositionX > 1600) _VelocityX *= -1;
            if (PositionY < 0) _VelocityY *= -1;
            if (PositionY > 900) _VelocityY *= -1;

            PositionX += _VelocityX;
            PositionY += _VelocityY;
            base.Update(gameTime);
        }
    }
}
