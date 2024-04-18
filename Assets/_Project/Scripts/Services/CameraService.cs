using UnityEngine;
using VContainer.Unity;

namespace _Project.Scripts.Services
{
    public sealed class CameraService : IFixedTickable
    {
        private readonly Camera _camera;
        private readonly Vector3 _offset;
        
        private Transform _target;

        public CameraService(Vector3 offset, Camera camera)
        {
            _offset = offset;
            _camera = camera;
        }
        
        public void SetTarget(Transform target) => _target = target;

        public void FixedTick() => FollowTarget();

        private void FollowTarget()
        {
            if (_target == null)
                return;

            var nextPosition = _target.position + _offset;
            _camera.transform.position = nextPosition;
        }
    }
}