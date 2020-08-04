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
    protected Int32 multiplication;
    public GameObject(Int32 X, Int32 Y, Int32 multiplication)
    {
      this.Pos.X = X;
      this.Pos.Y = Y;
      this.multiplication = multiplication;
    }
    public GameObject(Rectangle destinationRectangle)
    {
      this.destinationRectangle = destinationRectangle;
    }
  }
}
