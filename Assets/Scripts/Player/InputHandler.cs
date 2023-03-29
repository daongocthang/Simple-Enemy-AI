using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference movement, attack, pointer;

        public Vector2 GetMovementInput()
        {
            return movement.action.ReadValue<Vector2>().normalized;
        }

        public Vector2 GetPointerInput()
        {
            Vector3 mousePos = pointer.action.ReadValue<Vector2>();
            mousePos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}