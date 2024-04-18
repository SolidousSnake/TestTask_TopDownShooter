using UnityEngine;

namespace _Project.Scripts.Core.Factory
{
    public interface IEnemyFactory
    {
        public void Get(Vector2 position);
    }
}