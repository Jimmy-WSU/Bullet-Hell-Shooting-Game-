namespace BulletHellShootingGame.Sprites
{
    using BulletHellShootingGame.Sprites.Projectiles;

    internal abstract class Attack
    {
        private Projectile projectile;

        public virtual void DoAttack()
        {
        }
    }
}
