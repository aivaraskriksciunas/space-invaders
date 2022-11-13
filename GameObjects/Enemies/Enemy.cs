using SpaceInvaders.GameObjects.Bullets;
using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects.Enemies
{
    class Enemy : ITakesBulletDamage
    {
        public float PosX { get; private set; }
        public float PosY { get; private set; }
        public int Health { get; private set; }

        public const float ENEMY_SIZE = 15;

        public Enemy( int health = 1 )
        {
            Health = health;
        }

        public bool OnBulletHit( Bullet bullet )
        {
            if ( bullet.BulletTarget != BulletTarget.ENEMY )
                return false;

            Health -= bullet.Damage;
            return true;
        }

        public void SetPosition( float posx, float posy )
        {
            PosX = posx;
            PosY = posy;
        }

        public void Update( float delta )
        {
            PosY += 20 * delta;
        }

        public Boundaries GetCollisionBoundaries()
        {
            return new Boundaries(
                PosX, PosY,
                PosX + ENEMY_SIZE, PosY + ENEMY_SIZE );
        }
    }
}
