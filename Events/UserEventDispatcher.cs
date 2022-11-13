using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.Events
{
    delegate void OnGameEvent( float delta );

    class UserEventDispatcher
    {
        private Dictionary<Events, OnGameEvent> eventListeners;

        public UserEventDispatcher()
        {
            eventListeners = new Dictionary<Events, OnGameEvent>();
        }

        public void Listen( Events ev, OnGameEvent listener )
        {
            eventListeners[ev] = listener;
        }

        public void StopListening( Events ev )
        {
            eventListeners.Remove( ev );
        }

        public void Dispatch( Events ev, float delta )
        {
            if ( !eventListeners.ContainsKey( ev ) ) return;

            eventListeners[ev]?.Invoke( delta );
        }
    }
}
