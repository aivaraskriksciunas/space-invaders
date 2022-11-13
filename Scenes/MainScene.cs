using SpaceInvaders.Graphics;
using SpaceInvaders.Graphics.UI;
using SpaceInvaders.Graphics.Renderers;
using SpaceInvaders.Events;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.Enemies;
using SpaceInvaders.Utils;
using SpaceInvaders.GameObjects.Bullets;
using System.Collections.Generic;

namespace SpaceInvaders.Scenes
{
    class MainScene : Scene
    {
        private Player player;
        private EnemyManager enemyManager;
        private BulletManager bulletManager;
        private UIText healthCounterText;

        public override void InitializeScene( RenderQueue renderQueue, UserEventDispatcher eventManager )
        {
            int w_width = (int)Config.GetInstance().WindowWidth;
            int w_height = (int)Config.GetInstance().WindowHeight;

            Boundaries playerBoundaries = new Boundaries(
                0, 0, 
                w_width, w_height );

            Boundaries enemyBoundary = new Boundaries(
                0, -1000,
                w_width, w_height - 200 );

            Boundaries bulletBoundaries = new Boundaries(
                -50, -50,
                w_width + 50, w_height + 50 );

            // Create managers
            bulletManager = new BulletManager();
            bulletManager.SetScreenBoundaries( bulletBoundaries );

            enemyManager = new EnemyManager( bulletManager  );
            enemyManager.SetBoundaries( enemyBoundary );

            // Create objects
            player = new Player( bulletManager );
            player.SetPosition( w_width / 2, w_height - 100 );
            player.SetBoundaries( playerBoundaries );
            player.AttachListeners( eventManager );

            // Add objects to render queue
            renderQueue.AddToQueue( new PlayerRenderer( player ) );
            renderQueue.AddToQueue( new EnemyRenderer( enemyManager ) );
            renderQueue.AddToQueue( new BulletRenderer( bulletManager ) );

            // Create UI Elements
            healthCounterText = new UIText( 20, 20, 16 );
            renderQueue.AddToQueue( healthCounterText );
        }

        public override void UpdateScene( float delta )
        {
            List<ITakesBulletDamage> bulletColliders = new List<ITakesBulletDamage>();
            bulletColliders.AddRange( enemyManager.Enemies );
            bulletColliders.Add( player );

            enemyManager.Update( delta );
            bulletManager.Update( delta, bulletColliders );

            healthCounterText.SetDisplayText( "Health: " + player.Health );
            if ( player.Health <= 0 )
            {
                sceneSwitcher.SetScene( Scenes.GAME_OVER_SCENE );
            }
        }
    }
}
