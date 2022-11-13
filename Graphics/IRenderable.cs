using System;
using SFML.Graphics;

namespace SpaceInvaders.Graphics
{
    interface IRenderable
    {
        public void Render( RenderWindow window );
    }
}
