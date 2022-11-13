using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.Events
{
    interface IKeyEventListener
    {
        public void OnKeyDown( double delta );
    }
}
