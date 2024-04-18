using _Project.Scripts.Bonus.Kits;
using _Project.Scripts.Core.Factory;
using _Project.Scripts.Core.Spawner;
using _Project.Scripts.Services;
using _Project.Scripts.UI;
using _Project.Scripts.Unit;
using _Project.Scripts.Unit.Death;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Core.Bootstrapper
{
    public sealed class LevelBootstrapper : LifetimeScope
    {
        [Header("UI")] 
        [SerializeField] private HealthView _healthView;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private FailureWindow _failureWindow;
        
        [Header("Camera")] 
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector3 _offset;

        [Header("Enemy")] 
        [SerializeField] private EnemyFacade _enemyPrefab;
        [SerializeField] private float _spawnDelay;
        
        [Header("Player")]
        [SerializeField] private InputService _inputService;
        [SerializeField] private PlayerFacade _playerPrefab;
        [SerializeField] private Vector2 _spawnPoint;
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindPlayer(builder);
            BindServices(builder);
            BindUI(builder);
            BindFactory(builder);

            builder.Register<Score>(Lifetime.Singleton).WithParameter(_scoreView);
            builder.RegisterEntryPoint<EnemySpawner>().WithParameter(_spawnDelay);
        }

        private void BindFactory(IContainerBuilder builder)
        {
            builder.Register<IEnemyFactory, EnemyFactory>(Lifetime.Singleton).WithParameter(_enemyPrefab);
        }

        private void BindUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_healthView);
            builder.RegisterInstance(_failureWindow);
        }

        private void BindServices(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_inputService, Lifetime.Singleton);
            
            builder.RegisterEntryPoint<CameraService>().WithParameter(_offset).WithParameter(_camera).AsSelf();
        }

        private void BindPlayer(IContainerBuilder builder)
        {
            builder.Register(container => 
                container.Instantiate(_playerPrefab, _spawnPoint, Quaternion.identity), Lifetime.Singleton);
        }
    }
}