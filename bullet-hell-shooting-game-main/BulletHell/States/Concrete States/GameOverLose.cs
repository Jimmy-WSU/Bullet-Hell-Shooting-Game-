﻿namespace BulletHellShootingGame.States
{
    using System;
    using System.Collections.Generic;
    using BulletHellShootingGame.Controls;
    using BulletHellShootingGame.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameOverLose : State
    {
        private List<Component> components;
        private Texture2D gameOverTexture;

        public GameOverLose()
          : base()
        {
            var buttonTexture = TextureFactory.GetTexture("Controls/Button");
            var buttonFont = TextureFactory.GetSpriteFont("Fonts/Font");
            this.gameOverTexture = TextureFactory.GetTexture("Titles/GameOver");

            var returnButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Main Menu",
            };

            returnButton.Click += this.ReturnButton_Click;

            var exitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Exit Game",
            };

            exitGameButton.Click += this.ExitGameButton_Click;

            this.components = new List<Component>()
            {
                returnButton,
                exitGameButton,
            };
        }

        public object GraphicsDevice { get; private set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicManagers.GraphicsDevice.Clear(Color.Red);

            spriteBatch.Begin();
            spriteBatch.Draw(this.gameOverTexture, new Vector2(90, 50), Color.Black);

            foreach (var component in this.components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
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
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new MenuState());
        }

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ExitEvent(null, e);
        }
    }
}
