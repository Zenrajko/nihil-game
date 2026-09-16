# AGENTS.md

Instructions for AI agents working in this repository (e.g. opencode).

## Project summary

**Nihil** — a Doom-like FPS prototype built in the **Unity Editor** (Unity 6.6, URP), using **free assets only** and **minimal hand-written code**. All content is original / free-licensed — "Doom-like" is a genre homage only, no id/Bethesda IP. The human drives all building; agents are **advisors only**.

## Role rules (most important)

- **Advisor-only.** Advise, explain, review, research. Do NOT write or edit Unity project files (`.cs`, scenes, assets, prefabs) or create game code on the human's behalf.
- Coach with the human's own goals: learn Unity by doing, Editor-first workflow, reuse free assets over writing code.
- If asked to produce game code, ask/clarify and prefer explaining the approach instead.

## Repository rules

- Repo layout: Unity project lives in `Nihil/` (Assets, Packages, ProjectSettings). Docs at repo root: `README.md` (public portfolio pitch), `CHANGELOG.md` (session log), `AGENTS.md` (this file), `CREDITS.md` (asset attributions). `.gitignore`/`.gitattributes` at root; ignore patterns are deliberately NOT root-anchored (project is in a subfolder).
- Never init git, commit, or push unless explicitly asked.
- Asset policy: **free/CC0 assets only**. Every imported asset records license + redistribution terms in `CREDITS.md`. **Never commit any asset whose license restricts redistribution** — exclude via `.gitignore` and note the exclusion. `CREDITS.md` doesn't exist yet; create it when the first such asset is imported.

## Tech stack (pinned — don't suggest alternatives)

| Layer | Choice | Notes |
|---|---|---|
| Engine | Unity 6.6 | `6000.6.0f1`, Supported release (per `Nihil/ProjectSettings/ProjectVersion.txt`). Verify exact version before version-gated advice. |
| Render pipeline | URP | `Universal 3D` template. Never suggest Built-in Render Pipeline. |
| Input | Unity Input System (1.20, Editor-configured) | via Input Actions assets |
| Player controller | Starter Assets – First Person Controller | zero movement code to write |
| Camera / VFX | Cinemachine · Particle System · Shader Graph | editor tools, no hand-written shaders |
| Navigation | com.unity.ai.navigation (2.0.14) | for enemy movement (M4) |
| Scripting | Minimal C# | only what no free asset provides |

## Development philosophy

**"Do it in the Editor; only code what no asset does."** For every feature, in order:
1. Does Unity do it already? (Character Controller, Rigidbody/Raycast, Particle System, Timeline, Animator, NavMesh)
2. Does a free asset do it? (Starter Assets controller, asset-store AI packs)
3. Only then: smallest C# script filling the gap (e.g. a ~15-line HP handler).

Recommended build order per feature:

| Feature | Editor route first | Script only if needed |
|---|---|---|
| Player movement | Starter Assets FPS Controller + Character Controller | — |
| Input | Input Actions asset (Editor) | — |
| Weapon (hitscan) | Starter Assets gun config, Particle System muzzle flash | small fire/hitscan script |
| Plasma / effects | weapon prefabs, TrailRenderer | small script |
| Enemy damage | NavMesh Agent + Animator states (walk/dead) | small HP + death script |
| Health/pickups | ScriptableObjects for item data | small pickup script |
| Arena flow | Timeline, trigger colliders, spawn points | level-bootstrap script |

## Asset sources

| Source | Offerings | License | Typical use |
|---|---|---|---|
| Unity Asset Store (free) | Starter Assets – First Person Controller | Unity free | controller, weapon rig |
| [Kenney.nl](https://kenney.nl/) | weapons, dungeon tiles, enemies, audio | CC0 | level geometry, enemies, SFX |
| [Quaternius](https://quaternius.com/) | character/weapon packs | CC0 | enemies, weapons, props |
| [Poly Pizza](https://poly.pizza/) | 3D models | varies, mostly CC0 | stand-ins |
| [Poly Haven](https://polyhaven.com/) | textures, HDRIs | CC0 | textures, sky lighting |
| [ambientCG](https://ambientcg.com/) | PBR textures | CC0 | surface textures |
| [Freesound](https://freesound.org/) | SFX | varies; filter CC0 | gun/monster sounds |

## Milestones

| # | Milestone | Done when |
|---|---|---|
| M0 | Project scaffolding | project created, `.gitignore`, first commit, editor runs — **done** |
| M1 | Whitebox arena | grey-box level, player spawns, collision works |
| M2 | Movement + look | walk, sprint, crouch, jump, mouse look |
| M3 | Weapon firing | hitscan fires, muzzle flash, sound, damages target |
| M4 | Enemies | one enemy type: moves to player, takes damage, dies |
| M5 | Health + game state | player HP, damage feedback, death/restart |
| M6 | Juice + combat loop | screenshake, particles, pickups, HUD, spawn loop |

Each milestone ends with a **playtest** and a `CHANGELOG.md` entry.

## Conventions

- Session logs at the top of `CHANGELOG.md`: `## YYYY-MM-DD — title`, entries tagged `[Decision]` / `[Milestone]` / `[Changed]` / `[Added]` / `[Fixed]` / `[Lesson]` / `[Attribution]`.
- Session loop: `plan → do → playtest → log`. Small commits per working step.
- README is public-facing and kept lean; operational detail lives here and in `CHANGELOG.md`.

## Commands

- No build/test commands exist (Unity is editor-driven). No npm/cargo/etc.
- Verify actual Unity version from `Nihil/ProjectSettings/ProjectVersion.txt` or `CHANGELOG.md` before version-gated advice.

## When in doubt

- Prefer teaching over doing.
- Answer questions about this repo by reading `README.md` and `CHANGELOG.md` first.