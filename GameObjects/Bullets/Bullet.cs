using System;
using SpaceInvaders.Utils;

namespace SpaceInvaders.GameObjects.Bullets
{
    enum BulletTarget {
        PLAYER,
        ENEMY
    }

    class Bullet
    {
        public float PosX { get; private set; }
        public float PosY { get; private set; }
        public BulletTarget BulletTarget { get; private set; }
        public int Damage { get; private set; }

        private float SpeedX;
        private float SpeedY;

        private const float BULLET_SPEED = 200;

        public const float BULLET_WIDTH = 5;
        public const float BULLET_HEIGHT = 8;

        public Bullet( float x, float y, float dir, BulletTarget bulletTarget )
        {
            PosX = x;
            PosY = y;

            SpeedY = -(float)Math.Sin( dir ) * BULLET_SPEED;
            SpeedX = (float)Math.Cos( dir ) * BULLET_SPEED;

            BulletTarget = bulletTarget;
            Damage = 1;
        }

        public void Update( float delta )
        {
            PosY += SpeedY * delta;
            PosX += SpeedX * delta;
        }

        public Boundaries GetBoundaries()
        {
            return new Boundaries(
                PosX, PosY,
                PosX + BULLET_WIDTH, PosY + BULLET_HEIGHT );
        }
    }
}
