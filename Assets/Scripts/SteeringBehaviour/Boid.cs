using UnityEngine;

namespace SteeringBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Boid : MonoBehaviour
    {
        [SerializeField]
        private Transform spriteTransform;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponentInParent<Rigidbody2D>();
        }

        public void SetVelocity(Vector2 velocity)
        {
            rb.position += velocity;
        }

        public float DistanceTo(Vector2 target)
        {
            var self = rb.position;
            var a = new Vector3(self.x, self.y);
            var b = new Vector3(target.x, target.y);

            return Vector3.Distance(a, b);
        }

        public void LookAt(Vector2 target)
        {
            var scale = spriteTransform.localScale;
            var dir = target - (Vector2) spriteTransform.position;
            if (dir.x > 0)
            {
                scale.x = 1;
            }
            else if (dir.x < 0)
            {
                scale.x = -1;
            }

            spriteTransform.localScale = scale;
        }
    }
}