using _Project.Scripts.Bonus.Kits;
using UnityEngine;

namespace _Project.Scripts.Unit.Death
{
    public sealed class EnemyDeath
    {
        private readonly Medkit _medkitPrefab;
        private readonly int _spawnChance;
        private readonly GameObject _enemyFacade;
        private readonly Score _score;
        
        public EnemyDeath(Medkit medkitPrefab, int spawnChance, EnemyFacade enemyFacade, Score score)
        {
            _medkitPrefab = medkitPrefab;
            _spawnChance = spawnChance;
            _enemyFacade = enemyFacade.gameObject;
            _score = score;
        }

        public void Die()
        {
            SpawnMedkit();
            _score.Increment();
            Object.Destroy(_enemyFacade);
        }

        private void SpawnMedkit()
        { 
            int randNumber = Random.Range(0, 101);

            if (randNumber <= _spawnChance * 100)
                Object.Instantiate(_medkitPrefab, _enemyFacade.transform.position, Quaternion.identity);
        }
    }
}