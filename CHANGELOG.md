# Project History — Nihil

Living journal for the *Nihil* project. Newest entries at the top.

**Legend**: `[Decision]` `[Milestone]` `[Changed]` `[Added]` `[Fixed]` `[Lesson]` `[Attribution]`

---

## 2026-09-18 — Terrain + alien-sun pivot, back on the Doom-like

### [Decision] TRON theme shelved
- Auditioned a neon TRON look (black void sky, glowing grid lines, bloom-heavy post) as a diversion. Fun to prototype, but it fights the Doom-like direction — shelved. Sky and lighting now point back at the hostile-alien-planet brief.
- Lesson reminder: a theming experiment is cheap to try when it's all material/volume tweaks; nothing below needed tearing out.

### [Changed] Level opens up
- Walls + floor instances replaced with a single **Terrain** object + a few hills — replaces the walled 20×16 arena with an open battlefield. Cover is now terrain-driven (hills), so spawn/cover layout gets reconsidered before M4.
- Uncommitted gun-feel tuning from the last session carries forward: `bobHeight` 0.009→0.02, `swayAmount` 0.05→0.1.

### [Changed] Skybox → large alien sun
- `Assets/Settings/Sky.mat` (created last session, now Skybox/Procedural) tuned from "black void" to a big glaring sun for the alien-planet look.
- [Lesson] Unity 6.6's Procedural skybox shader **no longer has `Ground Exponent`** — the 6000.6 manual lists exactly: Sun · Sun Size · Sun Size Convergence · Atmosphere Thickness · Sky Tint · Ground · Exposure. Earlier that field existed in the legacy shader; don't look for it.
- Sun disk direction follows the scene's directional light — aim the light, not a skybox knob, to place the sun.

### [Added] Terrain wilderness — the planet
- Walled 20×16 arena retired; one **Terrain** + sculpted hills replaced it as the battlefield. Terrain data + terrain layers live under `Assets/Terrain/` (textures in `Assets/Terrain/Textures/`, layers in `Assets/Terrain/Layers/`).
- Painted with two ambientCG terrain layers — dirt across the floor, rock on the hill crests — see `CREDITS.md`.
- Terrain material `Dirt.mat` (**URP → Terrain → Lit**) assigned via Terrain Settings.
- [Lesson] Unity 6 terrain tools live in the **Scene-view overlay**, not the Inspector — and "Paint Texture" hides under a **Materials Mode** category (Stamp Terrain is a separate *sculpt* tool).
- [Lesson] Unity 6's Procedural skybox shader **dropped `Ground Exponent`** — 6000.6 manual lists exactly Sun · Sun Size · Sun Size Convergence · Atmosphere Thickness · Sky Tint · Ground · Exposure. Horizon-glow moods now ride on Atmosphere Thickness + Sky Tint.
- [Known] Steep faces are cheesable: `CharacterController` treats near-vertical slopes as walls, and even a *single* jump pressed against one carries the player up to the crest (wall-riding). `slopeLimit` can't stop it (governs walking only) — the planned `TerrainSlide.cs` (multi-ray steep check + downhill slide + jump-lock) is specced but not yet written.

### [Changed] Game feel
- Gun sway/bob tuned: `bobHeight` 0.009→**0.02**, `swayAmount` 0.05→**0.1**.
- Jump feel tuning pass: Jump Height reduced, Gravity raised (less floaty). Dropping Slope Limit to ~30 confirmed it blocks *walking* up steep faces but does nothing for jump arcs (see TerrainSlide note above).

---

## 2026-09-16 — Gun sway + unused-asset review

