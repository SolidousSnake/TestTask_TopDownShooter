using _Project.Scripts.Config;
using _Project.Scripts.Core.Spawner;
using _Project.Scripts.Services;
using _Project.Scripts.UI;
using _Project.Scripts.Unit.Death;
using _Project.Scripts.Unit.Mover;
using _Project.Scripts.Unit.Rotator;
using _Project.Scripts.Weapon;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.Unit
{
    public sealed class PlayerFacade : MonoBehaviour
    {
        [Header("Combat")]
        [SerializeField] private UnitConfig _config;
        [SerializeField] private Gun _gun;
        
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidBody2D;
        [SerializeField] private Health.Health _health;
        
        [Inject]
        private void Construct(InputService inputService, CameraService cameraService, HealthView healthView
            , FailureWindow failureWindow, EnemySpawner enemySpawner)
        {
            var movement = new PhysicsMovement(_rigidBody2D, _config.MovementSpeed);
            var rotation = new CircleRotator(transform, _rigidBody2D, _config.RotationSpeed);
            var playerDeath = new PlayerDeath(failureWindow, enemySpawner);
            
            _health.Initialize(_config.Health);
            _health.HealthChanged += healthView.SetAmount;
            _health.Depleted += playerDeath.Die;
            
            cameraService.SetTarget(transform);
            
            inputService.MovementJoystickMoved += movement.Move;
            inputService.MovementJoystickMoved += rotation.Rotate;
            inputService.ShootButtonPressed += () => _gun.Use().Forget();
        }
    }
}