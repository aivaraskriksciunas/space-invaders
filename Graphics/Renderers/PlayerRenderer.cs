using SFML.Graphics;
using SFML.System;
using SpaceInvaders.GameObjects;
using System;

namespace SpaceInvaders.Graphics.Renderers
{
    class PlayerRenderer : IRenderable
    {
        Player player;
        RectangleShape shape;

        public PlayerRenderer( Player player )
        {
            this.player = player;
            shape = new RectangleShape();
            shape.Size = new Vector2f( Player.PLAYER_SIZE, Player.PLAYER_SIZE );
            shape.FillColor = Color.White;
            shape.Origin = new Vector2f( 10, 10 );
        }

        public void Render( RenderWindow window )
        {
            shape.Position = new Vector2f( player.PosX, player.PosY );
            window.Draw( shape );
        }
    }
}
