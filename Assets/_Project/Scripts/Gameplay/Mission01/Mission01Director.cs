using UnityEngine;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace Skybound.MissionOne
{
    public class Mission01Director : MonoBehaviour
    {
        [SerializeField] private string missionId = "M01";
        [SerializeField] private GameObject resultsPanel;
        private IMissionService _m;
        private void Start() { _m = ServiceLocator.Get<IMissionService>(); _m.OnMissionCompleted += C; }
        private void OnDestroy() { if (_m != null) _m.OnMissionCompleted -= C; }
        private void C(MissionDataSO m) { if (m.missionId == missionId && resultsPanel) resultsPanel.SetActive(true); }
    }
}
