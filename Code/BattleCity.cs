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

    static public Int32 GetRnd(Int32 min, Int32 max)
    {
      return random.Next(min, max);
    }

    public void Init(SpriteBatch spriteBatch, Int32 width, Int32 height, Texture2D texture)
    {
      FieldWidth = width;
      FieldHeight = height;
      SpriteBatch = spriteBatch;
      //      tanks.Add(new Tank(GetRnd(200, 500), GetRnd(200, 500), 1));
      tanks.Add(new Tank(100, 100, texture, width, height));
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
 /*   public static void CheckHit()
    {
      foreach (Tank tank in tanks)
      {
        if (Player.bullet.destinationRectangle.X <= tank.)
        {

        }
      }
    }
 */
    public static void AddTank(Texture2D texture)
    {
      tanks.Add(new Tank(GetRnd(FieldWidth / 2,FieldWidth - 20), GetRnd(0, FieldHeight), texture, FieldWidth, FieldHeight));
    }
  }
}
