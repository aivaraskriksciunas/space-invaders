using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace SpaceInvaders.Graphics
{
    public class RenderQueue
    {
        public List<IRenderable> queue { get; private set; }

        public RenderQueue()
        {
            queue = new List<IRenderable>();
        }

        public void ClearQueue()
        {
            queue.Clear();
        }

        public void AddToQueue( IRenderable renderable )
        {
            queue.Add( renderable );
        }

        public void Render( RenderWindow window )
        {
            foreach ( IRenderable obj in queue )
            {
                obj.Render( window );
            }
        }
    }
}
