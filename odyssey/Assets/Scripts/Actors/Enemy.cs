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
        //[SerializeField] private ActorView view;
        //[SerializeField] CircleCollision Detector solidFrame;
        //[SerializeField] private Collider2D collider;
        //[SerializeField] private Weapon weapon;
        [SerializeField] private int scoreValue = 10;
        [SerializeField] public float speed = 10f;

        public bool Available => !gameObject.activeInHierarchy;

        public void Initialize(BulletProvider bulletProvider, Action<Enemy> onDestroyed)
        {
            this.onDestroyed = onDestroyed;
            //solidFrame.Initialize(OnCollision);
            //view.Initialize(OnRelease);
            //weapon.Initialize(bulletProvider);
            //collider.enabled = true;
            //movementCommand = GetComponent<IMovementStrategy>();
            //movementCommand.Initialize();
        }

        private void FixedUpdate()
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            if (IsOutOfScene())
                onDestroyed(this);
        }
           

        private void OnCollision(GameObject hitObject)
        {
            Debug.Log("Handle Collision here");
        }
           
        private void StartDestroy()
        {
            //weapon.StopFiring();
            //scoreUpdate(this.scoreValue);
            //collider.enabled = false;
           // view.ShowDeath();
        }

        void onRelease()
        {
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