### [Added] Gun sway (M3 feel polish)
- `GunSway.cs` in `Assets/Kenney/BlasterKit/` — procedural walk bob (velocity-driven, grounded-only) + mouse-delta look sway. Cosmetic only; `Blaster.cs` ray stays camera-centric, so sway never shifts aim.
- [Fixed] v1 look-sway sampled camera Euler per-frame in `LateUpdate`, racing the controller/Cinemachine camera writes → one-frame twitch on turns. Rewrote to read `Mouse.current.delta` + `maxSway` clamp: ordering-proof and immune to screen-edge spikes. The two sway arms (camera-sampled vs mouse-sampled) were both diagnosed carefully before switching.

### [Lesson] Script wiring gotchas (both hit this session)
- Component was placed on a **new empty child** (`GunSway` GameObject) floating 1 m below the gun — swaying an invisible object. Must attach to the same object as `Blaster`.
- `GetComponentInParent<CharacterController>()` returns null when the camera is NOT parented under the player capsule → silent `enabled = false`. Use `FindAnyObjectByType<CharacterController>()` for the prototype.

### [Review] Unused-asset sweep (~93 MB unreferenced in `Nihil/Assets`)
Ran a GUID reachability closure from `Arena.scene`. Findings + plan:
- **Delete** `Starter Assets/Runtime/ThirdPersonController/` (~86 MB — model, animations, textures, sfx, prefabs).
- **Delete** `Starter Assets/Editor/ThirdPersonStarterAssetsDeployMenu.cs` — it compiles against the `ThirdPersonController` type; leave it in and the Editor assembly breaks.
- **Delete** `Starter Assets/Runtime/SpaceRobotKyle/` (~6.5 MB demo robot) and `Starter Assets/Runtime/Mobile/` (~0.2 MB; Windows-only target).
- Optional small: `Starter Assets/Runtime/Settings/` quality-pipeline assets, root `TutorialInfo/`, root `Readme.asset`.
- **Keep**: `Sample/Environment` wall+skybox chain, `Sample/FirstPersonController/Playground` lighting (**Arena is still bound to its baked lighting data** — re-bake Arena later), root `InputSystem_Actions.inputactions` (project-settings default), `Assets/Settings/*` (pipeline), `StarterAssetsDeployMenu.cs` + URP wizard (Editor tools).
- [Fixed] `EditorBuildSettings.asset` still lists `Assets/Scenes/SampleScene.unity` (the deleted URP template scene) — a build would break. Set Build Settings to `Assets/Scenes/Arena.unity`.
- Verified: `asset-vault/` present (7.3 MB, 229 files, gitignored); Kenney committed content is only what the game references (blaster-a, one laser clip).

### [Changed] Tooling
- External script editor switched Notepad → Visual Studio (Edit → Preferences → External Tools).

### [Lesson] Closure scan bug → Mobile blunder (review pass 2)
- My scene-GUID reachability closure silently under-reported refs (it also missed `StarterAssets.inputactions`, which IS wired to the player). Result: `Runtime/Mobile/` was wrongly flagged unused.
- **Truth:** the Arena scene instantiates two Mobile-bundle root prefabs — `UI_TouchScreenInput` + `UI_EventSystem` (auto-disabled on desktop via `MobileDisableAutoSwitchControls`). Deleting Mobile broke those references.
- **Fix applied in Editor:** delete both broken root GameObjects in the Arena hierarchy (they were inert on desktop) → scene clean again.
- **Remaining scene quirks:** arena carries a stale custom-reflection cubemap ref (`619e305f…`) from the copied Playground lighting — cosmetic; resolves on a proper Arena re-bake. `474bcb49` / `e823cd5b` are URP package assets (`UniversalAdditionalLightData`, `ParticlesUnlit` default mat) — benign.
- [Lesson] Re-verify reachability scans against git history when trusting a clean verdict; scene copies inherit stale refs the closure can mislabel.

### Next steps
- Remove `SampleScene.unity` from Build Settings (keep only `Assets/Scenes/Arena.unity`), playtest the arena, then commit the cleanup.

---

## 2026-09-16 — M3 progress: hitscan blaster

