using _Project.Scripts.Bonus.Kits;
using _Project.Scripts.Config;
using _Project.Scripts.Unit.Death;
using _Project.Scripts.Unit.Mover;
using _Project.Scripts.Unit.Rotator;
using _Project.Scripts.Unit.States;
using _Project.Scripts.Unit.States.Enemy;
using _Project.Scripts.Weapon;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.Unit
{
    public sealed class EnemyFacade : MonoBehaviour
    {
        [Header("Combat")]
        [SerializeField] private UnitConfig _config;
        [SerializeField] private float _attackDistance;
        [SerializeField] private Melee _melee;
        
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidBody2D;
        [SerializeField] private Health.Health _health;
        
        [Header("Loot")]
        [SerializeField] private Medkit _medkitPrefab;
        [SerializeField] private int _dropChance;

        private StateMachine _stateMachine;
        private PhysicsMovement _movement;
        private CircleRotator _rotator;
        private PlayerFacade _playerFacade;
                
        
        [Inject]
        private void Construct(PlayerFacade playerFacade, Score score)
        {
            _movement = new PhysicsMovement(_rigidBody2D, _config.MovementSpeed);
            _rotator = new CircleRotator(transform, _rigidBody2D, _config.MovementSpeed);
            _playerFacade = playerFacade;

            var enemyDeath = new EnemyDeath(_medkitPrefab, _dropChance, this, score);
            
            _health.Initialize(_config.Health);
            _health.Depleted += enemyDeath.Die;
            
            RegisterStates();
        }

        private void RegisterStates()
        {
            _stateMachine = new StateMachine();
            _stateMachine.RegisterState(new ChaseTargetState(_stateMachine, _playerFacade.transform, transform
                                                            , _movement, _rotator, _attackDistance));
            _stateMachine.RegisterState(new AttackPlayerState(_stateMachine, _playerFacade.transform, transform
                                                            , _melee, _attackDistance));
            _stateMachine.Enter<ChaseTargetState>();
        }
        
        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackDistance);
        }
    }
}