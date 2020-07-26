using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Arcada1
{
  public class Bullet : GameObject
  {
//    public Byte Damage { get; set; }
    private readonly Direction direction;
    private readonly Byte speed;
    public BulletDirectionSprite bulletDirection;
    public Bullet(Int32 x, Int32 y, Direction direction, Byte speed)
      : base(x,y)
    {
      this.destinationRectangle.X = x;
      this.destinationRectangle.Y = y;
      this.direction = direction;
      this.speed = speed;

      switch (direction)
      {
        case Direction.Up:
          bulletDirection = BulletDirectionSprite.Up;
          break;
        case Direction.Down:
          bulletDirection = BulletDirectionSprite.Down;
          break;
        case Direction.Left:
          bulletDirection = BulletDirectionSprite.Left;
          break;
        case Direction.Right:
          bulletDirection = BulletDirectionSprite.Right;
          break;
      }
    }
    public void Move()
    {
      switch (direction)
      {
        case Direction.Up:
          this.destinationRectangle.Y -= speed;
          break;
        case Direction.Down:
          this.destinationRectangle.Y += speed;
          break;
        case Direction.Left:
          this.destinationRectangle.X -= speed;
          break;
        case Direction.Right:
          this.destinationRectangle.X += speed;
          break;
      }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
      sourceRectangle.X = (int)bulletDirection;
      sourceRectangle.Y = 102;
      spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
    }
  }
}