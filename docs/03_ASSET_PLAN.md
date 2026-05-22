# 🎨 Asset Plan — Skybound Trials

## 1. Inventory

| Asset | Used for | Critical |
|---|---|---|
| **Obby Parkour Mega Pack** ($30) | All platforms, traps, bouncy pads, moving platforms | 🔴 Yes |
| **Character Controller Pro** ($28.99) | Player controller + jump variants | 🔴 Yes |
| **Traversal Pro** ($45) | Vault / climb / glide mechanics | 🔴 Yes |
| **Toon Town** | Floating stylised props on islands | 🟡 Helpful |
| **Stylized Weather System** ($20) | Misty mornings, sunset dramatic light | 🔴 Yes |
| **Zephyr Dynamic Wind** ($40) | Tree wind animation | 🟡 Helpful |
| **BoZo Characters** | Player + idle 'mountain elder' NPC at base camp | 🔴 Yes |
| **Casual RPG VFX** | Checkpoint sparkles, beacon light burst | 🔴 Yes |
| **Lumen FX 2** | Sunset light shafts, beacon glow | 🔴 Yes |
| **Heat UI** | Main menu, HUD, results | 🔴 Yes |
| **Game UI & Puzzle SFX Pack** | Jump, land, chime sounds | 🔴 Yes |
| **Cutscene Engine** | Intro narration, beacon-light camera pull | 🟡 Helpful |

**Inventory value applied: ~$320 across 12 assets.**

## 2. Must-buy

| Gap | Cost |
|---|---|
| Chill OST (4 tracks) | $200 |
| Glider wing prop + animation | $20 |
| Optional achievement icons | $0 (use Heat UI generic) |

## 3. Folder org — standard.

## 4. Performance

- Static obstacles batched.
- Moving platforms use cached transforms (no GetComponent in Update).
- Camera shake disabled at Low quality.

## 5. Licence ✅. No binaries.

## 6. Checklist

- [ ] Import all assets
- [ ] Build Player_Wanderer prefab from BoZo + Character Controller Pro
- [ ] Build 5 checkpoint prefabs
- [ ] Build moving platform prefab
- [ ] Author Trial 1 scene
