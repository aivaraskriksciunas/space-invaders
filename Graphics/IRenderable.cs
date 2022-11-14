using System;
using SFML.Graphics;

namespace SpaceInvaders.Graphics
{
    public interface IRenderable
    {
        public void Render( RenderWindow window );
    }
}
