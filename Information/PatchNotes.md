<p align="center">
    <a href="#"><img src="https://raw.githubusercontent.com/Deaadman/UniversalTweaks/release/Images/PatchNotesHeading.png"></a>

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

---

## v1.1.0 - Survivours Ease Update:

> **Upcoming Release...**

### Highlights / Key Changes:
- Fixed a small `UISprite` misalignment on the `FeedFire` panel. 
- Removed `Headache` debuff from Peach and Rose Hip Pies - Suggested by **Valerie**.
- Reduced how quickly snow shelters decay per day, from `100` to `50` HP - Suggested by **StrayCat**.
- Changed the spacing between how close decals can be placed - Suggested by **FarcryBliss**..
	- Currently under testing to find the right value, or whether it should be changed. 

### Added:
- Added a new `FoodTweaks` folder.
- Added a new `FoodTweaks.cs` file.
- Added two methods `PieItems()` and `RemoveHeadacheDebuffFromItems()`.
	- These handle getting the items, and removing the debuff.
- Added the `OnSceneWasInitialized()` method to `Main.cs`.
	- This calls the `PieItems()` method, once the method is called - it isn't called again.
<br></br>
- Added a new `SnowShelterTweaks` folder.
- Added a new `SnowShelterTweaks.cs` file.
- Added a harmony patch `SnowShelterManager.InstantiateSnowShelter()`.
	- This targets everytime a new snow shelter is made, then `__result.m_DailyDecayHP` changes from `100` to `50`.
<br></br>
- Added a new `UITweaks` folder.
- Added a new `UITweaks.cs` file.
- Added a harmony patch `Panel_FeedFire.Initialize()`.
	- This targets when the panel is built, then changes the `localPosition` and `localScale` of the `m_Sprite_FireFill` UISprite.
<br></br>
- Added a new `DecalTweaks` folder.
- Added a new `DecalTweaks.cs` file.
- Added a harmony patch `DynamicDecalsManager.Start()`.
	- This targets the `m_DecalOverlapLeniencyPercent` field and adjusts it from `20%` to `??%`.
	- This harmony patch has currently been commented out, testing whether it should even be implemented.

### Changed / Updated:
- Changed the following access modifiers to `private`.
	- `FlashlightKeepBatteryChange` class and it's `Prefix.`
	- `FlashlightFunctionality` class and it's `Prefix`.
	- `FlashlightBatteryDrain` class and it's `Postfix`.
	- `SnowShelterDecayRate` class and it's `Postfix`.
	- `RemoveHeadacheDebuffFromItems` method.
<br></br>
- Updated the `FlashlightPatches.cs` name to `FlashlightTweaks.cs`.

### Removed:
- Removed the `OnInitializeMelon()` method which calls the `LogStarter()` method.
	- A message displaying that the mod as loaded and on what version no longer shows, as MelonLoader already does that.

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
