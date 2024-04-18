using _Project.Scripts.Unit.Mover;
using _Project.Scripts.Unit.Rotator;
using UnityEngine;

namespace _Project.Scripts.Unit.States.Enemy
{
    public sealed class ChaseTargetState : IUpdateableState
    {
        private readonly StateMachine _stateMachine;
        private readonly Transform _target;
        private readonly Transform _selfTransform;
        private readonly PhysicsMovement _movement;
        private readonly CircleRotator _rotator;

        private readonly float _attackDistance;
        
        public ChaseTargetState(StateMachine stateMachine, Transform target, Transform selfTransform
            , PhysicsMovement movement, CircleRotator rotator, float attackDistance)
        {
            _stateMachine = stateMachine;
            _target = target;
            _selfTransform = selfTransform;
            _movement = movement;
            _rotator = rotator;
            _attackDistance = attackDistance;
        }
        
        public void Update()
        {
            if(_target == null)
                return;
            
            _movement.Move(-_target.position);        
            _rotator.Rotate(_target.position);
            
            if(Vector2.Distance(_target.position, _selfTransform.position) <= _attackDistance)
                _stateMachine.Enter<AttackPlayerState>();
        }
    }
}