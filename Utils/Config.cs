using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.Utils
{
    class Config
    {
        private static Config instance;

        public uint WindowWidth;
        public uint WindowHeight;

        private Config() { }

        public static Config GetInstance()
        {
            if ( instance == null )
                instance = new Config();

            return instance;
        }
    }
}
