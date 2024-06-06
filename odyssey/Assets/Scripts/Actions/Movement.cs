using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] private bool clampToScreen;
        
        public void MoveBy(Vector2 movementVector)
        {
            movementVector *= speed * Time.fixedDeltaTime;
            transform.Translate(new Vector3(movementVector.x, movementVector.y, 0f));
            
            if (clampToScreen)
            {
                clampMovement();    
            }
        }

        private void clampMovement()
        {
            Vector3 position = transform.position;
            Vector3 camStart = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
            Vector3 camEnd = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));

            position.x = Mathf.Clamp(position.x, camStart.x, camEnd.x);
            position.y = Mathf.Clamp(position.y, camStart.y, camEnd.y);

            transform.position = position;
        }
    }
}
