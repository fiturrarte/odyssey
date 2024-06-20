using Assets.Scripts.Actors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Director
{
    public class RandomEnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnInterval;
        [SerializeField] private EnemyProvider enemyProvider;
        [SerializeField] private BulletProvider enemyBulletProvider;
        [SerializeField] private float spawnAreaWidth;
        [SerializeField] private float spawnYPosition;

        public void Initialize()
        {
            enemyBulletProvider.GetBullet();
            enemyProvider.Initialize(enemyBulletProvider);
        }

        public void StartWave()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(spawnInterval);
            Enemy enemy = enemyProvider.GetEnemy();
            float xPos = UnityEngine.Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            enemy.SetPosition(new Vector3(xPos, spawnYPosition, 0));
            StartCoroutine(SpawnEnemy()); // Corregí "SpawnEneny" a "SpawnEnemy"
        }
    }
}
