# 🛠️ Unity Setup Guide — Skybound Trials

## Prerequisites
- Unity 2022.3.30f1 LTS
- Assets per `03_ASSET_PLAN.md` in Inventix account
- Node.js 18+
- Anthropic API key

## Step 1 — New Unity project
3D (URP) Core → `SkyboundTrials`.

## Step 2 — Drop repo
```bash
git clone https://github.com/Abdulmalek-Agents/skybound-trials.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Pipeline
URP. Linear colour. Quality preset High.

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
7. Player_Wanderer.prefab + Cinemachine 3rd-person camera.
8. `[Mission01Director]` GameObject with Mission01Director.cs.
9. `MissionData_M01.asset` with 6 objectives (GDD §5).

Build idx 3.

## Step 8 — AI proxy
```bash
cd server/copilot-proxy && cp .env.example .env
npm install && npm run dev
```

## Step 9 — Coach personas
Create `Persona_Coach_Motivator.asset` + `Persona_Coach_Heckler.asset`. Paste from `05_AI_COPILOT_INTEGRATION.md`.

## Step 10 — Playtest
Bootstrap → New Game → M01 → climb islands → hit 3 checkpoints → light beacon → Mission Complete.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Player slides off platforms | Check Character Controller Pro slope settings |
| Falling forever | FallZone collider not set as trigger |
| Coach silent | Proxy not running or persona not assigned |
| Spinning blade doesn't hurt | SpinningBlade.OnTriggerEnter must call CheckpointService reset |

## After M1
Tag `v0.1-mission1-playable`. M2: add Double-jump unlock to ParkourController, new scene, new MissionData.
