using SFML.Graphics;
using SFML.System;
using SpaceInvaders.GameObjects.Enemies;

namespace SpaceInvaders.Graphics.Renderers
{
    class EnemyRenderer : IRenderable
    {
        private EnemyManager manager;

        public EnemyRenderer( EnemyManager manager )
        {
            this.manager = manager;
        }

        public void Render( RenderWindow window )
        {
            foreach ( var enemy in manager.Enemies )
            {
                DrawEnemy( window, enemy );
            }
        }

        private void DrawEnemy( RenderWindow window, Enemy enemy )
        {
            RectangleShape rect = new RectangleShape();
            rect.Position = new Vector2f( enemy.PosX, enemy.PosY );
            rect.Size = new Vector2f( Enemy.ENEMY_SIZE, Enemy.ENEMY_SIZE );
            rect.FillColor = Color.Red;

            window.Draw( rect );
        }
    }
}
