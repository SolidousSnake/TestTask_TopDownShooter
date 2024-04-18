using _Project.Scripts.Core.Spawner;
using _Project.Scripts.UI;

namespace _Project.Scripts.Unit.Death
{
    public sealed class PlayerDeath
    {
        private readonly FailureWindow _failureWindow;
        private readonly EnemySpawner _enemySpawner;
        
        public PlayerDeath(FailureWindow failureWindow, EnemySpawner enemySpawner)
        {
            _failureWindow = failureWindow;
            _enemySpawner = enemySpawner;
        }

        public void Die()
        {
            _failureWindow.gameObject.SetActive(true);
            _enemySpawner.Dispose();
        }
    }
}