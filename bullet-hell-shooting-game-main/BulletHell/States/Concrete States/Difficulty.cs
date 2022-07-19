namespace BulletHellShootingGame.States
{
    using System;
    using System.Collections.Generic;
    using BulletHellShootingGame.Controls;
    using BulletHellShootingGame.Game_Utilities;
    using BulletHellShootingGame.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DifficultyState : State
    {
        private List<Component> components;
        private Texture2D selectDifficultyTexture;

        public DifficultyState()
          : base()
        {
            var buttonTexture = TextureFactory.GetTexture("Controls/Button");
            var buttonFont = TextureFactory.GetSpriteFont("Fonts/Font");
            this.selectDifficultyTexture = TextureFactory.GetTexture("Titles/SelectDifficulty");

            var newGameEasyButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Slow Speed",
            };

            newGameEasyButton.Click += this.NewGameEasyButton_Click;

            var newGameNormalButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Normal Speed",
            };

            newGameNormalButton.Click += this.NewGameNormalButton_Click;


            var returnButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Main Menu",
            };

            returnButton.Click += this.QuitGameButton_Click;

            this.components = new List<Component>()
              {
                newGameEasyButton,
                newGameNormalButton,
                returnButton,
              };
        }

        public object GraphicsDevice { get; private set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicManagers.GraphicsDevice.Clear(Color.DarkGray);

            spriteBatch.Begin();
            spriteBatch.Draw(this.selectDifficultyTexture, new Vector2(40, 50), Color.White);

            foreach (var component in this.components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in this.components)
            {
                component.Update(gameTime);
            }
        }

        public override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicManagers.GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }


        private void NewGameNormalButton_Click(object sender, EventArgs e)
        {
            GameLoader.LoadGameDictionary("demo");

            StateManager.ChangeState(new GameState());
        }

        private void NewGameEasyButton_Click(object sender, EventArgs e)
        {
            GameLoader.LoadGameDictionary("demo");

            StateManager.ChangeState(new GameState());
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new MenuState());
        }
    }
}
