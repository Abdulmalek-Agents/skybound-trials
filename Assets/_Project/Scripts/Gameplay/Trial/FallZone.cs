using UnityEngine;
using UnityEngine.Events;
using InventixGames.Core;
namespace Skybound.Trial
{
    [RequireComponent(typeof(Collider))]
    public class FallZone : MonoBehaviour
    {
        public UnityEvent OnPlayerFell;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (ServiceLocator.TryGet<ICheckpointService>(out var c) && c.TryGetLatest(out var pos, out _))
            {
                other.transform.position = pos + Vector3.up * 1f;
                if (other.TryGetComponent<Rigidbody>(out var rb)) rb.linearVelocity = Vector3.zero;
                if (other.TryGetComponent<CharacterController>(out var cc)) { cc.enabled = false; cc.enabled = true; }
            }
            OnPlayerFell?.Invoke();
        }
    }
}
