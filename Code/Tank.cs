using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcada1
{
  public class Tank : GameObject
  {
    private Int32 Lifes;
    Direction CurrentDirection;
    FrameOfTank frame;
    TypeOfTank type;
//    Rectangle sourceRectangle = new Rectangle();
 //   Rectangle destinationRectangle = new Rectangle();
    public Tank(Int32 PosX, Int32 PosY, Byte mult)
      : base(PosX, PosY)
    {
      this.destinationRectangle.X = PosX;
      this.destinationRectangle.Y = PosY;
      this.destinationRectangle.Width = this.destinationRectangle.Height = 16 * mult;
      this.Lifes = 1;
      this.CurrentDirection = Direction.Up;
      sourceRectangle.Width = sourceRectangle.Height = 16;
    }
    public void Update(Direction Direction)
    {
      switch (Direction)
      {
        case Direction.Up:
          if(frame != FrameOfTank.UpFirstFrame)
          {
            frame = FrameOfTank.UpFirstFrame;
          }
          else
          {
            frame = FrameOfTank.UpSecondFrame;
          }
          destinationRectangle.Y -= 1;
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
          destinationRectangle.Y += 1;
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
          destinationRectangle.X -= 1;
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
          destinationRectangle.X += 1;
          this.CurrentDirection = Direction.Right;
          break;
      }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
      sourceRectangle.X = (Int32)frame;
      sourceRectangle.Y = (Int32)type;
          spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
    }
    public Rectangle GetPosForFire => new Rectangle(destinationRectangle.X + 8, destinationRectangle.Y + 8, 10, 10);
  }
}
