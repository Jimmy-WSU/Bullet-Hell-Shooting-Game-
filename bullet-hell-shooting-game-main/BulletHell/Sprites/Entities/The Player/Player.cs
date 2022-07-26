﻿namespace BulletHellShootingGame.Sprites.The_Player
{
    using System.Collections.Generic;
    using BulletHellShootingGame.Sprites.Entities;
    using BulletHellShootingGame.Sprites.Entities.Enemies;
    using BulletHellShootingGame.Sprites.Movement_Patterns;
    using BulletHellShootingGame.Sprites.Movement_Patterns.Concrete_Movement_Patterns;
    using BulletHellShootingGame.Sprites.Projectiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    internal class Player : Entity
    {
        public bool SlowMode;
        public bool Invincible;
        private double initialSpawnTime;
        private bool spawning;
        private bool resetGameTime = true;

        private KeyboardState currentKey;
        private KeyboardState previousKey;

        public Player(Texture2D texture, Color color, MovementPattern movement, Projectile projectile)
            : base(texture, color, movement, projectile)
        {
            this.spawning = true;
            this.Invincible = true;
        }

        // Serves as hitbox; Player hitbox is smaller than enemies'
        public override Rectangle Rectangle
        {
            get => new Rectangle(
                    new Point((int)this.Movement.Position.X, (int)this.Movement.Position.Y),
                    new Point(this.Texture.Width / 6, this.Texture.Height / 6));
        }

        public override void Update(GameTime gameTime, List<Sprite> enemies)
        {
            if (this.resetGameTime)
            {
                this.initialSpawnTime = gameTime.TotalGameTime.TotalSeconds;
                this.resetGameTime = !this.resetGameTime;
            }

            this.previousKey = this.currentKey;
            this.currentKey = Keyboard.GetState();

            this.SetInvincibility(gameTime);

            this.Attack(enemies);

            int previousSpeed = this.Movement.CurrentSpeed;

            // check if slow speed
            this.SlowMode = this.IsSlowPressed();

            this.Move();
            this.Movement.CurrentSpeed = previousSpeed;
        }

        public override void OnCollision(Sprite sprite)
        {
            this.Movement.ZeroXVelocity();
            this.Movement.ZeroYVelocity();

            if (this.Invincible == false)
            {
                if (sprite is Projectile projectile && projectile.Parent != this)
                {
                    this.IsRemoved = true;
                    if (projectile.Texture.Name == "LifePiece")
                    {
                        this.IsRemoved = false;
                        this.AddLive = true;
                    }
                }
                else if (sprite is Enemy)
                {
                    this.IsRemoved = true;
                }
            }
        }

        public bool IsSlowPressed()
        {
            if (this.currentKey.IsKeyDown(Keys.LeftShift))
            {
                this.Movement.CurrentSpeed = this.Movement.Speed / 2;
                return true;
            }

            return false;
        }

        public void Respawn(GameTime gameTime)
        {
            ((PlayerInput)this.Movement).Respawn();
            this.IsRemoved = false;
            this.AddLive = false;
            this.spawning = true;
            this.Invincible = true;
            this.initialSpawnTime = gameTime.TotalGameTime.TotalSeconds;
        }

        private void SetInvincibility(GameTime gameTime)
        {
            if (this.spawning == true)
            {
                // palyer health is 10
                if ((gameTime.TotalGameTime.TotalSeconds - this.initialSpawnTime) >= 5)
                {
                    this.Invincible = false;
                    this.spawning = false;
                }
            }
            else
            {
                if (this.currentKey.IsKeyDown(Keys.OemTilde) && !this.previousKey.IsKeyDown(Keys.OemTilde))
                {
                    this.Invincible = !this.Invincible;
                }
            }
        }

        private new void Attack(List<Sprite> sprites)
        {
            if (this.currentKey.IsKeyDown(Keys.Space) && this.previousKey.IsKeyUp(Keys.Space))
            {
                sprites.ForEach((e) => { e.isFromPlayer = true; });
                base.Attack(sprites);
            }
        }

        private void Move()
        {
            this.Movement.Move();
        }
    }
}
