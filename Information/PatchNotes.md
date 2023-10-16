<p align="center">
    <a href="#"><img src="https://raw.githubusercontent.com/Deaadman/UniversalTweaks/release/Images/TitleCardPatchNotes.png"></a>

---

Welcome to the patch notes for this modification. This document provides a detailed insight into the history of every update made to this project. These patch notes keep you informed about the latest additions, bug fixes and enhancements which each release. Along with current information, it also brings you insights as to upcoming possible ideas.

So please note that the upcoming ideas provided within these patch notes isn't final and is subject to change and should not be interpreted as a guarantee of implementation -and production may be halted at any time due to reasons such as life, and loss of interest.

| Versions: |
| - |
| [vX.X.X](#vxxx) |
| [v1.1.0 - Survivours Ease Update](#v110---survivours-ease-update) |
| [v1.0.0 - Initial Launch](#v100---initial-launch) |

---

## vX.X.X:

>**Note:** A bundle of ideas, with no guarantee of implementation.

- Flashlight Tweaks
	- Prevent `High` state if there isn't an aurora (may balance things)
	- Figure out why the `Intense` audio won't play without an aurora.
	- Disable flashlight flicker if there is not aurora.
	- Allow a small chance of wolves to be scared by the `High` state flashlight without an aurora (only at night).
- Spray Paint Tweaks
	- Remove the limiter of where paint can be placed (sprayed). Suggested by **FarcryBliss**.
- Snow Shelter Tweaks
	- Slow down the decay rate of snow shelters, this gives them more of a purpose rather than being emergency shelters. Suggested by **StrayCat**.

---

## v1.1.0 - Survivours Ease Update:

> **Upcoming Release...**

### Highlights / Key Changes:
- Removed `Headache` debuff from Peach and Rose Hip Pies - Suggested by **Valerie**.

### Added:
- Added a new `FoodTweaks` folder.
- Added a new `FoodTweaks.cs` file.
- Added two methods `PieItems()` and `RemoveHeadacheDebuffFromItems()`.
	- These handle getting the items, and removing the debuff.
- Added the `OnSceneWasInitialized()` method to `Main.cs`.
	- This calls the `PieItems()` method, once the method is called - it isn't called again.

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