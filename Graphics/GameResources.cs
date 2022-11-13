using SFML.Graphics;
using System;

namespace SpaceInvaders.Graphics
{
    class GameResources
    {
        // Singleton
        private static GameResources instance;

        private GameResources() { }

        public static GameResources GetInstance()
        {
            if ( instance == null )
                instance = new GameResources();

            return instance;
        }

        // Class body
        public Font MainFont { get; private set; }

        public bool LoadResources()
        {
            try
            {
                MainFont = new Font( "Assets/press-start.ttf" );
            }
            catch ( SFML.LoadingFailedException e )
            {
                Console.Error.WriteLine( "Could not load game resources. Try again." );
                Console.Error.WriteLine( e.Message );
                return false;
            }

            return true;
        }
    }
}
