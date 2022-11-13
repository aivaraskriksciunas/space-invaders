using SpaceInvaders.GameObjects.Bullets;
using SpaceInvaders.Utils;
using SFML.System;
using System;

namespace SpaceInvaders.GameObjects.Enemies
{
    class Enemy : ITakesBulletDamage
    {
        public float PosX { get; private set; }
        public float PosY { get; private set; }
        public int Health { get; private set; }

        public const float ENEMY_SIZE = 15;

        private int shootInterval;
        private Clock shootClock;

        public Enemy( int health = 1 )
        {
            Health = health;

            Random randomGen = new Random();
            shootInterval = randomGen.Next( 800, 3000 );
            shootClock = new Clock();
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

        public void Update( float delta, BulletManager bulletManager )
        {
            PosY += 20 * delta;

            if ( shootClock.ElapsedTime.AsMilliseconds() > shootInterval )
            {
                bulletManager.Shoot( PosX, PosY, (float)Math.PI * 1.5f, BulletTarget.PLAYER );
                shootClock.Restart();
            }
        }

        public Boundaries GetCollisionBoundaries()
        {
            return new Boundaries(
                PosX, PosY,
                PosX + ENEMY_SIZE, PosY + ENEMY_SIZE );
        }
    }
}
