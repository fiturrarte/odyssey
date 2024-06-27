using Assets.Scripts.Player;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class Enemy : MonoBehaviour
    {
        Action<Enemy> onDestroyed;
        Action<int> scoreUpdate;
        [SerializeField] Movement movement;
        [SerializeField] public float speed = 10f;

        public bool Available => !gameObject.activeInHierarchy;

        public void Initialize(BulletProvider bulletProvider, Action<Enemy> onDestroyed)
        {
            this.onDestroyed = onDestroyed;
        }

        private void FixedUpdate()
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            if (IsOutOfScene())
                onDestroyed(this);
        }
           

        private bool IsOutOfScene()
        {
            Vector3 canEnd = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));
            Vector3 position = transform.position;
            return (position.y - 1) > canEnd.y;
        }

        public void SetPosition(Vector3 position) => 
            transform.position = position;

    }
}

