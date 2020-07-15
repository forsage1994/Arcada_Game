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
    SpriteBatch spriteBatch;
    Texture2D texture;
    Vector2 pos = new Vector2() { X = 0, Y = 0 };
//    Int64 counter = 0;
    sbyte dirX = 1, dirY = 1;
    Random rnd = new Random();
    Color BackgroundColor = new Color();

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected void ChangeDirection(Single Position,   ref SByte Direction,   
                                Int32 ScreenSize, Int32 TextureSize)
    {
      if ( (Position >= (ScreenSize - TextureSize)) || (Position <= 0) )
        Direction *= -1;
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
      BackgroundColor.R = (byte)rnd.Next(255);
      BackgroundColor.G = (byte)rnd.Next(255);
      BackgroundColor.B = (byte)rnd.Next(255);
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
      texture = Content.Load<Texture2D>("bubble");

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

      pos.X += dirX;
      pos.Y += dirY;

      ChangeDirection(pos.X, ref dirX, Window.ClientBounds.Width, texture.Width / 10);
      ChangeDirection(pos.Y, ref dirY, Window.ClientBounds.Height, texture.Height / 10);

      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(BackgroundColor);
      spriteBatch.Begin();
      spriteBatch.Draw(texture, pos, null, Color.White, 0.0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0);
      spriteBatch.End();

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}
