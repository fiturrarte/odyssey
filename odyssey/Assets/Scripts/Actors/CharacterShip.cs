using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class CharacterShip : MonoBehaviour
    {
        [SerializeField] private Vector3 bulletPositionOffset;
        [SerializeField] private float spawnBulletInterval;
        [SerializeField] BulletProvider bulletProvider;

        public void Initialize()
        {
            StartCoroutine(SpawnBullet());
        }

        private IEnumerator SpawnBullet()
        {
            yield return new WaitForSeconds(spawnBulletInterval);
            GameObject bullet = bulletProvider.GetBullet();
            bullet.transform.position = transform.position + bulletPositionOffset;
            bullet.transform.rotation = Quaternion.identity;

            StartCoroutine(SpawnBullet());
        }
        public void Shoot()
        {
            // Obtener una bala del proveedor
            GameObject bullet = bulletProvider.GetBullet();

        }
    }
    }

