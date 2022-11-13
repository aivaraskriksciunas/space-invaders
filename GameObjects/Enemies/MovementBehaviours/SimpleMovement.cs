using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvaders.GameObjects.Enemies.MovementBehaviours
{
    class SimpleMovement : IMovementBehaviour
    {
        private float MoveSpeed;

        public SimpleMovement( float moveSpeed )
        {
            MoveSpeed = moveSpeed;
        }


    }
}
