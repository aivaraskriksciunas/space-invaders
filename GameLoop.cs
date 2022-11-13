using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using SpaceInvaders.Graphics;
using SpaceInvaders.Scenes;
using SpaceInvaders.Events;

namespace SpaceInvaders
{
    class GameLoop
    {
        private RenderWindow window;
        private RenderQueue renderQueue;
        private UserEventManager eventManager;
        private SceneSwitcher sceneSwitcher;

        public GameLoop( uint w_width, uint w_height )
        {
            window = new RenderWindow( new VideoMode( w_width, w_height ), "Space Invaders" );
            renderQueue = new RenderQueue();
            eventManager = new UserEventManager();
            sceneSwitcher = new SceneSwitcher( renderQueue, eventManager );
            sceneSwitcher.SetScene( Scenes.Scenes.MAIN_SCENE );

            window.Closed += OnWindowClose;
        }

        public void Start()
        {
            Clock frameClock = new Clock();

            while ( window.IsOpen )
            {
                window.Clear( Color.Black );
                window.DispatchEvents();

                renderQueue.Render( window );

                float delta = frameClock.ElapsedTime.AsSeconds();
                sceneSwitcher.UpdateCurrentScene( delta );
                eventManager.ReadEvents( delta );
                frameClock.Restart();

                window.Display();
            }
        }

        private void OnWindowClose( object sender, EventArgs e )
        {
            window.Close();
        }
    }
}
