using System;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class CircleCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask collisionMask;
        [SerializeField] private float collisionWidth;
        private Action<GameObject> onTargetHit;

        public void Initialize(Action<GameObject> onTargetHit) => 
            this.onTargetHit = onTargetHit;

        public void CheckForCollisions(Vector2 movementVector)
        {
            RaycastHit2D hit;

            hit = Physics2D.CircleCast(transform.position, collisionWidth, movementVector.normalized, movementVector.magnitude, collisionMask);

            if (hit) 
                onTargetHit(hit.collider.transform.parent.gameObject);
        }

        private void OnDrawGizmos() => 
            Gizmos.DrawWireSphere(transform.position, collisionWidth);
    }
}