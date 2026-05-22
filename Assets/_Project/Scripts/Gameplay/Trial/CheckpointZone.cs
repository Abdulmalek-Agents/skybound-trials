using UnityEngine;
using UnityEngine.Events;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace Skybound.Trial
{
    [RequireComponent(typeof(Collider))]
    public class CheckpointZone : MonoBehaviour
    {
        [SerializeField] private string checkpointId;
        [SerializeField] private string objectiveOnReach;
        [SerializeField] private GameObject onActivateVfx;
        public UnityEvent OnActivated;
        private bool _activated;

        private void OnTriggerEnter(Collider other)
        {
            if (_activated || !other.CompareTag("Player")) return;
            _activated = true;
            if (ServiceLocator.TryGet<ICheckpointService>(out var c)) c.Register(transform.position, checkpointId);
            if (!string.IsNullOrEmpty(objectiveOnReach) && ServiceLocator.TryGet<IMissionService>(out var ms)) ms.ReportObjectiveProgress(objectiveOnReach);
            if (onActivateVfx) onActivateVfx.SetActive(true);
            OnActivated?.Invoke();
        }
    }
}
