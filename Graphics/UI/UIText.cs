using SFML.Graphics;
using SFML.System;
using SpaceInvaders.Graphics;

namespace SpaceInvaders.Graphics.UI
{
    class UIText : IRenderable
    {
        private Text text;
        
        public UIText( float posx, float posy, uint charSize, string t = "" )
        {
            text = new Text();
            text.Font = GameResources.GetInstance().MainFont;
            text.FillColor = Color.White;
            text.Position = new Vector2f( posx, posy );
            text.DisplayedString = t;
            text.CharacterSize = charSize;
        }

        public void CenterText()
        {
            FloatRect bounds = text.GetGlobalBounds();
            text.Position = new Vector2f(
                text.Position.X - bounds.Width / 2,
                text.Position.Y );
        }

        public void SetDisplayText( string txt )
        {
            text.DisplayedString = txt;
        }

        public void Render( RenderWindow window )
        {
            window.Draw( text );
        }
    }
}
