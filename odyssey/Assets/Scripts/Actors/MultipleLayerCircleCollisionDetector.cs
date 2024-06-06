using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class MultipleLayerCircleCollisionDetector : MonoBehaviour
    {
        [SerializeField] private List<LayerMask> collisionMask;
        [SerializeField] private float collisionWidth;
        private Action<GameObject> onTargetHit;

        public void Initialize(Action<GameObject> onTargetHit) => 
            this.onTargetHit = onTargetHit;

        public void CheckForCollisions(Vector2 movementVector)
        {
            if (collisionMask.Count == 0)
            {
                Debug.Log("No collision mask defined for gameobject " + gameObject.name);
                return;
            };
            
            RaycastHit2D hit;
            
            HashSet<RaycastHit2D> hits = new HashSet<RaycastHit2D>();
            collisionMask.ForEach(mask =>
            {
                hits.Add(Physics2D.CircleCast(transform.position, collisionWidth, movementVector.normalized,movementVector.magnitude, mask));
            });
            
            hit = hits.FirstOrDefault(hit2D => hit2D.collider != null);

            if (hit.collider != null)
            {
                onTargetHit(hit.collider.transform.parent.gameObject);
            }
        }

        private void OnDrawGizmos() => 
            Gizmos.DrawWireSphere(transform.position, collisionWidth);
    }
}
