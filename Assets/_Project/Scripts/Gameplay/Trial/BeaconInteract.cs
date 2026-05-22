using UnityEngine;
using UnityEngine.Events;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace Skybound.Trial
{
    [RequireComponent(typeof(Collider))]
    public class BeaconInteract : MonoBehaviour
    {
        [SerializeField] private string objectiveOnLight = "m1_light_beacon";
        [SerializeField] private GameObject lightFx;
        public UnityEvent OnLit;
        private bool _lit;
        private void OnTriggerStay(Collider other)
        {
            if (_lit || !other.CompareTag("Player")) return;
            if (!Input.GetKeyDown(KeyCode.E)) return;
            _lit = true;
            if (lightFx) lightFx.SetActive(true);
            if (ServiceLocator.TryGet<IMissionService>(out var ms)) ms.ReportObjectiveProgress(objectiveOnLight);
            OnLit?.Invoke();
        }
    }
}
