# 🛠️ Unity Setup Guide — Skybound Trials

> **v0.2.1: Unity 6 LTS (6000.4.4f1) target. No proxy server, no API key, no internet config required.**

## Prerequisites
- Unity Hub + Unity **6 LTS (6000.4.4f1)** with Windows IL2CPP module
- Assets per `03_ASSET_PLAN.md` in Inventix account

## Step 1 — New Unity project
Unity Hub → select Editor **6000.4.4f1** → template **Universal 3D** → `SkyboundTrials`.

## Step 2 — Drop repo
```bash
git clone https://github.com/Abdulmalek-Agents/skybound-trials.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Pipeline
URP 17.x. Linear colour. Quality preset High.

## Step 4 — Import order
1. Heat UI
2. Character Controller Pro
3. Traversal Pro
4. Obby Parkour Mega Pack
5. Toon Town
6. Stylized Weather System
7. Zephyr Dynamic Wind
8. BoZo Characters
9. Casual RPG VFX
10. Lumen FX 2
11. Game UI & Puzzle SFX Pack
12. Cutscene Engine

Move asset folders to `Assets/_Project/Art/`.

> **Unity 6 note:** if any package imports with pink materials, run **Edit → Rendering → Render Pipeline Converter → Built-in to URP**.

## Step 5 — Bootstrap scene
`Scenes/Bootstrap.unity` → `[Game]` with `GameBootstrap`. Build idx 0.

## Step 6 — MainMenu
Heat UI main menu. Build idx 1.

## Step 7 — Mission 1 — First Trial
1. New scene `Mission01_FirstTrial.unity`.
2. Drop a floating-platform layout from Obby Parkour Mega Pack — use 20 platforms in a winding line.
3. Place 3 CheckpointZone prefabs at thirds.
4. Place 2 SpinningBlade prefabs + 1 BouncyPad.
5. BeaconInteract prefab at end.
6. FallZone trigger covers area below all islands (large flat collider 1000m wide at y=-50).
7. Player_Wanderer.prefab + **Unity 6 camera**: `CinemachineCamera` with `CinemachineThirdPersonFollow` (replacement for the old free-look).
8. `[Mission01Director]` GameObject with Mission01Director.cs. Drag the `Coach` component (also on the player or a dedicated GameObject) and wire fall/checkpoint/beacon events to its public methods.
9. `MissionData_M01.asset` with 6 objectives (GDD §5).

Build idx 3.

## Step 8 — Author the Coach line banks

1. **Create → Inventix → Dialogue → Line Bank** six times:
   - `LineBank_Coach_Motivator_Falls.asset` (50 lines, warm + supportive)
   - `LineBank_Coach_Motivator_Checkpoints.asset` (50 lines)
   - `LineBank_Coach_Motivator_Beacon.asset` (15 reverent lines)
   - `LineBank_Coach_Heckler_Falls.asset` (50 dry/sardonic lines)
   - `LineBank_Coach_Heckler_Checkpoints.asset` (50 reluctant-praise lines)
   - `LineBank_Coach_Heckler_Beacon.asset` (15 understated lines)
2. Drag each into the corresponding field on the `Coach` component.
3. (Optional) drop wav clips into the `voiceOver` array.
4. Wire the pause-menu Motivator/Heckler/Off toggle to call `Coach.SetMode(...)`.

## Step 9 — Playtest
Bootstrap → New Game → M01 → climb islands → fall once (Coach barks) → hit 3 checkpoints (Coach barks) → light beacon (reverent line) → Mission Complete. Toggle Motivator ↔ Heckler in the pause menu and verify the bank set switches.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Player slides off platforms | Check Character Controller Pro slope settings |
| Falling forever | FallZone collider not set as trigger |
| Coach silent | LineBanks not assigned on `Coach`, or mode set to `Off` |
| `CinemachineFreeLook` missing | Use Unity 6's CinemachineCamera + CinemachineThirdPersonFollow |
| Spinning blade doesn't hurt | SpinningBlade.OnTriggerEnter must call CheckpointService reset |
| Pink materials | Render Pipeline Converter (Built-in → URP) |

## After M1
Tag `v0.2.1-mission1-playable`. M2: add Double-jump unlock to ParkourController, new scene, new MissionData.
