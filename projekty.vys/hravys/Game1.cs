using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace hravys
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // clanker
        private Texture2D _clankerTexture;
        private Vector2 _clankerPosition;
        private int _clankerSize = 50;
        private float _speed = 5f;
        private Texture2D _wallTexture;
        private Rectangle _wallRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _clankerPosition = new Vector2(
                _graphics.PreferredBackBufferWidth / 2 - _clankerSize / 2,
                _graphics.PreferredBackBufferHeight / 2 - _clankerSize / 2
                );

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _wallTexture = new Texture2D(GraphicsDevice, 1, 1);
            _wallTexture.SetData(new[] { Color.Black });
            _clankerTexture = new Texture2D(GraphicsDevice, 1, 1);
            _clankerTexture.SetData(new[] { Color.CornflowerBlue });

            int wallWidth = 200;
            int wallHeight = 40;
            int screenWidth = _graphics.PreferredBackBufferWidth;
            int screenHeight = _graphics.PreferredBackBufferHeight;

            _wallRect = new Rectangle(
                (screenWidth / 2) + 150,  // move 150px right from center
                (screenHeight / 2) - (wallHeight / 2),
                wallWidth,
                wallHeight
            );
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState k = Keyboard.GetState();


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                k.IsKeyDown(Keys.Escape))
                Exit();

            if (k.IsKeyDown(Keys.W)) _clankerPosition.Y -= _speed;
            if (k.IsKeyDown(Keys.S)) _clankerPosition.Y += _speed;
            if (k.IsKeyDown(Keys.A)) _clankerPosition.X -= _speed;
            if (k.IsKeyDown(Keys.D)) _clankerPosition.X += _speed;

            _clankerPosition.X = MathHelper.Clamp(_clankerPosition.X, 0, _graphics.PreferredBackBufferWidth - _clankerSize);
            _clankerPosition.Y = MathHelper.Clamp(_clankerPosition.Y, 0, _graphics.PreferredBackBufferHeight - _clankerSize);

            base.Update(gameTime);

            Rectangle clankerRect = new Rectangle(
                (int)_clankerPosition.X,
                (int)_clankerPosition.Y,
                _clankerSize,
                _clankerSize
            ); ;

                        // If colliding with wall, push clanker back
                        if (clankerRect.Intersects(_wallRect))
                        {
                            // Simple collision resolution: move clanker back opposite its velocity
                            if (k.IsKeyDown(Keys.W)) _clankerPosition.Y += _speed;
                            if (k.IsKeyDown(Keys.S)) _clankerPosition.Y -= _speed;
                            if (k.IsKeyDown(Keys.A)) _clankerPosition.X += _speed;
                            if (k.IsKeyDown(Keys.D)) _clankerPosition.X -= _speed;
                        }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_wallTexture, _wallRect, Color.Gray);

            _spriteBatch.Draw(
                _clankerTexture,
                new Rectangle((int)_clankerPosition.X, (int)_clankerPosition.Y, _clankerSize, _clankerSize),
                Color.CornflowerBlue

            );

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
