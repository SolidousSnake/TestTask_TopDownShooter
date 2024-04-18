using System;
using System.Threading;
using _Project.Scripts.Core.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Core.Spawner
{
    public sealed class EnemySpawner : IStartable, IDisposable
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly float _spawnDelay;

        private readonly CancellationTokenSource _cts;

        public EnemySpawner(IEnemyFactory enemyFactory, float spawnDelay)
        {
            _enemyFactory = enemyFactory;
            _spawnDelay = spawnDelay;

            _cts = new CancellationTokenSource();
        }

        public void Start()
        {
            Spawn().Forget();
        }

        private async UniTask Spawn()
        {
            while (!_cts.IsCancellationRequested)
            {
                _enemyFactory.Get(GetPosition());
                await UniTask.WaitForSeconds(_spawnDelay);
            }
        }

        private Vector2 GetPosition()
        { 
            var viewportSpawnPosition = Vector2.zero;
            int edge = Random.Range(0, 4);
            float offset = Random.value;

            switch (edge)
            {
                case 0:
                    viewportSpawnPosition = new Vector2(offset, 0f);
                    break;
                case 1:
                    viewportSpawnPosition = new Vector2(offset, 1f);
                    break;
                case 2:
                    viewportSpawnPosition = new Vector2(0f, offset);
                    break;
                case 3:
                    viewportSpawnPosition = new Vector2(1f, offset);
                    break;
            }

            return Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        }

        public void Dispose()
        {
            _cts.Cancel();
        }
    }
}