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
    class Score : TextObject
    {
        private int _score = 0;
                public Score(GameHost game)
            : base(game)
        {
            ScaleX = 1;
            ScaleY = 1;
            SpriteColor = Color.White;
        }

        public Score(GameHost game, SpriteFont font)
            : this(game)
        {
            Font = font;
        }

        public Score(GameHost game, SpriteFont font, Vector2 position)
            : this(game, font)
        {
            PositionX = position.X;
            PositionY = position.Y;
        }

        public void IncrementScore()
        {
            _score++;
            Text = "Score: " + _score;
        }

    }
}
