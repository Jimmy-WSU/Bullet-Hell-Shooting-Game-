namespace BulletHellShootingGame.Sprites.Projectiles.Concrete_Projectiles
{
    using BulletHellShootingGame.Sprites.Movement_Patterns;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Bullet : Projectile
    {
        public Bullet(Texture2D texture, Color color, MovementPattern movement, int damage, int healing)
            : base(texture, color, movement, damage, healing)
        {
        }
    }
}