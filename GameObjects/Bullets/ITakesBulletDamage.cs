using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects.Bullets
{
    public interface ITakesBulletDamage
    {
        public bool OnBulletHit( Bullet bullet );

        public Boundaries GetCollisionBoundaries();
    }
}