### [Added] Assets (Kenney, CC0)
- **Blaster Kit** → `Assets/Kenney/BlasterKit/` — 18 blasters, targets, props. Only `blaster-a.fbx` (+ textures) imported into the project; full pack kept in local `asset-vault/` (gitignored).
- **Sci-fi Sounds** → `Assets/Kenney/kenney_sci-fi-sounds/` — 70 CC0 clips; only `laserSmall_000.ogg` kept in project for the shot sound.
- Both logged in `CREDITS.md`.

### [Added] Gameplay
- Blaster model mounted on the FPS camera; `Blaster.cs` hitscan: fires on LMB (`Input System`, no kit edits), muzzle-flash particle + one-shot laser SFX in `Fire()`.
- Hit reporting via `Debug.Log` (fills M3 "damages a target" once a small HP handler exists; ray already resolves targets by name).

### [Changed] Asset workflow
- Unreferenced models/audio moved out of the Unity project into `asset-vault/` at repo root; `.gitignore` now excludes `asset-vault/`. Rule: commit only what the game references.
- [Lesson] Moving paths with `Move-Item` in PowerShell is error-prone; GLB/OBJ duplicate formats + preview art were dropped in the move (re-downloadable, CC0). Verify vault contents after bulk moves.

### Next
- M3 wrap: target with a tiny HP handler to close "damages a target", or proceed directly to M4 enemies (they'll need the same handler).

---

## 2026-09-16 — M1 & M2: whitebox arena + FPS movement

### [Milestone] M1 — Complete
- `Arena.unity` created from the Starter Assets Playground scene copy (kept player rig, removed demo environment).
- 20×16 m room built from `Wall_Prefab` instances + floor; geometric positions used, overlaps intentional. Materials skipped for now.
- Settings: grid snap enabled (Scene view magnet, Move Increment = 1).
- First lesson learned: **`.unity` files** are the scene assets; a same-named folder (baked lighting) is not.

### [Milestone] M2 — Complete (effectively)
- The Starter Assets First Person controller covers the whole milestone: walk, sprint, crouch, jump, mouse look — all playtested inside the arena during M1.
- No extra work needed; M2 folded into M1's playtest.

### [Lesson] URP material migration
- On touching materials, URP 17.6 auto-migrated three Starter Assets `.mat` files (added `_ScreenSpaceReflections`, float drift). Reverting is futile churn — committed once as part of M1.

### Next steps
- **M3 — Weapon firing**: hitscan fire, muzzle flash, sound, damages a target.

---

## 2026-09-16 — Commercial release kept possible

### [Decision] Sellability
- Keep the **option to sell** the finished game (e.g. on itch.io) open as a goal. It is not a current action item — just making sure nothing precludes it later.
- **License check (clear for commercial sale):**
  - Starter Assets – First Person Controller (Unity Companion License): royalty-free right to reproduce, modify, and distribute within Unity-authored content; the game itself is not a derivative of the assets. Commercial distribution is fine.
  - Unity 6 + Unity Personal: free below **$200K USD / last 12 months**; no per-install runtime fee on Unity 6. If that cap is ever crossed → upgrade to Pro (no retroactive penalty).
  - Planned CC0 pipeline (Kenney, Quaternius, Poly Haven, ambientCG) is commercial-safe, including resale. Freesound requires CC0-filtering.
- Consequence for asset policy: **keep `CREDITS.md` accurate** — a re-distribution-restricting free asset is the one thing that could block a sale.

---

## 2026-09-16 — Repo live on GitHub

### [Milestone] M0 — Repository pushed
- Created public repo `nihil-game` via `gh repo create` and pushed `master` (all Git/GitHub ops done from the CLI).
- Live at `https://github.com/Zenrajko/nihil-game`.
- Added `LICENSE` (MIT, © 2026 Zenrajko), license-scope note in `CREDITS.md`, License section in `README.md`, and `*.slnx` to `.gitignore`.

### Next steps
- **M1 — Whitebox arena**: grey-box room (floor + walls), player spawn, working collision. This is the first real playtest milestone.

---

## 2026-09-16 — Public portfolio repo + M0 complete

### [Decision] Repository visibility
- Host the project on GitHub as a **public** repo named `nihil-game` (portfolio purposes). Create with no README/license to avoid clashes — both already exist locally.
- Asset redistribution policy: every imported asset records its license + redistribution terms in `CREDITS.md`. If any asset's license restricts redistribution, it is **not** to be committed — exclude via `.gitignore` and note the exclusion. Adopted because the repo's public contents effectively redistribute all included assets.
- Currently-imported Starter Assets (Unity free starter package) permit redistribution - repo is clean today.

### [Milestone] M0 — Complete
- Unity 6.6 `6000.6.0f1` URP project `Nihil/` created via Unity Hub (`Universal 3D` template), opens and plays the sample scene.
- Committed: `.gitattributes` (`* text=auto`), `.gitignore` (subfolder-aware), docs, and the full Unity project (Assets/Packages/ProjectSettings + `.meta` files).
- `core.autocrlf=false` set locally to silence CRLF noise.

### Next steps
1. Create the public GitHub repo, then `git remote add origin ...` + `git push -u origin master`.
2. Create `CREDITS.md` placeholder.
3. First playtest milestone: whitebox arena (M1).

---

## 2026-09-16 — Unity version pinned to 6.6

### [Changed] Engine choice
- Existing install is **Unity 6.6 (6000.6.0f1)** — a Supported release (same support/stability as LTS until 6.7 ships). Chosen over the installed alpha (**6000.7.0a6**) and over installing 6.3 LTS separately. Continued with **Unity 6.6**.

---

## 2026-09-16 — Project kickoff

### [Decision] Scope
- Build a **Doom-like FPS prototype** (boomer shooter: fast movement, hitscan/plasma combat, arena fights) — a playable slice, not a full game.
- "Doom-like" means genre homage only (fast movement, arcade combat, arena structure). **No Doom content will be copied** - all art, levels, names, and audio are original or free-licensed assets; nothing derived from id/Bethesda IP.
- Learn Unity by doing; produce the game **in the Editor**, not from code.
- **Free assets only** (CC0 preferred). Reuse assets over writing code wherever possible.

### [Decision] Tech choices
- **Unity 6.6** (6000.6.0f1) — Supported release, pinned to the existing install (see "Unity version pinned to 6.6" above). [source](https://unity.com/releases/unity-6)
- **URP** via the `Universal 3D` template — Built-in Render Pipeline is no longer recommended for new titles, so not used.
- **Starter Assets – First Person Controller** for movement + look (zero movement code to write).
- **Input System** package for editor-configured input.
- Target: Windows desktop. Git for version control (`.gitignore` to be added after the Unity project is created).

### [Milestone] M0 — Delivered: planning docs
- Created `README.md` (overview, goals, tech stack, asset policy, milestones M0–M6).
- Created this journal (`CHANGELOG.md`) with the session-logging convention above.

### [Lesson] Assistant-usage rule
- I (the human) do the Editor work; the advisor suggests/reviews/explains but does not build. Keep this in mind and push back if a suggestion drifts into "telling you to hand it all to me."

### Next steps
1. Create the Unity project (Unity Hub → `Universal 3D` → name `Nihil` inside this repo folder).
2. Ask the advisor for a `.gitignore`, git init, first commit.
3. Record the exact Unity version here.

---

## Logging guide

**How to log**: after every session (even a short one), add a dated entry at the top of this file: what you did, what you planned to do, what broke, what you learned, what's next. Keep it short and factual. This file is the project's memory — the more honest it is, the better the advisor can keep you on track.

### Template — new session entry

```
## YYYY-MM-DD — short title
### [Type] What
- ...
### [Lesson] What I learned
- ...
### Next steps
- ...
```