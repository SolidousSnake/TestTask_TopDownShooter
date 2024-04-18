using System;
using _Project.Scripts.Unit.Health;
using UnityEngine;

namespace _Project.Scripts.Weapon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _lifeTime;

        private float _damage;

        private void OnValidate()
        {
            _rigidBody ??= GetComponent<Rigidbody2D>();
        }

        public void Initialize(float damage, float speed, Vector2 direction)
        {
            if (damage < 0)
                throw new ArgumentException($"Projectile must have positive damage. Damage equals: {damage}");

            _damage = damage;

            _rigidBody.velocity = speed * direction;
            Destroy(gameObject, _lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
                health.ApplyDamage(_damage);

            Destroy(gameObject);
        }
    }
}