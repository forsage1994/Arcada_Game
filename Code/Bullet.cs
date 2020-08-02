using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Arcada1
{
  public class Bullet : GameObject
  {
    //    public Byte Damage { get; set; }
    private Tank owner;
    private readonly Direction direction;
    private readonly Byte speed;
    public BulletDirectionSprite bulletDirection;
    public Bullet(Int32 x, Int32 y, Direction direction, Byte speed, Tank tank, Texture2D sprites)
      : base(x, y)
    {
      this.direction = direction;
      this.speed = speed;
      this.owner = tank;
      this.Texture = sprites;
      this.sourceRectangle.Y = 102;

      switch (direction)
      {
        case Direction.Up:
          bulletDirection = BulletDirectionSprite.Up;
          this.destinationRectangle.X = x + 6;
          this.destinationRectangle.Y = y - 2;
          destinationRectangle.Width = sourceRectangle.Width = 3;
          destinationRectangle.Height = sourceRectangle.Height = 4;
          break;
        case Direction.Down:
          bulletDirection = BulletDirectionSprite.Down;
          this.destinationRectangle.X = x + 6;
          this.destinationRectangle.Y = y + 14;
          destinationRectangle.Width = sourceRectangle.Width = 3;
          destinationRectangle.Height = sourceRectangle.Height = 4;
          break;
        case Direction.Left:
          bulletDirection = BulletDirectionSprite.Left;
          this.destinationRectangle.X = x - 2;
          this.destinationRectangle.Y = y + 6;
          destinationRectangle.Width = sourceRectangle.Width = 4;
          destinationRectangle.Height = sourceRectangle.Height = 3;
          break;
        case Direction.Right:
          bulletDirection = BulletDirectionSprite.Right;
          this.destinationRectangle.X = x + 14;
          this.destinationRectangle.Y = y + 6;
          destinationRectangle.Width = sourceRectangle.Width = 4;
          destinationRectangle.Height = sourceRectangle.Height = 3;
          break;
      }
      this.sourceRectangle.X = (int)bulletDirection;
    }
    public void Update()
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
      spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
    }
  }
}