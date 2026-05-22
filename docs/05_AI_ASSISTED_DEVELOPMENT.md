# 🤖 AI-Assisted Development — Skybound Trials

> **Important:** AI is a **development tool**, not a runtime feature.
> No part of the shipping game calls an LLM at runtime. Every coach line
> (Motivator + Heckler) is hand-authored into `LineBankSO` pools.
> Claude (via Claude Code and Claude Agents) is used by the studio to speed up
> design, code, level layout, dialogue writing, and QA — never by the player.

## 1. What the studio uses Claude for

| Phase | What Claude does | What humans do |
|---|---|---|
| Concept & trend research | PEAK + Roblox obby signals; viral parkour mechanics | Final greenlight |
| GDD authoring | Drafts sky-isle layouts, obstacle progression, beacon placements | Pillar checks |
| Code generation | Produces ScriptableObjects, player parkour controller, trial timer, obstacle states | Senior dev review + Unity wiring |
| Coach-line writing | Drafts 50 Motivator lines + 50 Heckler lines per event-bank | Writers polish, VO direction |
| Level layout | Suggests platform spacing, wind gusts, mid-air pickups for each sky-isle | Designers verify in-engine |
| QA & playtesting | Authors speedrun benchmarks, fall-detection regression sheets | Manual play |

## 2. Why we removed runtime LLM features (v0.1 → v0.2)

| Concern | v0.1 (runtime Coach LLM) | v0.2 (hand-authored banks) |
|---|---|---|
| Tone consistency between Motivator & Heckler | LLM may slip between modes | 100% authored lines per mode |
| Internet dependency on a focus-heavy parkour game | Distracting | Fully offline |
| Per-DAU cost | ~$0.01 per player per day | $0 |
| Latency during a fall | 600–2,000 ms (player already respawned) | Instant |
| QA repro of comedic timing | Hard | Deterministic |
| Voice-over recording (later) | Impossible | Trivial — fixed line set |

## 3. How Claude shows up in the dev workflow

1. **Plan** — GDD drafts.
2. **Code** — Claude Code generates Unity C# into branch PRs.
3. **Review** — Critic & Review Board persona panel audits.
4. **Wire** — Click-by-click Unity Editor instructions for obby blocks.
5. **Author content** — Coach lines (Motivator + Heckler).
6. **Test** — Speedrun + fall-detection sheets.
7. **Ship** — Only the compiled game ships. No LLM at runtime.

## 4. The shipping game's dialogue stack

| Type | When | Author tool |
|---|---|---|
| `LineBankSO` | Coach fall / checkpoint / beacon lines (×2 modes) | Inspector edit + Claude drafts |
| `LineBankSO` | Sky-isle ambient barks (optional) | Same |

## 5. Example: authoring `LineBank_Coach_Motivator_Falls.asset`

1. Writer asks Claude: *"Draft 50 short coach lines for when the climber falls. Warm, supportive, never punishing. 1 short sentence each."*
2. Claude returns 50 lines as a YAML list.
3. Writer creates `LineBank_Coach_Motivator_Falls.asset`, pastes lines, drags into `Coach.motivatorFalls`.
4. Repeat 5× (Motivator: falls, checkpoints, beacon | Heckler: falls, checkpoints, beacon) — ~300 lines total. **No proxy, no API key.**

## 6. What replaced what

| v0.1 (deleted) | v0.2 (replacement) |
|---|---|
| `Persona_Motivator.asset` / `Persona_Heckler.asset` | 6× `LineBank_Coach_*.asset` |
| `CoachAI.cs` (LLM caller) | `Coach.cs` (LineBank consumer) |
| `AICopilotPersonaSO.cs` | (deleted) |
| `ClaudeCopilotService.cs` | `ScriptedDialogueService.cs` |
| `server/copilot-proxy/` | (deleted) |

## 7. What the user must do after cloning

1. Open Unity project per `docs/07`.
2. Buy & import asset packs per `docs/03`.
3. Drag prefabs / wire scenes per `docs/07`.
4. **No proxy server, no API key, no internet config required.**
