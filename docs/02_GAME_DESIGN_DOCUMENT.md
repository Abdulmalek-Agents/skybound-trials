# 📜 Game Design Document — Skybound Trials

## 1. High-concept

The Sky-Isles drift above the clouds. Climb 6 ancient trials before sunset. Each trial is a different floating island with platforms, hazards, and a final beacon to light. The Coach (AI) speaks to you over an old radio strapped to your wrist.

**Fantasy:** 'I am the brave wanderer of the sky.'

**Emotional journey:** Trepidation → thrill → frustration → mastery → quiet awe at the view.

**Pillars:**
1. **Tight controls.** 1-frame jumps must work.
2. **Generous checkpoints.** Falling is funny, not punishing.
3. **Coach personality.** AI banter is the soul.

## 2. Core game loop

`Enter trial → Climb platforms → Hit checkpoint → Repeat → Light beacon → Next trial`

## 3. Player verbs

| Verb | Input | Notes |
|---|---|---|
| Move / sprint | WASD / Shift | |
| Jump | Space | Variable height |
| Double-jump | Space mid-air (unlocked M2) | |
| Vault | Auto on collision | Traversal Pro |
| Climb | E hold | Stamina-bound |
| Glide | Hold Space falling (M3+) | Slows descent |
| Reset to last checkpoint | R | Always available, no penalty |
| Coach toggle | T | Motivator / Heckler / Off |

## 4. Mission structure (6 sky-isles)

| # | Trial | Distinct mechanic |
|---|---|---|
| **1** | *The First Trial* | Basics: jump, sprint, checkpoint reset |
| 2 | *Whispering Heights* | Double-jump unlocked |
| 3 | *Galeward Pass* | Glide unlocked + wind gusts |
| 4 | *Stone Choir* | Moving platforms + spinning blades |
| 5 | *Lantern Climb* | Night trial; lanterns light path |
| 6 | *The Beacon Spire* | Final long climb, all mechanics, vista at top |

## 5. Mission 1 — *The First Trial*

**Duration:** 4–8 min.

**Flow:**
1. Spawn on small sky-isle. Coach (Claude) greets player.
2. 3 checkpoint zones connected by ~20 platforms.
3. Hazards: 2 spinning blades, 1 bouncy pad.
4. Final beacon: interact to light.
5. Stats screen: time + fall count + Coach commentary.

**Objectives:**
- `m1_first_jump` (Custom, 1)
- `m1_reach_checkpoint_1` (ReachLocation, 1)
- `m1_reach_checkpoint_2` (ReachLocation, 1)
- `m1_reach_checkpoint_3` (ReachLocation, 1)
- `m1_light_beacon` (InteractWith, 1)
- `m1_optional_no_falls` (Custom, 1, optional, awards medal)

## 6. AI Coach (Claude) — Motivator vs. Heckler

Two personas, player toggles in pause menu:
- **Motivator:** 'You're so close! Don't give up!'
- **Heckler:** 'Was that a jump, or did you trip?'

Full spec in `docs/05_AI_COPILOT_INTEGRATION.md`.

## 7. UI

- Heat UI base.
- HUD: timer, fall counter, current trial, Coach subtitle.
- Pause menu: Coach persona toggle, accessibility, restart trial.

## 8. Audio

- Music: chill ambient + light percussion.
- Game UI & Puzzle SFX Pack for jumps, lands, checkpoint chimes, beacon light.

## 9. Accessibility

- Auto-checkpoint after 3 falls in same spot.
- One-button glide.
- Subtitle Coach.
- Colourblind beacon palette.
- Reduced-motion option (less camera shake on falls).

## 10. Cut-list

1. Glide trail VFX (gameplay still works without).
2. M4 spinning blades replaced with stationary spikes.
3. M5 night trial collapsed into M6.

**Never cut:** First Trial, Coach personas, Beacon Spire vista.

✅ **Approved.**
