using _Project.Scripts.Unit.Health;
using UnityEngine;

namespace _Project.Scripts.Bonus.Kits
{
    public sealed class Medkit : MonoBehaviour
    {
        [SerializeField] private float _healingValue;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.ApplyHeal(_healingValue);
            }
            Destroy(gameObject);
        }
    }
}