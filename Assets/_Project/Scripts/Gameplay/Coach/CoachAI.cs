using UnityEngine;
using InventixGames.Core;
namespace Skybound.Coach
{
    public class CoachAI : MonoBehaviour
    {
        public enum Mode { Motivator, Heckler, Off }
        [SerializeField] private AICopilotPersonaSO motivatorPersona;
        [SerializeField] private AICopilotPersonaSO hecklerPersona;
        [SerializeField] private Mode mode = Mode.Motivator;
        [SerializeField] private float minFallCooldownSec = 8f;
        private float _nextFallTalk;
        private IAICopilotService _ai;

        private void Start() { _ai = ServiceLocator.Get<IAICopilotService>(); }
        public void OnPlayerFell()
        {
            if (mode == Mode.Off || Time.time < _nextFallTalk) return;
            _nextFallTalk = Time.time + minFallCooldownSec;
            var p = mode == Mode.Motivator ? motivatorPersona : hecklerPersona;
            _ai.Ask(p.systemPrompt, "Player just fell off a platform. React in one short line.", OnLine);
        }
        public void OnCheckpointHit()
        {
            if (mode == Mode.Off) return;
            var p = mode == Mode.Motivator ? motivatorPersona : hecklerPersona;
            _ai.Ask(p.systemPrompt, "Player just hit a checkpoint. React in one short line.", OnLine);
        }
        public void OnBeaconLit()
        {
            if (mode == Mode.Off) return;
            var p = mode == Mode.Motivator ? motivatorPersona : hecklerPersona;
            _ai.Ask(p.systemPrompt, "Player lit the trial's beacon. Brief reverent line.", OnLine);
        }
        public void SetMode(Mode m) => mode = m;
        protected virtual void OnLine(string line) { Debug.Log($"[Coach] {line}"); }
    }
}
