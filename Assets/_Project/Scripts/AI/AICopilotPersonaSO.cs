using UnityEngine;
namespace InventixGames.Core { [CreateAssetMenu(menuName = "Inventix/AI Copilot/Persona", fileName = "Persona_")] public class AICopilotPersonaSO : ScriptableObject { public string npcId; public string displayName; [TextArea(6, 20)] public string systemPrompt; [Range(0f, 1f)] public float temperature = 0.7f; public bool useShortTermMemory = true; } }
