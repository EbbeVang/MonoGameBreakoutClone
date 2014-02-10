using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameBreakoutClone.GameFramework;

namespace MonoGameBreakoutClone
{
    class Player : SpriteObject
    {
        private KeyboardState _keyboardState;
        private float speed = 4f;
        
         public Player(GameHost game)
            : base(game)
        {
            // Set the default scale and color
            ScaleX = 1;
            ScaleY = 1;
            SpriteColor = Color.White;
        }

        public Player(GameHost game, Vector2 position)
            : this(game)
        {
            // Store the provided position
            Position = position;
        }

        public Player(GameHost game, Vector2 position, Texture2D texture)
            : this(game, position)
        {
            // Store the provided texture
            SpriteTexture = texture;
        }

        public override void Update(GameTime gameTime)
        {
            _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Keys.Left))
            {
                PositionX = PositionX - speed;
            }
            if (_keyboardState.IsKeyDown(Keys.Right))
            {
                PositionX += speed;
            }
            base.Update(gameTime);
        }
    }
}
