namespace BulletHellShootingGame.Sprites.Entities.Enemies.Concrete_Enemies
{
    using System.Collections.Generic;
    using BulletHellShootingGame.Sprites.Movement_Patterns;
    using BulletHellShootingGame.Sprites.Projectiles;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using BulletHellShootingGame.Sprites.The_Player;

    internal class LifePiecer : Enemy
    {
        private float timer1;
        private Player player;
        public LifePiecer(Texture2D texture, Color color, MovementPattern movement, Projectile projectile, int lifeSpan)
            : base(texture, color, movement, projectile, lifeSpan)
        {
            /*this.player.AddLive = true;*/
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
            this.timer1 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer1 > .7f)
            {
                this.timer1 = 0;
                this.Heal(sprites);
            }
        }
    }
}
