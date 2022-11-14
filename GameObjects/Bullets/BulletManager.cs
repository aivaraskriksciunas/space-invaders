using System;
using System.Collections.Generic;
using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects.Bullets
{
    public class BulletManager
    {
        public List<Bullet> Bullets { get; private set; }
        private Boundaries ScreenBoundary;

        public BulletManager()
        {
            Bullets = new List<Bullet>();
        }

        public void SetScreenBoundaries( Boundaries bound )
        {
            ScreenBoundary = bound;
        }

        public void Update( float delta, List<ITakesBulletDamage> colliders )
        {
            for ( int i = Bullets.Count - 1; i >= 0; i-- )
            {
                Bullets[i].Update( delta );

                bool shouldRemove = false;
                if ( CheckCollisions( Bullets[i], colliders ) )
                    shouldRemove = true;

                if ( !ScreenBoundary.IsInside( Bullets[i].PosX, Bullets[i].PosY ) )
                    shouldRemove = true;

                if ( shouldRemove )
                {
                    Bullets.RemoveAt( i );
                }
            }
        }

        public void Shoot( float fromX, float fromY, float direction, BulletTarget bulletTarget = BulletTarget.ENEMY )
        {
            Bullets.Add( new Bullet( fromX, fromY, direction, bulletTarget ) );
        }

        private bool CheckCollisions( Bullet bullet, List<ITakesBulletDamage> colliders )
        {
            foreach ( var collider in colliders )
            {
                if ( collider.GetCollisionBoundaries().Overlaps( bullet.GetBoundaries() ) )
                {
                    if ( !collider.OnBulletHit( bullet ) ) continue;

                    return true;
                }
            }

            return false;
        }
    }
}
