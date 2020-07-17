using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Arcada1
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    static SpriteBatch spriteBatch;
    static Texture2D texture;
    Vector2 pos = new Vector2() { X = 0, Y = 0 };
    static Vector2 centerOfRotation = new Vector2() { X = 15, Y = 15 };
    Int64 counter = 0;
    //    sbyte dirX = 1, dirY = 1;
    Random rnd = new Random();
    Color BackgroundColor = new Color();
    Player player = new Player(100, 100, texture);
    //List<Target>

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected void ChangeDirection(Single Position, ref SByte Direction,
                                Int32 ScreenSize, Int32 TextureSize)
    {
      if ((Position >= (ScreenSize - TextureSize)) || (Position <= 0))
        Direction *= -1;
    }

    public enum Moves : Byte
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
    public class GameObject
    {
      protected Texture2D Texture;
      protected Vector2 Pos;
      public GameObject(Int32 X, Int32 Y, Texture2D Texture)
      {
        this.Pos.X = X;
        this.Pos.Y = Y;
        this.Texture = Texture;
      }
      public void SetTexture(Texture2D Texture)
      {
        this.Texture = Texture;
      }
    }
    protected class Target : GameObject
    {
      TypesOfTarget Type;
      public Target(Int32 X, Int32 Y, Texture2D Texture, TypesOfTarget Type)
        : base(X, Y, Texture)
      {
        this.Type = Type;
      }
      public void Draw()
      {
        spriteBatch.Begin();
        spriteBatch.Draw(this.Texture, this.Pos, Color.White);
        spriteBatch.End();
      }
    }
    protected class Player : GameObject
    {
      private Int32 Lifes;
      Moves CurrentDirection;
      public Player(Int32 PosX, Int32 PosY, Texture2D Texture)
        : base(PosX, PosY, Texture)
      {
        this.Pos.X = PosX;
        this.Pos.Y = PosY;
        this.Lifes = 1;
        this.Texture = Texture;
        this.CurrentDirection = Moves.Up;
      }
      public void MovePlayer(Moves Direction)
      {
        switch (Direction)
        {
          case Moves.Up:
            this.Pos.Y -= 1;
            this.CurrentDirection = Moves.Up;
            break;
          case Moves.Down:
            this.Pos.Y += 1;
            this.CurrentDirection = Moves.Down;
            break;
          case Moves.Left:
            this.Pos.X -= 1;
            this.CurrentDirection = Moves.Left;
            break;
          case Moves.Right:
            this.Pos.X += 1;
            this.CurrentDirection = Moves.Right;
            break;
        }
      }

      public void Draw()
      {
        spriteBatch.Begin();
        switch (this.CurrentDirection)
        {
          case Moves.Up:
            spriteBatch.Draw(this.Texture, this.Pos, null, Color.White, 0.0f, centerOfRotation, 2f, SpriteEffects.None, 0);
            break;
          case Moves.Down:
            spriteBatch.Draw(this.Texture, this.Pos, null, Color.White, 3.14f, centerOfRotation, 2f, SpriteEffects.None, 0);
            break;
          case Moves.Left:
            spriteBatch.Draw(this.Texture, this.Pos, null, Color.White, 3.14f * 1.5f, centerOfRotation, 2f, SpriteEffects.None, 0);
            break;
          case Moves.Right:
            spriteBatch.Draw(this.Texture, this.Pos, null, Color.White, 3.14f / 2, centerOfRotation, 2f, SpriteEffects.None, 0);
            break;
          default:
            break;
        }
        spriteBatch.End();
      }
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
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
      spriteBatch = new SpriteBatch(GraphicsDevice);
      texture = Content.Load<Texture2D>("tank");
      player.SetTexture(texture);

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

      if (Keyboard.GetState().IsKeyDown(Keys.Up))
        player.MovePlayer(Moves.Up);

      if (Keyboard.GetState().IsKeyDown(Keys.Down))
        player.MovePlayer(Moves.Down);

      if (Keyboard.GetState().IsKeyDown(Keys.Left))
        player.MovePlayer(Moves.Left);

      if (Keyboard.GetState().IsKeyDown(Keys.Right))
        player.MovePlayer(Moves.Right);

      if (counter % 600 == 0)
      {

      }

      //pos.X += dirX;
      //pos.Y += dirY;

      //      ChangeDirection(pos.X, ref dirX, Window.ClientBounds.Width, texture.Width / 10);
      //      ChangeDirection(pos.Y, ref dirY, Window.ClientBounds.Height, texture.Height / 10);

      base.Update(gameTime);

      ++counter;
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.White);

      player.Draw();

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}
