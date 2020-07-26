using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcada1
{
  public class Target : GameObject
  {

    TypesOfTarget Type;
    public Target(Int32 X, Int32 Y, Texture2D Texture, TypesOfTarget Type)
      : base(X, Y)
    {
      this.Type = Type;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(this.Texture, this.Pos, Color.White);
    }
  }
}
