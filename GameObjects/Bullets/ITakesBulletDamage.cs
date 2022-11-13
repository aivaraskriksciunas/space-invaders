using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects.Bullets
{
    interface ITakesBulletDamage
    {
        public bool OnBulletHit( Bullet bullet );

        public Boundaries GetCollisionBoundaries();
    }
}
