using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Dummy : MonoBehaviour
    {
        [SerializeField] private CircleCollisionDetector solidFrame;

        void Start()
        {
            solidFrame.Initialize(OnCollision);
        }

        private void OnDeath() => 
            gameObject.SetActive(false);

        void FixedUpdate()
        {
            var speed = Vector2.down * Time.fixedDeltaTime;
            transform.Translate(speed);
            solidFrame.CheckForCollisions(speed);
        }

        void OnCollision(GameObject hitObject)
        {
          
        }
    }
}