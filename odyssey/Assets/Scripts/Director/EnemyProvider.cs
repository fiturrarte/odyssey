using Assets.Scripts.Actors;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Director
{
    public class EnemyProvider : MonoBehaviour
    {
        IList<Enemy> enemies = new List<Enemy>();
        [SerializeField] public Enemy enemyPrefab;
        private BulletProvider bulletProvider;

        internal void Initialize(BulletProvider bulletProvider)
        {
            this.bulletProvider = bulletProvider;
        }

        private Enemy InstantiateNewEnemy()
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            RegisterEnemy(newEnemy);
            return newEnemy;
        }

        private void RegisterEnemy(Enemy enemy) => enemies.Add(enemy);

        public Enemy GetEnemy()
        {
            var candidate = enemies.Any(e => e.Available) ? enemies.First(e => e.Available) : InstantiateNewEnemy();
            candidate.gameObject.SetActive(true);
            candidate.Initialize(bulletProvider, ReturnToPool);
            return candidate;
        }

        void ReturnToPool(Enemy enemy) => enemy.gameObject.SetActive(false);
    }
}
