using UnityEngine;

namespace _Project.Scripts.Unit.Rotator
{
    public sealed class CircleRotator
    {
        private readonly Transform _body;
        private readonly Rigidbody2D _rigidBody;
        private readonly float _rotationSpeed;

        public CircleRotator(Transform body, Rigidbody2D rigidBody, float rotationSpeed)
        {
            _body = body;
            _rigidBody = rigidBody;
            _rotationSpeed = rotationSpeed;
        }

        public void Rotate(Vector2 value)
        {
            if(value == Vector2.zero)
                return;
            
            var targetRotation = Quaternion.LookRotation(_body.forward, value);
            var rotation = Quaternion.RotateTowards(_body.rotation, targetRotation, _rotationSpeed);
            
            _rigidBody.MoveRotation(rotation);
        }
    }
}