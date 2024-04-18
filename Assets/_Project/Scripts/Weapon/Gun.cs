using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Weapon
{
    public sealed class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private Projectile _bulletPrefab;
        [SerializeField] private Transform _muzzle;
        [SerializeField] private AudioSource _source;
        
        [SerializeField] private float _fireRate;

        [SerializeField] private float _damage;
        [SerializeField] private float _projectileSpeed;

        private bool _canShoot = true;

        public async UniTask Use()
        {
            if (!_canShoot)
                return;

            _canShoot = false;

            Projectile projectile = Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
            projectile.Initialize(_damage, _projectileSpeed, _muzzle.up);
            _source.Play();
            await UniTask.WaitForSeconds(_fireRate);

            _canShoot = true;
        }
    }
}