using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Gum;
using Gum.Managers;

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
        GumUI.Initialize(this, "GumUI/GumUI.gumj");
        Gum.Renderables.ShapeRenderer.Self.Initialize();
        Gum.Wireframe.CustomSetPropertyOnRenderable.InMemoryFontCreator = new KernSmith.Gum.KernSmithFontCreator(GraphicsDevice);
        
        var screen = ObjectFinder.Self.GumProjectSave.Screens[0].ToGraphicalUiElement();          
        screen.AddToRoot();
        
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
