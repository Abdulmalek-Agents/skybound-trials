# 🧱 Technical Architecture — Skybound Trials

## 1. Stack

Unity 2022.3 LTS + URP. New Input System. Addressables. Claude proxy.

## 2. Scripts

```
Core/         (shared)
AI/           ClaudeCopilotService, AICopilotPersonaSO
UI/           MainMenuController, HUDController
Gameplay/
  Player/     ParkourController, PlayerStamina, GliderController
  Trial/      CheckpointZone, FallZone, BeaconInteract, TimerSystem
  Obstacles/  MovingPlatform, SpinningBlade, BouncyPad
  Coach/      CoachAI  (Claude integration)
  Mission01/  Mission01Director
```

## 3. Scenes

| Scene | Idx |
|---|---|
| Bootstrap | 0 |
| MainMenu | 1 |
| BaseCamp (hub) | 2 |
| Mission01_FirstTrial | 3 |
| ... M02-M06 | 4-8 |

## 4. Player controller pattern

ParkourController wraps Character Controller Pro. Reads input, applies stat overrides. State machine: `Grounded → Jumping → Falling → Gliding → Climbing → Vaulting`.

## 5. Checkpoint system

CheckpointZone registers via ICheckpointService. FallZone resets to latest. R-key shortcut also resets.

## 6. Coach AI

CoachAI MonoBehaviour subscribes to:
- Player fall events (FallZone)
- Checkpoint events
- Long-stuck events (no checkpoint progress in 60s)
- Beacon lit event

Builds context strings, calls Claude proxy, displays in HUD.

## 7. Scalability

- New trial = new scene + MissionData asset.
- New obstacle = new prefab + MonoBehaviour script.

## 8. Performance budget

- < 800 draw calls per island.
- Particles capped at 2000.
- Memory < 1 GB.

## 9. CI later.
