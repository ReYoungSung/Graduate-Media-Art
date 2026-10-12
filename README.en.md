[한국어](README.md) | **English**

# Graduate-Media-Art — 활주로 (Runway)

An interactive media art project created for Handong Global University's 2024 graduation ceremony. It uses Unity VFX and OptiTrack motion capture and was designed for a large curved-screen exhibition.

## Background

The exhibition was developed while learning Unity VFX based on lectures by new media artist 김성은. A related music video was also produced using Unreal Engine 5 and OptiTrack. The Unity project in this repository is located in `GMA_MediaArtWall/`.

## Team

EyeCU (Computer Graphics Laboratory) — 이영성 (Youngsung Ree), 김유겸

## Development environment

| Item | Value |
| --- | --- |
| Unity Editor | **2021.3.9f1** |
| Unity project folder | `GMA_MediaArtWall/` |
| Default branch | `Master` |

The Unity version is taken from [ProjectVersion.txt](GMA_MediaArtWall/ProjectSettings/ProjectVersion.txt).

- OptiTrack motion-capture equipment and a tracking space
- Immersion Pro and a large curved screen to reproduce the original exhibition setup

## Getting started

```bash
git clone --branch Master https://github.com/ReYoungSung/Graduate-Media-Art.git
```

1. Install the Editor version above through Unity Hub.
2. Add the repository's `GMA_MediaArtWall` folder as a project. The repository root and Unity project folder are different.
3. Complete the initial import and Package Manager dependency restoration.
4. Open `Assets/GMA_Project/GMA_BLock_Art_Wall.unity` and enter Play mode.

The build configuration includes the block-art scene and `Assets/GMA_Project/GMA_Text_Art_Wall.unity`. You can open each scene separately. Reproducing the full exhibition requires motion-capture connectivity and on-site display configuration.

See [EditorBuildSettings.asset](GMA_MediaArtWall/ProjectSettings/EditorBuildSettings.asset) for build configuration and [manifest.json](GMA_MediaArtWall/Packages/manifest.json) for dependencies. The `Assets/` paths below are relative to the Unity project folder.

## Main folders

| Path | Contents |
| --- | --- |
| [Assets/GMA_Project/](GMA_MediaArtWall/Assets/GMA_Project/) | Block-art and text-art scenes |
| [Assets/OptiTrack/](GMA_MediaArtWall/Assets/OptiTrack/) | OptiTrack integration |

## Graphics and audio

The package configuration uses HDRP 12.1.7, LASP 2.1.6, and LASP VFX 1.0.2. Finish package restoration during the initial import, then check the exhibition PC's graphics environment, audio input, and tracking-data reception separately.

## Usage

### Running the exhibition

1. Configure the tracked target in OptiTrack and verify that Unity's tracked object follows its physical position.
2. Set the large display's output resolution and projection position, then run the block-art or text-art scene.
3. Bring the tracked wand into the scene's interaction areas and check the response.
4. Use the start area to reset the artwork for the next visitor.

### Interactions and operator controls

The area names below are tags defined in `MagicWanding`. Check their correspondence to on-site signage and component connections in the scene being used.

| Input/area | Response |
| --- | --- |
| Touch `StartPoint` | Cycle the VFX color and reset the artwork |
| Touch area `A`, `B`, `C`, or `D` | Activate the connected logo effect |
| Touch `ArtTrigger` | Trigger the radius-based sphere-removal effect |
| Number keys starting at `1` | Select VFX templates on objects with `ChangeVisualEffectTemplate` attached |

Area interactions have a 0.75-second cooldown to prevent repeated triggers. If rapid contact produces no response, wait briefly and try again. Number keys are limited to the number of templates registered in the Inspector.

### Ending and troubleshooting

Exit Play mode in the Editor. If tracking stops, check equipment connectivity and Unity's data reception first. The Space-key code attempts to switch to `Scene2`, which differs from the currently registered exhibition scene names. Fix the scene connection before using it as an exhibition switching key.

Behavior references: [MagicWanding.cs](GMA_MediaArtWall/Assets/MagicWanding.cs) · [ChangeVisualEffectTemplate.cs](GMA_MediaArtWall/Assets/ChangeVisualEffectTemplate.cs)
