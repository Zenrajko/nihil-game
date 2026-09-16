# Nihil

A **Doom-style first-person shooter prototype** built in the Unity Editor. Nihil is a learning-first project: build a "boomer shooter" playable slice using exclusively **free assets**, **minimal hand-written code**, and an **Editor-driven workflow** (gameplay assembled in the Unity editor rather than programmed from scratch).

- **Genre**: FPS / boomer shooter (Doom, Quake-style movement & combat)
- **Platform target**: Windows (desktop)
- **Engine**: Unity 6.6 (6000.6.0f1, Supported release)
- **Render pipeline**: Universal Render Pipeline (URP), 2D-era `Universal 3D` template

---

## Table of Contents

1. [Project Goals](#project-goals)
2. [Tech Stack](#tech-stack)
3. [Non-Goals](#non-goals)
4. [Getting Started](#getting-started)
5. [Development Philosophy](#development-philosophy)
6. [Asset Policy](#asset-policy)
7. [Milestones](#milestones)
8. [Working Practices](#working-practices)
9. [Project Log](#project-log)

---

## Project Goals

The project is driven by six explicit, in-order goals:

1. **Prototype a Doom-like FPS** — movement, shooting, enemies, health, arenas. Enough to feel "vaguely Doom", not a full game.
2. **Learn Unity by doing** — every session should teach at least one new Unity concept.
3. **Use only free assets** — CC0 / public-domain / free-license assets only, with attribution recorded.
4. **Build in the Unity Editor** — prefer Editor work (prefabs, components, Timeline, particles, Shader Graph) over writing code.
5. **Reuse assets over coding** — where a free package or built-in component already does the job, use it instead of writing a script.
6. **Do-it-myself project** — I drive the work; the advisor suggests, reviews, explains, and unblocks — never does the building for me.

---

## Tech Stack

| Layer | Choice | Notes |
|---|---|---|
| Engine | Unity 6.6 (Supported) | `6000.6.0f1` — same support/stability as LTS until 6.7 ships. New projects should not use Built-in Render Pipeline. |
| Render pipeline | URP (`Universal 3D` template) | Free, performant, good for stylized/retro visuals. |
| Input | Unity Input System package | Configured in the Editor via Input Actions. |
| Player controller | **Starter Assets – First Person Controller** (free) | Prebuilt `PlayerController` + `CameraController` scripts from Unity — zero movement code needed. |
| Physics | Character Controller component | Bundled with the Starter Assets setup. |
| Camera | Cinemachine (optional) | Free camera toolkit; good for hitshake/death cam. |
| VFX | Shader Graph, VFX Graph, Particle System | All editor tools; no hand-written shaders. |
| Scripting | Minimal C# | Only where no free asset exists (see [Code Budget](#code-budget)). Compose in Editor whenever possible. |
| Version control | Git + (optionally GitHub) | `.gitignore` generated after Unity project creation. |

> **Version pin**: Update this table's engine version after installing (record exact version in `CHANGELOG.md`, e.g. `6000.6.0f1`).

---

## Non-Goals

- No custom render pipeline / custom shader coding
- No multiplayer / networking
- No mobile or console targets
- No level builder tooling — levels are hand-placed in the editor
- No paid assets (even "cheap")
- No writing code that a free asset already provides

---

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity **6.6** (`6000.6.0f1`, Supported) installed via Unity Hub
- Git (`git --version`)

### Create the Unity project

> Repo root is `D:\repos\nihil-game`; the Unity project lives one level down.

1. Open Unity Hub → **New project** → tab **All templates**.
2. Select **Universal 3D** (URP template) — *do not* use Built-in.
3. Set **Project name** to `Nihil`, **Location** to `D:\repos\nihil-game`.
   - Result: `D:\repos\nihil-game\Nihil\` with `Assets`, `Packages`, etc.
4. Click **Create project**.
5. After creation, ask the advisor for the `.gitignore`, then:
   ```powershell
   git init
   # add .gitignore, then
   git add .
   git commit -m "chore: scaffold Unity 6.6 URP project"
   ```

### Import the free assets

Follow the [Asset Policy](#asset-policy) table. Import via:

- **Unity Asset Store** → *Add to My Assets* → *Import* (needs free Unity account).
- **Local packages** (Kenney/Quaternius zips) → drag into the Project window, or `Assets > Import Package > Custom Package`.

---

## Development Philosophy

**Rule of thumb: "Do it in the Editor; only code what no asset does."**

For every feature ask the same three questions, in order:

1. **Does Unity do it already?** (e.g. Character Controller, Physics: Rigidbody/Raycast, Particle System, Timeline, Animator/State Machines, NavMesh for enemy movement)
2. **Does a free asset do it?** (Starter Assets FPS controller, asset-store AI packs)
3. **Only then**: write the smallest C# script that fills the gap (e.g. a 15-line damage/health handler).

### Recommended build order per feature

| Feature | Editor route first | Script only if needed |
|---|---|---|
| Player movement | Starter Assets FPS Controller + Character Controller | — |
| Input | Input Actions asset (Editor) | — |
| Weapon (hitscan) | Starter Assets gun config, muzzle flash via Particle System | small fire/hitscan script |
| Melee/plasma arc | Weapon/ability prefabs, TrailRenderer | small script |
| Enemy damage | NavMesh Agent + Animator states for walk/dead | small HP + death script |
| Health/pickups | ScriptableObjects for item data | small pickup script |
| Arena flow | Timeline, trigger colliders, spawn points | level-bootstrap script |

---

## Asset Policy

**Only free assets.** Rule of thumb: prefer **CC0 / public domain** (no attribution required), then explicitly-free licenses, recording attribution in `CHANGELOG.md` whenever a license requires it.

| Source | Offerings | License | Typical use |
|---|---|---|---|
| [Unity Asset Store – free](https://assetstore.unity.com/) | **Starter Assets – First Person Controller** | Unity free | Player controller, weapon rig, weapon base assets |
| [Kenney.nl](https://kenney.nl/) | weapons, dungeon tiles, enemies, characters, audio | CC0 (public domain) | Level geometry, enemies, props, SFX |
| [Quaternius](https://quaternius.com/) | modular character/weapon packs | CC0 | Enemies, weapons, low-poly props |
| [Poly Pizza](https://poly.pizza/) | single 3D models | varies, mostly CC0 | Stand-in objects |
| [Poly Haven](https://polyhaven.com/) | textures, HDRIs, models | CC0 | Textures, skydome lighting |
| [ambientCG](https://ambientcg.com/) | PBR textures | CC0 | Surface textures |
| [Freesound](https://freesound.org/) | SFX | varies; filter CC0 | Gun / monster sounds |

**Attribution**: keep a `CREDITS.md` (or an `attributions` section in `CHANGELOG.md`) documenting each used asset's name, author, license. Start it as soon as the first asset is imported — not later.

---

## Milestones

High-level plan — finer work is logged in `CHANGELOG.md` as it happens.

| # | Milestone | Done when |
|---|---|---|
| M0 | Project scaffolding | Unity project created, `.gitignore`, first commit, editor opens, play mode runs an empty level |
| M1 | Whitebox arena | Grey-box level with player spawning and collision working |
| M2 | Movement + look | FPS control from Starter Assets: walk, sprint, crouch, jump, mouse look |
| M3 | Weapon firing | Hitscan/bullet weapon fires, muzzle flash, sound, damages a target |
| M4 | Enemies | At least one enemy type: moves toward player, takes damage, dies |
| M5 | Health + game state | Player HP, damage feedback, enemy HP, death/restart state |
| M6 | Juice + combat loop | Screenshake, particles, pickups, HUD (ammo/HP), arena spawn loop |

Each milestone ends with a **playable build in the editor** ("playtest") and a `CHANGELOG.md` entry describing what was done and what was learned.

---

## Working Practices

- **Advisor (me)**: suggest approaches, explain Unity concepts, review plans, answer questions — but *you* click, drag, and build in the Editor.
- **Session loop**: `plan → do → playtest → log`. Log *every* session in `CHANGELOG.md`, even half-hours: what you did, what broke, what you learned.
- **Commit discipline**: small commit per working step. Commit message per repo style.
- **Docs first**: before each milestone, re-read `CHANGELOG.md` and this readme's [Milestones](#milestones).

---

## Project Log

`CHANGELOG.md` is the living journal: decisions, milestones, lessons, and attributions in reverse-chronological order. Initialised at kickoff — **2026-09-16**.

---

*Last updated: 2026-09-16 — Project kickoff.*