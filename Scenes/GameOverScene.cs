using SpaceInvaders.Events;
using SpaceInvaders.Graphics;
using System;
using System.Collections.Generic;
using SpaceInvaders.Graphics.UI;
using SpaceInvaders.Utils;

namespace SpaceInvaders.Scenes
{
    class GameOverScene : Scene
    {
        private UIText gameOverText;
        private UIText pressSpaceText;

        public override void InitializeScene( RenderQueue renderQueue, UserEventDispatcher eventDispatcher )
        {
            eventDispatcher.Listen( Events.Events.MAIN_ACTION, OnPlayGame );

            float screenCenter = Config.GetInstance().WindowWidth / 2;
            gameOverText = new UIText( screenCenter, 200, 30, "GAME OVER" );
            pressSpaceText = new UIText( screenCenter, 400, 18, "Press SPACE to try again" );

            gameOverText.CenterText();
            pressSpaceText.CenterText();

            renderQueue.AddToQueue( gameOverText );
            renderQueue.AddToQueue( pressSpaceText );
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
