using System;
using System.Collections.Generic;
using System.Text;
using SpaceInvaders.Graphics;
using SpaceInvaders.Events;

namespace SpaceInvaders.Scenes
{
    enum Scenes
    {
        MAIN_SCENE,
        GAME_OVER_SCENE,
    }

    class SceneSwitcher
    {
        private Scene currentScene;
        private RenderQueue renderQueue;
        private UserEventManager eventManager;

        public SceneSwitcher( RenderQueue renderQueue, UserEventManager eventManager )
        {
            this.renderQueue = renderQueue;
            this.eventManager = eventManager;
        }

        public void SetScene( Scenes scene )
        {
            renderQueue.ClearQueue();

            switch ( scene )
            {
                case Scenes.MAIN_SCENE:
                    currentScene = new MainScene();
                    break;
                case Scenes.GAME_OVER_SCENE:
                    currentScene = new GameOverScene();
                    break;
            }

            currentScene.SetSceneSwitcher( this );
            currentScene.InitializeScene( renderQueue, eventManager.CreateEventDispatcher() );
        }

        public void UpdateCurrentScene( float delta )
        {
            currentScene.UpdateScene( delta );
        }
    }
}
