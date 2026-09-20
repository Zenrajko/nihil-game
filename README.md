# Nihil

**A Doom-style first-person shooter prototype.** Fast arena combat, a sleek retro-future look, and zero paid assets.

Nihil is a homage to the boomer-shooter genre — entirely original art, levels, and weapons, built in the Unity Editor with **100% free assets** and minimal hand-written code.

---

## Screenshots

![Nihil alien-planet arena with fog](screenshots/Screenshot%202026-09-19%20124657.png)

*Expanded alien-planet terrain with distance fog — built-in URP scene fog rolls in across the sculpted hills, leaving the sky clear.*

![Nihil alien-planet arena](screenshots/Screenshot%202026-09-18%20125617.png)

*Open alien-planet arena — sculpted terrain, dirt + rock layers, giant-sun skybox. TerrainSlide stops wall-riding on the cliffs.*

![Nihil whitebox arena](screenshots/Screenshot%202026-09-16%20141127.png)

*First playtest in the whitebox arena — hitscan blaster with muzzle flash and laser SFX (M3).*

---

## Features (in progress)

- **Fast "boomer shooter" movement** — sprint, jump, crouch — **done** (M1/M2)
- **Hitscan weapon** — instant-hit gun with muzzle flash, impact, and sound (M3)
- **Distance fog** — built-in URP scene fog, thins out the horizon (no post-processing)
- **Helmet HUD + in-fiction dialogue** — incoming transmissions type into a log, protagonist lines in chat, with a Cinemachine cut at the energy source
- **Arena fights** against simple chasing enemies (M4)
- **Health, damage, death & restart** game state (M5)
- **Retro-juice** — screenshake, particles, pickups, HUD (M6)

> Status: pre-alpha prototype — M0–M2 complete, M3 in progress, plus a working story intro (helmet dialogue + cinematic cut), set on an open alien-planet arena — see [Roadmap](#roadmap).

---

## How to run

1. Install **Unity 6.6 LTS-line** (`6000.6.0f1`, Supported) via Unity Hub
2. Open this repo's `Nihil/` folder as a project (Hub → **Open → Add project from disk** → select `Nihil/`)
3. Open the `Arena` scene and press **Play**

Builds for Windows desktop target (M1+).

---

## Tech stack

| Layer | Choice |
|---|---|
| Engine | Unity 6.6 (6000.6.0f1, URP) |
| Render pipeline | Universal Render Pipeline (URP) |
| Player controller | Starter Assets – First Person Controller (free) |
| Input | Unity Input System (Editor-configured) |
| Camera / VFX | Cinemachine · Particle System · Shader Graph |
| Code | Minimal C# — gameplay composed in the Editor |

Read more in [`CREDITS.md`](CREDITS.md) (all assets free, CC0-preferred).

## License

Original code & docs: **MIT** (see [`LICENSE`](LICENSE)). Third-party assets remain under their respective licenses — see [`CREDITS.md`](CREDITS.md).

---

## Roadmap

| # | Milestone |
|---|---|
| M0 | Project scaffolding — **done** |
| M1 | Whitebox arena — **done** |
| M2 | Movement + look — **done** |
| M3 | Weapon firing |
| M4 | Enemies |
| M5 | Health + game state |
| M6 | Juice + combat loop |

Detailed progress is logged in [`CHANGELOG.md`](CHANGELOG.md).

---

*Built with free assets only ([Kenney](https://kenney.nl/), [Quaternius](https://quaternius.com/), [Poly Haven](https://polyhaven.com/), Unity Starter Assets, and more — see `CREDITS.md`).*