# Credits

Asset attributions for **Nihil**. Every imported asset records its author, license, and redistribution terms here — required whenever its license demands attribution.

> **License scope**: The `LICENSE` file (MIT) covers only original code and docs written for this project. It does **not** cover third-party assets; each asset remains under its own license as recorded below.

## Policy

- **Free/CC0 assets only.** Prefer CC0 / public domain, then explicitly-free licenses.
- If an asset's license restricts redistribution, it must **not** be committed to this public repo (exclude via `.gitignore` and note the exclusion here).

## Assets

### 2026-09-16 — Sci-fi Sounds (Kenney)
- Author: Kenney — https://kenney.nl/assets/sci-fi-sounds
- License: **CC0 1.0 Universal** — free for any use incl. commercial, no attribution required
- Redistribution: unrestricted (public domain dedication)
- Notes: 70 normalized OGG files — lasers, explosions, engines. Imported into `Assets/Kenney/kenney_sci-fi-sounds/` for M3 shot SFX. Pruned to the single used clip (`laserSmall_000.ogg`); the rest stay in the gitignored `asset-vault/`.

### 2026-09-16 — Blaster Kit (Kenney)
- Author: Kenney — https://kenney.nl/assets/blaster-kit
- License: **CC0 1.0 Universal** — free for any use incl. commercial, no attribution required
- Redistribution: unrestricted (public domain dedication)
- Notes: Contains multiple blaster models, bullets, targets (FBX/glTF/OBJ). Imported into `Assets/Kenney/BlasterKit/` for M3 weapon.

### 2026-09-18 — Terrain textures: Ground087, Rock029, Rock037 (ambientCG)
- Author: ambientCG — https://ambientcg.com/
- License: **CC0 1.0 Universal** — free for any use incl. commercial, no attribution required
- Redistribution: unrestricted (public domain dedication)
- Notes: 2K PBR sets (Color, NormalGL, Roughness, AO). Imported into `Assets/Terrain/Textures/` for the alien-planet terrain — dirt layer (Ground087) + rock layers (Rock029/Rock037). Only the Unity-relevant maps are committed; the `.blend`/`.mtlx`/`.tres`/`.usdc` authoring sidecars are not.

### 2026-09-21 — UI SFX — `click_004.ogg` (Kenney)
- Author: Kenney — https://kenney.nl/assets/ui-audio
- License: **CC0 1.0 Universal** — free for any use incl. commercial, no attribution required
- Redistribution: unrestricted (public domain dedication)
- Notes: Single UI click imported into `Assets/Audio/` (author-provided `License.txt` kept next to it) — used as the HelmetLog typewriter beep, pitch-shifted in code.

### 2026-09-21 — Fonts: Michroma, Orbitron (Google Fonts)
- Author: Google Fonts — https://fonts.google.com/ (Michroma, Orbitron)
- License: **SIL Open Font License 1.1** — free use, modification, and redistribution, provided the license accompanies the font
- Redistribution: permitted verbatim / modified with OFL license text included
- Notes: Imported into `Assets/Fonts/` (TTF + generated SDF assets) for the HUD terminal look. **OFL license text ships next to each TTF** (`Michroma_OFL.txt`, `Orbitron_OFL.txt`) so redistribution stays compliant.

### 2026-09-21 — TextMesh Pro essentials (Unity) incl. LiberationSans
- Author: Unity Technologies / the TMP project; LiberationSans by Red Hat (as bundled by Unity)
- License: TMP package under Unity Companion License; bundled LiberationSans under OFL (license file shipped in `Assets/TextMesh Pro/Fonts/`)
- Redistribution: permitted as part of the Unity project
- Notes: "TMP Essential Resources" imported into `Assets/TextMesh Pro/` (fonts, materials, shaders, settings) so `HelmetLog.cs` can render HUD text.

### 2026-09-16 — Starter Assets – First Person + Third Person | Character Controllers (v2.0, Sep 2026)
- Author: Unity Technologies — [Asset Store listing 196526](https://assetstore.unity.com/packages/3d/characters/first-person-third-person-character-controllers-196526)
- License: **Unity Companion License** (commercial use permitted within Unity-authored content; distribution of the game fine; no Unity trademarks in branding)
- Redistribution: permitted as part of a Unity-authored project via Companion License
- Notes: Imported full package. Used subset only — First Person controller, Input System, Sample env walls/skybox. Unused content pruned from the repo per license-permitting strip: Third Person controller (scripts/character/animations/sfx), SpaceRobotKyle robot, Mobile UI touchscreen bundle, and the quality-level pipeline assets. The original `ThirdPersonStarterAssetsDeployMenu.cs` editor script was removed with it (it compiled against the deleted `ThirdPersonController`).