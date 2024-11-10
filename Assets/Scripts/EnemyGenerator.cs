using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _lowerbound;
        [SerializeField] private float _upperbound;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private ScoreModel _scoreModel;
        
        private ObjectPool<Enemy> _objectPool;

        private void Start()
        {
            _objectPool = new ObjectPool<Enemy>(_enemyPrefab);
            
            StartCoroutine(Generating());
        }

        private IEnumerator Generating()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                Spawn();
                yield return wait;
            }
        }

        private void Spawn()
        {
            float spawnPositionY = Random.Range(_lowerbound, _upperbound);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
            
            Enemy enemy = _objectPool.GetObject();

            enemy.gameObject.SetActive(true);
            enemy.SetDirection(Vector3.left);
            enemy.transform.position = spawnPoint;
            enemy.Init(_scoreModel);

            enemy.Faced += ReturnToPool;
        }

        private void ReturnToPool(Enemy enemy)
        {
                enemy.Faced -= ReturnToPool;
                _objectPool.PutObject(enemy);
        }
    }
}