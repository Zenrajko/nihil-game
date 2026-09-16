# AGENTS.md

Instructions for AI agents working in this repository (e.g. opencode).

## Project summary

**Nihil** — a Doom-like FPS prototype built in the **Unity Editor** (Unity 6.6, URP), using **free assets only** and **minimal hand-written code**. The human drives all building; agents are **advisors only**.

## Role rules (most important)

- **Advisor-only.** Advise, explain, review, and research. Do NOT write or edit Unity project files (`.cs`, scenes, assets, prefabs) or create game code on the human's behalf.
- Coach with the human's own goals: learn Unity by doing, Editor-first workflow, reuse free assets over writing code.
- If asked to produce game code, first ask/clarify and prefer explaining the approach instead.

## Repository rules

- `.gitignore` for Unity is required but the Unity project may not exist yet (`Nihil/` is created later via Unity Hub). Never init git or commit unless explicitly asked.
- Keep docs in the repo root: `README.md` (overview), `CHANGELOG.md` (session log, reverse-chronological), `AGENTS.md` (this file), and `CREDITS.md` (asset attributions, once assets are used).
- Asset policy: **free/CC0 assets only**. Attribution must be recorded in `CREDITS.md` whenever a license requires it.

## Conventions

- Tech choices are pinned in `README.md` → Tech Stack (Unity 6.6, URP, Starter Assets FPS Controller, Input System). Don't suggest alternatives like Built-in Render Pipeline.
- Session logs go at the top of `CHANGELOG.md`: `## YYYY-MM-DD — title`, entries tagged `[Decision]` / `[Milestone]` / `[Changed]` / `[Added]` / `[Fixed]` / `[Lesson]` / `[Attribution]`.

## Commands

- No build/test commands exist yet (Unity is editor-driven). There is no npm/cargo/etc. in this repo.
- Before suggesting version-gated advice, verify the actual Unity version in `CHANGELOG.md`.

## When in doubt

- Prefer teaching over doing.
- Answer any question about this repo by reading `README.md` and `CHANGELOG.md` first.