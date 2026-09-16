# Project History — Nihil

Living journal for the *Nihil* project. Newest entries at the top.

**Legend**: `[Decision]` `[Milestone]` `[Changed]` `[Added]` `[Fixed]` `[Lesson]` `[Attribution]`

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