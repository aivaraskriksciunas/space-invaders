using System;
using System.Collections.Generic;
using System.Text;
using SpaceInvaders.Graphics;
using SpaceInvaders.Events;

namespace SpaceInvaders.Scenes
{
    abstract class Scene
    {
        protected SceneSwitcher sceneSwitcher;

        public void SetSceneSwitcher( SceneSwitcher sceneSwitcher )
        {
            this.sceneSwitcher = sceneSwitcher;
        }

        abstract public void InitializeScene( RenderQueue renderQueue, UserEventDispatcher eventDispatcher );

        abstract public void UpdateScene( float delta );
    }
}
