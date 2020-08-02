using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Arcada1
{
  public class GameObject
  {
    public Texture2D Texture { get; set; }
    protected Vector2 Pos;
    protected Rectangle sourceRectangle = new Rectangle();
    public Rectangle destinationRectangle = new Rectangle();
    public GameObject(Int32 X, Int32 Y)
    {
      this.Pos.X = X;
      this.Pos.Y = Y;
    }
    public GameObject(Rectangle destinationRectangle)
    {
      this.destinationRectangle = destinationRectangle;
    }
  }
}
