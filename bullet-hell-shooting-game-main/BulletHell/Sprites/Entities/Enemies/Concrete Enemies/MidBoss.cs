namespace BulletHellShootingGame.Sprites.Entities.Enemies.Concrete_Enemies
{
    using System.Collections.Generic;
    using BulletHellShootingGame.Sprites.Movement_Patterns;
    using BulletHellShootingGame.Sprites.Projectiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class MidBoss : Enemy
    {
        // private int previoustime = 0;
        private float timer1;
        private float timer2;
        private float timer3;
        private double[] timers;
        public MidBoss(Texture2D texture, Color color, MovementPattern movement, Projectile projectile, int lifeSpan)
            : base(texture, color, movement, projectile, lifeSpan)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
            /*
                        if (this.previousTime != (int)gameTime.TotalGameTime.TotalSeconds)
                        {*/
            this.timer1 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer1 > .2f)
            {
                this.timer1 = 0;
                this.Attack(sprites);
            }
            
            /*this.timer1 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer1 > .8f)
            {
                this.timer1 = 0;
                this.Attack(sprites);
            }

            this.timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer2 > .9f)
            {
                this.timer2 = 0;
                this.Attack(sprites);
            }

            this.timer3 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer3 > 1f)
            {
                this.timer3 = 0;
                this.Attack(sprites);
            }*/
            /*this.Attack(sprites);*/
            /*}*/

            // this.previousTime = (int)gameTime.TotalGameTime.TotalSeconds;
        }

/*        public new void Attack(List<Sprite> sprites)
        {
            // TODO: needs refactoring and moved to Attack object
            *//*Projectile newProjectile = this.Projectile.Clone() as Projectile;
            newProjectile.Movement = this.Projectile.Movement.Clone() as MovementPattern;
            newProjectile.Movement.Velocity = this.Movement.Velocity;
            newProjectile.Movement.Position = this.Movement.Position;
            int projectileSpeed = newProjectile.Movement.Speed;
            newProjectile.Movement.Velocity.Normalize();

            Vector2 velocity = newProjectile.Movement.Velocity;
            velocity.X *= projectileSpeed;
            velocity.Y *= projectileSpeed;
            velocity.Y += 1;
            velocity.X += 1;
            newProjectile.Movement.Velocity = velocity;
            newProjectile.Parent = this;

            sprites.Add(newProjectile);*//*
            Projectile newProjectile = this.Projectile.Clone() as Projectile;
            int projectileSpeed = newProjectile.Movement.Speed;
            newProjectile.Movement = this.Projectile.Movement.Clone() as MovementPattern;
            newProjectile.Movement.Parent = newProjectile;
            Vector2 velocity = newProjectile.Movement.Velocity;
            velocity.Normalize();
            velocity.X *= projectileSpeed;
            velocity.Y *= projectileSpeed;
            newProjectile.Movement.Velocity = velocity;
            newProjectile.Movement.Position = new Vector2(this.Rectangle.Center.X, this.Rectangle.Center.Y);
            newProjectile.Parent = this;
            sprites.Add(newProjectile);
        }*/
    }
}
