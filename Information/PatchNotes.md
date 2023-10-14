<p align="center">
    <a href="#"><img src="https://raw.githubusercontent.com/Deaadman/UniversalTweaks/release/Images/TitleCardPatchNotes.png"></a>

---

Welcome to the patch notes for this modification. This document provides a detailed insight into the history of every update made to this project. These patch notes keep you informed about the latest additions, bug fixes and enhancements which each release. Along with current information, it also brings you insights as to upcoming possible ideas.

So please note that the upcoming ideas provided within these patch notes isn't final and is subject to change and should not be interpreted as a guarantee of implementation -and production may be halted at any time due to reasons such as life, and loss of interest.

| Versions: |
| - |
| [vX.X.X](#vxxx) |
| [v1.0.0 - Initial Launch](#v100---initial-launch) |

---

## vX.X.X:

>**Note:** A bundle of ideas, with no guarantee of implementation.

- Flashlight Tweaks
	- Prevent `High` state if there isn't an aurora (may balance things)
	- Figure out why the `Intense` audio won't play without an aurora.

---

## v1.0.0 - Initial Launch:

> Released on the **14th of October 2023**.

### Highlights / Key Changes:
- Flashlights now work without an aurora.
	- Flashlights are only charged during an aurora, so use wisely.

### Added:
- Added a new `FlashlightPatches.cs` file.
- Added three harmony patches which target specific things.
	- `FlashlightItem.GetNormalizedCharge` targets the battery of the flashlight.
	- `FlashlightItem.IsLit` allows for the flashlight to turn on and off.
	- `FlashlightItem.Update` drains the battery without an aurora.