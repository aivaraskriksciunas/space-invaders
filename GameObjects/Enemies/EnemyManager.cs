using SFML.System;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using SpaceInvaders.GameObjects.Bullets;

namespace SpaceInvaders.GameObjects.Enemies
{
    class EnemyManager
    {
        public List<Enemy> Enemies { get; private set; }
        private Boundaries EnemyBoundary;

        private Clock SpawnClock;
        private float SpawnInterval = 1000;

        private Random randomGenerator;

        private BulletManager bulletManager;

        public EnemyManager( BulletManager bulletManager )
        {
            SpawnClock = new Clock();
            randomGenerator = new Random();
            Enemies = new List<Enemy>();

            this.bulletManager = bulletManager;
        }

        public void SetBoundaries( Boundaries enemyBoundary )
        {
            this.EnemyBoundary = enemyBoundary;
        }

        public void Update( float delta )
        {
            for ( int i = Enemies.Count - 1; i >= 0; i-- )
            {
                Enemies[i].Update( delta );

                if ( Enemies[i].Health <= 0 )
                {
                    Enemies.RemoveAt( i );
                }
            }

            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            if ( SpawnClock.ElapsedTime.AsMilliseconds() >= SpawnInterval )
            {
                SpawnEnemy();
                SpawnClock.Restart();
            }
        }

        private void SpawnEnemy()
        {
            Enemy newEnemy = new Enemy();
            newEnemy.SetPosition(
                randomGenerator.Next(
                    (int)EnemyBoundary.StartX, (int)EnemyBoundary.EndX
                ),
                -100 );

            Enemies.Add( newEnemy );
            
        }
    }
}
