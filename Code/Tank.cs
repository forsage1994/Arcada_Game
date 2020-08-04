using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Arcada1
{
  public class Tank : GameObject
  {
    public static Int32 FieldWidth, FieldHeight;
    private Int32 Lifes;
    private Direction CurrentDirection;
    private FrameOfTank frame;
    private TypeOfTank type;
    public Bullet bullet = null;
    public Tank(Int32 PosX, Int32 PosY, Texture2D texture, Int32 fieldWidth, Int32 fieldHeight, Int32 multiplication)
      : base(PosX, PosY, multiplication)
    {
      this.destinationRectangle.X = PosX * multiplication;
      this.destinationRectangle.Y = PosY * multiplication;
      this.destinationRectangle.Width = this.destinationRectangle.Height = 16 * multiplication;
      this.Texture = texture;
      this.Lifes = 1;
      this.CurrentDirection = Direction.Up;
      this.sourceRectangle.Width = this.sourceRectangle.Height = 16;
      FieldHeight = fieldHeight * multiplication;
      FieldWidth = fieldWidth * multiplication;
      this.multiplication = multiplication;
    }
    public void Update(Direction Direction)
    {
      this.CurrentDirection = Direction;
      switch (Direction)
      {
        case Direction.Up:
          if (frame != FrameOfTank.UpFirstFrame)
          {
            frame = FrameOfTank.UpFirstFrame;
          }
          else
          {
            frame = FrameOfTank.UpSecondFrame;
          }
          this.destinationRectangle.Y -= 1 * multiplication;
          this.CurrentDirection = Direction.Up;
          break;
        case Direction.Down:
          if (frame != FrameOfTank.DownFirstFrame)
          {
            frame = FrameOfTank.DownFirstFrame;
          }
          else
          {
            frame = FrameOfTank.DownSecondFrame;
          }
          this.destinationRectangle.Y += 1 * multiplication;
          this.CurrentDirection = Direction.Down;
          break;
        case Direction.Left:
          if (frame != FrameOfTank.LeftFirstFrame)
          {
            frame = FrameOfTank.LeftFirstFrame;
          }
          else
          {
            frame = FrameOfTank.LeftSecondFrame;
          }
          this.destinationRectangle.X -= 1 * multiplication;
          this.CurrentDirection = Direction.Left;
          break;
        case Direction.Right:
          if (frame != FrameOfTank.RightFirstFrame)
          {
            frame = FrameOfTank.RightFirstFrame;
          }
          else
          {
            frame = FrameOfTank.RightSecondFrame;
          }
          this.destinationRectangle.X += 1 * multiplication;
          this.CurrentDirection = Direction.Right;
          break;
      }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
      sourceRectangle.X = (Int32)frame;
      sourceRectangle.Y = (Int32)type;
      if (Lifes != 0)
        spriteBatch.Draw(this.Texture, this.destinationRectangle, this.sourceRectangle, Color.White);
      else
        spriteBatch.Draw(this.Texture, this.destinationRectangle, this.sourceRectangle, Color.Black);
      this.DrawBullet(spriteBatch);
    }
    public void Fire(Texture2D sprites)
    {
      if (this.bullet == null)
      {
        this.bullet = new Bullet(this.destinationRectangle.X, this.destinationRectangle.Y, this.CurrentDirection, 2, this, sprites, this.multiplication);
      }
    }
    public void DrawBullet(SpriteBatch spriteBatch)
    {
      if (this.bullet != null)
      {
        this.bullet.Draw(spriteBatch);
      }
    }
    public void UpdateBullet()
    {
      if (this.bullet != null)
      {
        this.bullet.Update();
        this.CheckBullet();
      }
    }
    public void CheckBullet()
    {
      if ((this.bullet.destinationRectangle.X <= (-4 * multiplication)) ||
          (this.bullet.destinationRectangle.X > FieldWidth) ||
          (this.bullet.destinationRectangle.Y <= (-4 * multiplication)) ||
          (this.bullet.destinationRectangle.Y > FieldHeight))
        this.bullet = null;
    }
    public void HitToAnotherTank()
    {

    }
    public void HitByAnotherTank()
    {
      //this.Lifes = 0;
    }
    public bool IsLife()
    {
      return (this.Lifes > 0);
    }
  }
}