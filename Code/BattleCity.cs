using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Arcada1
{
  public class BattleCity
  {
    public static Int32 FieldWidth, FieldHeight;
    public static Random random = new Random();
    public static SpriteBatch SpriteBatch { get; set; }
    public static Tank Player;
    public static List<Tank> tanks = new List<Tank>();
    static Int32 displayMultiplication;

    static public Int32 GetRnd(Int32 min, Int32 max)
    {
      return random.Next(min, max);
    }

    public void Init(SpriteBatch spriteBatch, Int32 width, Int32 height, Int32 multiplication, Texture2D texture)
    {
      displayMultiplication = multiplication;
      FieldWidth = width;
      FieldHeight = height;
      SpriteBatch = spriteBatch;
      //      tanks.Add(new Tank(GetRnd(200, 500), GetRnd(200, 500), 1));
      tanks.Add(new Tank(100, 100, texture, width, height, multiplication));
      Player = tanks[0];
    }

    public static void Draw()
    {
      foreach (Tank tank in tanks)
        tank.Draw(SpriteBatch);
    }

    public static void Update(Direction direction)
    {
      foreach (Tank tank in tanks)
      {
        tank.Update(direction);
      }
    }

    public static void UpdateBullet()
    {
      foreach (Tank tank in tanks)
      {
        tank.UpdateBullet();
      }
    }
    public static void CheckHit()
    {
      for (Int32 i = 0; i < tanks.Count; ++i)
      {
        if ((Player.bullet != null) && (tanks.Count > 1) && tanks[i].IsLife() &&
          ((Player.bullet.destinationRectangle.X < (tanks[i].destinationRectangle.X + tanks[i].destinationRectangle.Width)) &&
            (Player.bullet.destinationRectangle.X + Player.bullet.destinationRectangle.Width > tanks[i].destinationRectangle.X)) &&
            ((Player.bullet.destinationRectangle.Y < (tanks[i].destinationRectangle.Y + tanks[i].destinationRectangle.Height)) &&
            (Player.bullet.destinationRectangle.Y + Player.bullet.destinationRectangle.Height > tanks[i].destinationRectangle.Y)))
        {
          //          tanks[i].HitByAnotherTank();
          Player.bullet = null;
          tanks[i] = null;
          tanks.RemoveAt(i);
        }
      }
      //GC.Collect();
      //GC.WaitForPendingFinalizers();

    }
    public static void AddTank(Texture2D texture)
    {
      tanks.Add(new Tank(GetRnd(FieldWidth / 2, FieldWidth - 20), GetRnd(0, FieldHeight), texture, FieldWidth, FieldHeight, displayMultiplication));
    }
  }
}
