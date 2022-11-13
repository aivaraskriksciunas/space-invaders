using SpaceInvaders.Utils;
using SpaceInvaders.Graphics;
using System;

namespace SpaceInvaders
{
    class Program
    {
        static int Main(string[] args)
        {
            Config.GetInstance().WindowWidth = 800;
            Config.GetInstance().WindowHeight = 600;

            if ( !GameResources.GetInstance().LoadResources() )
            {
                Console.WriteLine( "Exiting..." );
                return -1;
            }

            GameLoop game = new GameLoop( 
                Config.GetInstance().WindowWidth, 
                Config.GetInstance().WindowHeight );

            game.Start();
            return 0;
        }
    }

}
