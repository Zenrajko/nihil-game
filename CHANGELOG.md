# Project History — Nihil

Living journal for the *Nihil* project. Newest entries at the top.

**Legend**: `[Decision]` `[Milestone]` `[Changed]` `[Added]` `[Fixed]` `[Lesson]` `[Attribution]`

---

## 2026-09-16 — Unity version pinned to 6.6

### [Changed] Engine choice
- Existing install is **Unity 6.6 (6000.6.0f1)** — a Supported release (same support/stability as LTS until 6.7 ships). Chosen over the installed alpha (**6000.7.0a6**) and over installing 6.3 LTS separately. Continued with **Unity 6.6**.

---

## 2026-09-16 — Project kickoff

### [Decision] Scope
- Build a **Doom-like FPS prototype** (boomer shooter: fast movement, hitscan/plasma combat, arena fights) — a playable slice, not a full game.
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