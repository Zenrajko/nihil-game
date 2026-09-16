# Credits

Asset attributions for **Nihil**. Every imported asset records its author, license, and redistribution terms here — required whenever its license demands attribution.

> **License scope**: The `LICENSE` file (MIT) covers only original code and docs written for this project. It does **not** cover third-party assets; each asset remains under its own license as recorded below.

## Policy

- **Free/CC0 assets only.** Prefer CC0 / public domain, then explicitly-free licenses.
- If an asset's license restricts redistribution, it must **not** be committed to this public repo (exclude via `.gitignore` and note the exclusion here).

## Assets

### 2026-09-16 — Starter Assets – First Person + Third Person | Character Controllers (v2.0, Sep 2026)
- Author: Unity Technologies — [Asset Store listing 196526](https://assetstore.unity.com/packages/3d/characters/first-person-third-person-character-controllers-196526)
- License: **Unity Companion License** (commercial use permitted within Unity-authored content; distribution of the game fine; no Unity trademarks in branding)
- Redistribution: permitted as part of a Unity-authored project via Companion License
- Notes: Imported full package. Deprecation warnings present on import (`FindObjectsByType(FindObjectsSortMode)` in `Editor/ThirdPersonStarterAssetsDeployMenu.cs`) — left as-is to keep parity with the store asset; the code is functional and Third Person controller is unused.