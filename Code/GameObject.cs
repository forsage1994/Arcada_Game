using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcada1
{
  public class GameObject
  {
    public Texture2D Texture { get; set; }
    protected Vector2 Pos;
    public GameObject(Int32 X, Int32 Y)
    {
      this.Pos.X = X;
      this.Pos.Y = Y;
    }
  }
}
