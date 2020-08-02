using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Arcada1
{
  public enum Stat
  {
    SplashScreen,
    Game,
    GameOver,
    Pause
  }
  public enum Direction : Byte
  {
    Up,
    Down,
    Left,
    Right
  }
  public enum TypesOfTarget : Byte
  {
    Cure,
    Poison,
    Death
  }
  public enum FrameOfTank : Byte
  {
    UpFirstFrame = 0,
    UpSecondFrame = 16,
    LeftFirstFrame = 32,
    LeftSecondFrame = 48,
    DownFirstFrame = 64,
    DownSecondFrame = 80,
    RightFirstFrame = 96,
    RightSecondFrame = 112
  }
  public enum TypeOfTank : Byte
  {
    TypeOne = 0,
    TypeTwo = 16,
    TypeThree = 32,
    TypeFour = 48,
    TypeFive = 64,
    TypeSix = 80,
    TypeSeven = 96,
    TypeEight = 112
  }
  public enum BulletDirectionSprite : Byte
  {
    Up = 67,
    Left = 74,
    Down = 83,
    Right = 90
  }
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    static SpriteBatch spriteBatch;
    static Texture2D tank, sprites;
    BattleCity battleCity = new BattleCity();
    Random rnd = new Random();
    Stat Stat = Stat.SplashScreen;

    const Int32 Width = 1000, Height = 500;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      graphics.PreferredBackBufferWidth = Width;
      graphics.PreferredBackBufferHeight = Height;
      graphics.ApplyChanges();
      // TODO: Add your initialization logic here
      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      // Create a new SpriteBatch, which can be used to draw textures.
      tank = Content.Load<Texture2D>("yellow_tanks");
      sprites = Content.Load<Texture2D>("other_sprites");
      spriteBatch = new SpriteBatch(GraphicsDevice);
      battleCity.Init(spriteBatch, Width, Height, tank);
      //      tank1.Texture = Content.Load<Texture2D>("yellow_tanks");
      //     player.SetTexture(texture);


      // TODO: use this.Content to load your game content here
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      switch (Stat)
      {
        case Stat.SplashScreen:
          if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            Stat = Stat.Game;
          break;

        case Stat.Game:
          BattleCity.UpdateBullet();
          BattleCity.CheckHit();

          if (Keyboard.GetState().IsKeyDown(Keys.H))
            BattleCity.AddTank(tank);

          if (Keyboard.GetState().IsKeyDown(Keys.Space))
            BattleCity.Player.Fire(sprites);
          else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            BattleCity.Update(Direction.Up);
          else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            BattleCity.Update(Direction.Down);
          else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            BattleCity.Update(Direction.Left);
          else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            BattleCity.Update(Direction.Right);
          break;

        case Stat.GameOver:

          break;

        case Stat.Pause:

          break;
      }



      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);

      spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

      switch (Stat)
      {
        case Stat.SplashScreen:

          break;

        case Stat.Game:
          BattleCity.Draw();

          //          tank1.Draw(spriteBatch);
          break;

        case Stat.GameOver:

          break;

        case Stat.Pause:

          break;
      }



      spriteBatch.End();

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}
