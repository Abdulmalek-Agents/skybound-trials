# 🧱 Technical Architecture — Skybound Trials

> v0.2: runtime LLM removed. Coach reads from 6 `LineBankSO` pools (Motivator + Heckler × fall/checkpoint/beacon).
> v0.2.1: Unity 6 LTS (6000.4.4f1) target.

## 1. Stack

| Layer | Choice |
|---|---|
| Engine | Unity **6 LTS (6000.4.4f1)** |
| Render | **URP 17.x** |
| Player controller | Character Controller Pro (Unity 6 compatible) |
| Input | New Input System |
| Async loading | Addressables |
| Save | JsonUtility → persistentDataPath |
| Dialogue | Hand-authored `LineBankSO` pools |
| Camera | Cinemachine 3.x |
| Source control | Git + LFS |

## 2. Scripts

```
Core/         (shared)
Dialogue/     DialogueNodeSO, LineBankSO, ScriptedDialogueService
UI/           MainMenuController, HUDController
Gameplay/
  Player/     ParkourController, PlayerStamina, GliderController
  Trial/      CheckpointZone, FallZone, BeaconInteract, TimerSystem
  Obstacles/  MovingPlatform, SpinningBlade, BouncyPad
  Coach/      Coach  (6 LineBanks: Motivator + Heckler × fall/checkpoint/beacon)
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

CheckpointZone registers via ICheckpointService. FallZone resets to latest. R-key shortcut also resets. Each Checkpoint also fires `Coach.OnCheckpointHit()` (cooldown-protected).

## 6. Coach (scripted)

`Coach` MonoBehaviour subscribes to:
- Player fall events (FallZone) → picks from Motivator-or-Heckler falls bank
- Checkpoint events → picks from checkpoints bank
- Beacon lit event → picks from beacon bank

Mode (Motivator / Heckler / Off) is set via pause-menu toggle calling `Coach.SetMode(...)`.

Lines are hand-authored ScriptableObjects — see `docs/05_AI_ASSISTED_DEVELOPMENT.md`.

## 7. Unity 6 (6000.4.4f1) compatibility notes

- **URP** upgraded from 14.x → 17.x — Render Pipeline Converter handles Unity 2022–era assets.
- **Cinemachine 3.x** — 3rd-person follow camera uses `CinemachineCamera` + `CinemachineThirdPersonFollow`.
- **Character Controller Pro** — Unity-6-compatible; take any vendor update.
- **Splines**, **Addressables**, **NavMesh**, **TextMeshPro**, **New Input System** unchanged.

## 8. Scalability

- New trial = new scene + MissionData asset.
- New obstacle = new prefab + MonoBehaviour script.
- New Coach event = add `LineBankSO` field to `Coach` + author the bank.
- Internet outage breaks game? ❌ No — fully offline.

## 9. Performance budget

- < 800 draw calls per island.
- Particles capped at 2000.
- Memory < 1 GB.

## 10. CI later.
