using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        private List<Rectangle> _walls; 

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
            _clankerTexture = new Texture2D(GraphicsDevice, 1, 1);
            _clankerTexture.SetData(new[] { Color.CornflowerBlue });
            _wallTexture = new Texture2D(GraphicsDevice, 1, 1);
            _wallTexture.SetData(new[] { Color.Gray });

            int screenWidth = _graphics.PreferredBackBufferWidth;
            int screenHeight = _graphics.PreferredBackBufferHeight;

            _walls = new List<Rectangle>
{
                // Top wall
                new Rectangle(67, 67, 67, 67),

                // Bottom wall
                new Rectangle(100, 300, 500, 25),

                // Left wall
                new Rectangle(60, 250, 20, 150),

                // Right wall
                new Rectangle(680, 250, 20, 320),

                // Middle vertical wall
                new Rectangle(400, 40, 20, 160)
            };
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

            // Clanker rectangle
            Rectangle clankerRect = new Rectangle(
                (int)_clankerPosition.X,
                (int)_clankerPosition.Y,
                _clankerSize,
                _clankerSize
            );

            // Check each wall for collisions
            foreach (var wall in _walls)
            {
                if (clankerRect.Intersects(wall))
                {
                    // Simple collision response
                    if (k.IsKeyDown(Keys.W)) _clankerPosition.Y += _speed;
                    if (k.IsKeyDown(Keys.S)) _clankerPosition.Y -= _speed;
                    if (k.IsKeyDown(Keys.A)) _clankerPosition.X += _speed;
                    if (k.IsKeyDown(Keys.D)) _clankerPosition.X -= _speed;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            foreach (var wall in _walls)
            {
                _spriteBatch.Draw(_wallTexture, wall, Color.Gray);
            }

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
