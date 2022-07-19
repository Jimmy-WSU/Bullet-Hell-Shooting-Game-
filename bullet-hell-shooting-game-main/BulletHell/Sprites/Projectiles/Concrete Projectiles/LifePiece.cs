namespace BulletHellShootingGame.Sprites.Projectiles.Concrete_Projectiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BulletHellShootingGame.Sprites.Movement_Patterns;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class LifePiece : Projectile
    {
        public LifePiece(Texture2D texture, Color color, MovementPattern movement, int damage, int healing)
            : base(texture, color, movement, damage, healing)
        {
        }
    }
}
