using _Project.Scripts.Unit;
using Unity.Mathematics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Core.Factory
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyFacade _prefab;
        private readonly IObjectResolver _resolver;

        public EnemyFactory(EnemyFacade prefab, IObjectResolver resolver)
        {
            _prefab = prefab;
            _resolver = resolver;
        }

        public void Get(Vector2 position)
        {
            _resolver.Instantiate(_prefab, position, quaternion.identity);
        }
    }
}