using UnityEngine;

namespace Assets.Scripts.Director
{
    public class SceneInitializer : MonoBehaviour
    { 


        void Start()
        {            
            var characterShip = FindObjectOfType<Actors.CharacterShip>();
            characterShip.Initialize();
        }

    }
}
