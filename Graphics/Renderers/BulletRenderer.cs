using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SpaceInvaders.GameObjects.Bullets;
using SpaceInvaders.Graphics;

namespace SpaceInvaders.Graphics.Renderers
{
    class BulletRenderer : IRenderable
    {
        private BulletManager bulletManager;

        public BulletRenderer( BulletManager bulletManager )
        {
            this.bulletManager = bulletManager;
        }

        public void Render( RenderWindow window )
        {
            RectangleShape rect = new RectangleShape();
            rect.FillColor = Color.Yellow;
            rect.Size = new Vector2f( Bullet.BULLET_WIDTH, Bullet.BULLET_HEIGHT );

            foreach ( var bullet in bulletManager.Bullets )
            {
                rect.Position = new Vector2f( bullet.PosX, bullet.PosY );
                window.Draw( rect );
            }
        }
    }
}
