using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;

namespace SpaceInvaders.Events
{
    enum Events
    {
        LEFT,
        RIGHT,
        MAIN_ACTION,
    }

    class UserEventManager
    {
        private Dictionary<Events, KeyBinding> keyBindings;
        private UserEventDispatcher eventDispatcher;

        public UserEventManager()
        {
            keyBindings = new Dictionary<Events, KeyBinding>();
            keyBindings[Events.LEFT] = new KeyBinding( Keyboard.Key.A, Keyboard.Key.Left );
            keyBindings[Events.RIGHT] = new KeyBinding( Keyboard.Key.D, Keyboard.Key.Right );
            keyBindings[Events.MAIN_ACTION] = new KeyBinding( Keyboard.Key.Space );
        }

        public UserEventDispatcher CreateEventDispatcher()
        {
            eventDispatcher = new UserEventDispatcher();
            return eventDispatcher;
        }

        public void ReadEvents( float delta )
        {
            foreach ( var item in keyBindings )
            {
                if ( item.Value.IsActive() )
                {
                    eventDispatcher.Dispatch( item.Key, delta );
                }
            }
        }
    }
}
