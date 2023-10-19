<p align="center">
    <a href="#"><img src="https://raw.githubusercontent.com/Deaadman/UniversalTweaks/release/Images/PatchNotesHeading.png"></a>

---

Welcome to the patch notes for this modification. This document provides a detailed insight into the history of every update made to this project. These patch notes keep you informed about the latest additions, bug fixes and enhancements which each release. Along with current information, it also brings you insights as to upcoming possible ideas.

So please note that the upcoming ideas provided within these patch notes isn't final and is subject to change and should not be interpreted as a guarantee of implementation -and production may be halted at any time due to reasons such as life, and loss of interest.

| Versions: |
| - |
| [vX.X.X](#vxxx) |
| [v1.1.0 - Ton of Tweaks Update](#v110---ton-of-tweaks-update) |
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

## v1.1.0 - Ton of Tweaks Update:

> **Upcoming Release...**

### Highlights / Key Changes:
- Fixed a small `UISprite` misalignment on the `FeedFire` panel. 
- Now requires LocalizationUtilities as a dependent mod.
- Removed `Headache` debuff from Peach and Rose Hip Pies - Suggested by **Valerie**.
- Reduced how quickly snow shelters decay per day, from `100` to `50` HP - Suggested by **StrayCat**.
- Decals (spray paint) now have no restrictions to how close they can be placed to one another - Suggested by **FarcryBliss**.
- Snares now have an option to reset them from the inspect menu if a bunny was caught - Suggested by **Mentat**.
- Aiming with revolver no longer requires you to be stationary - Suggested by **Romain**.

### Added:
- Added a `Tweaks` folder.
<br></br>
- Added a `FoodTweaks.cs` file.
- Added two methods `PieItems()` and `RemoveHeadacheDebuffFromItems()`.
	- These handle getting the items, and removing the debuff.
- Added the `OnSceneWasInitialized()` method to `Main.cs`.
	- This calls the `PieItems()` method, once the method is called - it isn't called again.
<br></br>
- Added a `SnowShelterTweaks.cs` file.
- Added a harmony patch `SnowShelterManager.InstantiateSnowShelter()`.
	- This targets everytime a new snow shelter is made, then `__result.m_DailyDecayHP` changes from `100` to `50`.
<br></br>
- Added a `UITweaks.cs` file.
- Added a harmony patch `Panel_FeedFire.Initialize()`.
	- This targets when the panel is built, then changes the `localPosition` and `localScale` of the `m_Sprite_FireFill` UISprite.
<br></br>
- Added a `DecalTweaks.cs` file.
- Added a harmony patch `DynamicDecalsManager.Start()`.
	- This targets the `m_DecalOverlapLeniencyPercent` field and adjusts it from `20%` to `100%`.
	- This means that decals now have no restrictions with how close they can be placed to one another.
<br></br>
- Added a `SnareTweaks.cs` file.
- Added two harmony patches `PlayerManager.InitLabelsForGear()` and `PlayerManager.UpdateInspectGear()`.
	- `InitLabelsForGear()` adds the `Equip` action button for the snare when the state is set to `WithRabbit`.
	- `UpdateInspectGear()` is the function that allows the snare to be set to `Set` from the inspect menu.
<br></br>
- Added a `Localization.json` file.
- Added a `LoadLocalizations()` method to be called in `OnInitializeMelon()`.
	- This handles all the different languages for the `GAMEPLAY_SetSnare` localization.
	- Universal Tweaks now requires LocalizationUtilities as a dependent mod.
<br></br>
- Added a `GunTweaks.cs` file.
- Added two harmony patches `vp_FPSPlayer.Update()` and `Panel_HUD.Update()`.
	- `vp_FPSPlayer.Update()` removes the walking restrictions when aiming with a revolver.
	- `Panel_HUD.Update()` removes the `m_AimingLimitedMobility` sprite that comes up when aiming with a revolver.

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
- Removed the `LogStarter()` method within `OnInitializeMelon()`.
	- This was a message displaying that the mod as loaded and on what version no longer shows, as MelonLoader already does that.

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
