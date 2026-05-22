using UnityEngine;
using InventixGames.Core.Dialogue;

namespace Skybound.Coach
{
    /// <summary>
    /// Coach Sky speaks to the climber via the wrist-radio.
    /// Two parallel sets of LineBankSO assets — Motivator + Heckler — cover
    /// fall / checkpoint / beacon events. Mode is chosen in the pause menu.
    /// v0.2: 100% hand-authored — see /Assets/_Project/Data/LineBanks/.
    /// </summary>
    public class Coach : MonoBehaviour
    {
        public enum Mode { Motivator, Heckler, Off }

        [Header("Motivator banks (warm, encouraging)")]
        [SerializeField] private LineBankSO motivatorFalls;
        [SerializeField] private LineBankSO motivatorCheckpoints;
        [SerializeField] private LineBankSO motivatorBeacon;

        [Header("Heckler banks (dry, sardonic)")]
        [SerializeField] private LineBankSO hecklerFalls;
        [SerializeField] private LineBankSO hecklerCheckpoints;
        [SerializeField] private LineBankSO hecklerBeacon;

        [Header("Mode + cooldowns")]
        [SerializeField] private Mode mode = Mode.Motivator;
        [SerializeField] private float fallCooldownSec = 8f;
        [SerializeField] private float checkpointCooldownSec = 5f;

        [Header("Audio")]
        [SerializeField] private AudioSource radioSource;

        private float _nextFallTalk, _nextCheckpointTalk;
        public void SetMode(Mode m) => mode = m;

        public void OnPlayerFell()
        {
            if (mode == Mode.Off || Time.time < _nextFallTalk) return;
            _nextFallTalk = Time.time + fallCooldownSec;
            Say(mode == Mode.Motivator ? motivatorFalls : hecklerFalls);
        }
        public void OnCheckpointHit()
        {
            if (mode == Mode.Off || Time.time < _nextCheckpointTalk) return;
            _nextCheckpointTalk = Time.time + checkpointCooldownSec;
            Say(mode == Mode.Motivator ? motivatorCheckpoints : hecklerCheckpoints);
        }
        public void OnBeaconLit()
        {
            if (mode == Mode.Off) return;
            Say(mode == Mode.Motivator ? motivatorBeacon : hecklerBeacon);
        }

        protected virtual void Say(LineBankSO bank)
        {
            if (bank == null) return;
            string line = bank.PickRandom(out var clip);
            if (radioSource && clip) { radioSource.clip = clip; radioSource.Play(); }
            Debug.Log($"[Coach] {line}");
        }
    }
}
