using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcada1
{
  class BattleCity
  {
    public static int Width, Height;
    public static Random random;
    public static SpriteBatch SpriteBatch { get; set; }
    static List<Tank> tanks = new List<Tank>(0);

    static public Int32 GetRnd(Int32 min, Int32 max)
    {
      return random.Next(min, max);
    }

    static public void Init(SpriteBatch spriteBatch, Int32 width, Int32 height)
    {
      BattleCity.Width = width;
      BattleCity.Height = height;
      BattleCity.SpriteBatch = spriteBatch;
      //      tanks.Add(new Tank(GetRnd(200, 500), GetRnd(200, 500), 1));
      tanks.Add(new Tank(100, 100, 1));
    }

    public static void Draw()
    {
      foreach(Tank tank in tanks)
        tank.Draw(SpriteBatch);
    }

    public static void Update(Direction direction)
    {
      foreach (Tank tank in tanks)
        tank.Update(direction);
    }
  }
}
