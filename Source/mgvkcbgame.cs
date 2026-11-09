using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Gum;
using Gum.Forms;
using Gum.Forms.Controls;

namespace Source;

public class mgvkcbgame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    GumService GumUI => GumService.Default;
    
    public mgvkcbgame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    
    protected override void Initialize()
    {
        GumUI.Initialize(this);
        Gum.Renderables.ShapeRenderer.Self.Initialize();
        
        base.Initialize();
    }
    
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        GumUI.Update(gameTime);
                
        base.Update(gameTime);
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        GumUI.Draw();
        
        base.Draw(gameTime);
    }
}
