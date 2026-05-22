using UnityEngine;
using TMPro;
namespace InventixGames.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText, fallsText, coachText;
        private float _startTime;
        private int _falls;
        private void Start() => _startTime = Time.time;
        private void Update() { var t = Time.time - _startTime; if (timerText) timerText.text = $"{Mathf.FloorToInt(t / 60f):00}:{Mathf.FloorToInt(t % 60f):00}"; }
        public void RegisterFall() { _falls++; if (fallsText) fallsText.text = $"Falls: {_falls}"; }
        public void SetCoachLine(string s) { if (coachText) coachText.text = s; }
    }
}
