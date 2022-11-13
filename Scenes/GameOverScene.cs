using SpaceInvaders.Events;
using SpaceInvaders.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.Scenes
{
    class GameOverScene : Scene
    {
        public override void InitializeScene( RenderQueue renderQueue, UserEventDispatcher eventDispatcher )
        {
            eventDispatcher.Listen( Events.Events.MAIN_ACTION, OnPlayGame );
        }

        public void OnPlayGame( float delta )
        {
            sceneSwitcher.SetScene( Scenes.MAIN_SCENE );
        }

        public override void UpdateScene( float delta )
        {

        }
    }
}
