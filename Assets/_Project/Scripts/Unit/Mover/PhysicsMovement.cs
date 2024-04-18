using UnityEngine;

namespace _Project.Scripts.Unit.Mover
{
    public class PhysicsMovement
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly float _movementSpeed;
         
        public PhysicsMovement(Rigidbody2D rigidBody, float movementSpeed)
        {
            _rigidBody = rigidBody;
            _movementSpeed = movementSpeed;
        }
        
        public void Move(Vector2 direction)
        {
            _rigidBody.velocity = direction * _movementSpeed;
        }
    }
}