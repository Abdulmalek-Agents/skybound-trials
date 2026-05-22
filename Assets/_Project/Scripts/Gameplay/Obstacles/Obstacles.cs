using UnityEngine;
namespace Skybound.Obstacles
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Vector3 toLocal = new Vector3(0, 0, 5);
        [SerializeField] private float speed = 1.5f;
        private Vector3 _from;
        private void Start() { _from = transform.position; }
        private void Update()
        {
            float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;
            transform.position = Vector3.Lerp(_from, _from + transform.TransformDirection(toLocal), t);
        }
    }

    public class SpinningBlade : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed = 180f;
        [SerializeField] private FallZoneTrigger triggerOnHit;
        private void Update() => transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    public class FallZoneTrigger : MonoBehaviour { /* placeholder for hit-triggers fallzone callback */ }

    public class BouncyPad : MonoBehaviour
    {
        [SerializeField] private float bounceForce = 10f;
        private void OnTriggerEnter(Collider o) { if (!o.CompareTag("Player")) return; if (o.TryGetComponent<Rigidbody>(out var rb)) rb.linearVelocity = new Vector3(rb.linearVelocity.x, bounceForce, rb.linearVelocity.z); }
    }
}
