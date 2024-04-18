using _Project.Scripts.Unit.Health;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Weapon
{
    public sealed class Melee : MonoBehaviour, IWeapon
    {
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private float _damage;
        [SerializeField] private float _delay;
        [SerializeField] private float _range;

        public async UniTask Use()
        {
            Collider2D[] other = Physics2D.OverlapCircleAll(transform.position, _range, _targetLayer);
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i].TryGetComponent(out Health health))
                     health.ApplyDamage(_damage);
            }
            
            await UniTask.WaitForSeconds(_delay);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}