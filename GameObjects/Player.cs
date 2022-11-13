using System;
using SpaceInvaders.Events;
using SpaceInvaders.Utils;
using SFML.System;
using SpaceInvaders.GameObjects.Bullets;
using System.Collections.Generic;

namespace SpaceInvaders.GameObjects
{
    class Player : ITakesBulletDamage
    {
        public float PosX { get; private set; }
        public float PosY { get; private set; }
        public int Health { get; private set; }

        public const float PLAYER_SIZE = 20;
        private const float MOVE_SPEED = 400;
        private const int SHOOT_INTERVAL = 50;

        private Clock ShootClock;

        private Boundaries MoveBoundaries;

        private BulletManager bulletManager;

        public Player( BulletManager bulletManager )
        {
            ShootClock = new Clock();
            this.bulletManager = bulletManager;
            Health = 10;
        }

        public void AttachListeners( UserEventDispatcher eventDispatcher )
        {
            eventDispatcher.Listen( Events.Events.LEFT, MoveLeft );
            eventDispatcher.Listen( Events.Events.RIGHT, MoveRight );
            eventDispatcher.Listen( Events.Events.MAIN_ACTION, Shoot );
        }

        public void SetPosition( int x, int y )
        {
            PosX = x; PosY = y;
        }

        public void SetBoundaries( Boundaries bound )
        {
            MoveBoundaries = bound;
        }

        private void MoveLeft( float delta )
        {
            float newx = PosX;
            newx -= MOVE_SPEED * delta;

            if ( MoveBoundaries.IsInside( newx, PosY ) )
                PosX = newx;
        }

        private void MoveRight( float delta )
        {
            float newx = PosX;
            newx += MOVE_SPEED * delta;

            if ( MoveBoundaries.IsInside( newx, PosY ) )
                PosX = newx;
        }

        private void Shoot( float delta )
        {
            if ( ShootClock.ElapsedTime.AsMilliseconds() <= SHOOT_INTERVAL )
                return;

            ShootClock.Restart();

            bulletManager.Shoot( PosX, PosY, (float)(Math.PI / 2), BulletTarget.ENEMY );
        }

        public bool OnBulletHit( Bullet bullet )
        {
            if ( bullet.BulletTarget != BulletTarget.PLAYER )
                return false;

            Health -= bullet.Damage;
            return true;
        }

        public Boundaries GetCollisionBoundaries()
        {
            return new Boundaries(
                PosX, PosY,
                PosX + PLAYER_SIZE, PosY + PLAYER_SIZE );
        }
    }
}
