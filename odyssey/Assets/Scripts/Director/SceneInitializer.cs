using UnityEngine;

namespace Assets.Scripts.Director
{
    public class SceneInitializer : MonoBehaviour
    {

        [SerializeField] private RandomEnemySpawner enemySpawner;
        void Start()
        {
            //

            var characterShip = FindObjectOfType<Actors.CharacterShip>();
            characterShip.Initialize();

            enemySpawner.Initialize();
            enemySpawner.StartWave();
        }

    }
}
