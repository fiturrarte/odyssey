using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] Movement movement;

        void FixedUpdate()
        {
            var movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movement.MoveBy(movementVector);

            if (Input.touchCount > 0)
            {
                touchInputs();
            }
        }

        void touchInputs()
        {
            Touch touch = Input.GetTouch(0);
            movement.MoveBy((touch.deltaPosition) * Time.fixedDeltaTime);
        }
    }
}