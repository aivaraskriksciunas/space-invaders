using SFML.Window;

namespace SpaceInvaders.Events
{
    class KeyBinding
    {
        private Keyboard.Key? primaryKey;
        private Keyboard.Key? secondaryKey;

        public KeyBinding() {}
        public KeyBinding( Keyboard.Key primaryKey )
        {
            setPrimaryKey( primaryKey );
        }
        public KeyBinding( Keyboard.Key primaryKey, Keyboard.Key secondaryKey )
        {
            setPrimaryKey( primaryKey );
            setSecondaryKey( secondaryKey );
        }

        public void setPrimaryKey( Keyboard.Key key )
        {
            primaryKey = key;
        }

        public void setSecondaryKey( Keyboard.Key key )
        {
            secondaryKey = key;
        }

        public bool IsActive()
        {
            if ( primaryKey != null )
            {
                if ( Keyboard.IsKeyPressed( (Keyboard.Key)primaryKey ) )
                    return true;
            }

            if ( secondaryKey != null )
            {
                if ( Keyboard.IsKeyPressed( (Keyboard.Key)secondaryKey ) )
                    return true;
            }

            return false;
        }

    }
}
