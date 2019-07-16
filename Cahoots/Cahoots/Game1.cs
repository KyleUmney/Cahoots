using Cahoots.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    private static int _screenWidth = 1280;
    private static int _screenHeight = 720;
    Texture2D texture;
    Grid grid;
    BaseTile selectorTile;
    Enemies test;


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
      // TODO: Add your initialization logic here
      IsMouseVisible = true;
      graphics.PreferredBackBufferWidth = _screenWidth;
      graphics.PreferredBackBufferHeight = _screenHeight;
      graphics.ApplyChanges();
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

      grid = new Grid();

      selectorTile = new BaseTile();

      test = new Enemies();

      texture = Content.Load<Texture2D>("Textures/Untitled");

      test.texture = Content.Load<Texture2D>("Textures/Dude");

      grid.PopulateTiles(texture);
      selectorTile.Texture = texture;
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
      var mouse = Mouse.GetState();
      var mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

      foreach (var item in grid.Tiles)
      {
        if (mouseRectangle.Intersects(item.Rectangle))
        {
          selectorTile.Rectangle = item.Rectangle;
        }
      }

      foreach (var tile in grid.Tiles)
      {
        test.FollowPath(tile);
      }

      base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      spriteBatch.Begin();
      grid.Draw(spriteBatch);
      spriteBatch.Draw(selectorTile.Texture, selectorTile.Rectangle, Color.BurlyWood);
      spriteBatch.Draw(test.texture, test.Rectangle, Color.AliceBlue);
      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
