using _Project.Scripts.Weapon;
using UnityEngine;

namespace _Project.Scripts.Unit.States.Enemy
{
    public sealed class AttackPlayerState : IUpdateableState
    {
        private readonly StateMachine _stateMachine;
        private readonly Transform _target;
        private readonly Transform _selfTransform;
        private readonly IWeapon _weapon;
        
        private readonly float _attackDistance;
        
        public AttackPlayerState(StateMachine stateMachine, Transform target, Transform selfTransform
            , IWeapon weapon, float attackDistance)
        {
            _stateMachine = stateMachine;
            _target = target;
            _selfTransform = selfTransform;
            _weapon = weapon;
            _attackDistance = attackDistance;
        }
        
        public void Update()
        {
            if(_target == null)
                return;
            
            _weapon.Use();
            if(Vector2.Distance(_target.position, _selfTransform.position) > _attackDistance)
                _stateMachine.Enter<ChaseTargetState>();
        }
    }
}