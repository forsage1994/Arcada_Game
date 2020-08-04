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
    private readonly Int32 speed;
    public BulletDirectionSprite bulletDirection;
    public Bullet(Int32 x, Int32 y, Direction direction, Byte speed, Tank tank, Texture2D sprites, Int32 multiplication)
      : base(x, y, multiplication)
    {
      this.multiplication = multiplication;
      this.direction = direction;
      this.speed = speed * this.multiplication;
      this.owner = tank;
      this.Texture = sprites;
      this.sourceRectangle.Y = 102;

      switch (direction)
      {
        case Direction.Up:
          bulletDirection = BulletDirectionSprite.Up;
          this.destinationRectangle.X = x + 6 * this.multiplication;
          this.destinationRectangle.Y = y - 2 * this.multiplication;
          sourceRectangle.Width = 3;
          sourceRectangle.Height = 4;
          destinationRectangle.Width = sourceRectangle.Width * this.multiplication;
          destinationRectangle.Height = sourceRectangle.Height * this.multiplication;
          break;
        case Direction.Down:
          bulletDirection = BulletDirectionSprite.Down;
          this.destinationRectangle.X = x + 6 * this.multiplication;
          this.destinationRectangle.Y = y + 14 * this.multiplication;
          sourceRectangle.Width = 3;
          sourceRectangle.Height = 4;
          destinationRectangle.Width = sourceRectangle.Width * this.multiplication;
          destinationRectangle.Height = sourceRectangle.Height * this.multiplication;
          break;
        case Direction.Left:
          bulletDirection = BulletDirectionSprite.Left;
          this.destinationRectangle.X = x - 2 * this.multiplication;
          this.destinationRectangle.Y = y + 6 * this.multiplication;
          sourceRectangle.Width = 4;
          sourceRectangle.Height = 3;
          destinationRectangle.Width = sourceRectangle.Width * this.multiplication;
          destinationRectangle.Height = sourceRectangle.Height * this.multiplication;
          break;
        case Direction.Right:
          bulletDirection = BulletDirectionSprite.Right;
          this.destinationRectangle.X = x + 14 * this.multiplication;
          this.destinationRectangle.Y = y + 6 * this.multiplication;
          sourceRectangle.Width = 4;
          sourceRectangle.Height = 3;
          destinationRectangle.Width = sourceRectangle.Width * this.multiplication;
          destinationRectangle.Height = sourceRectangle.Height * this.multiplication;
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