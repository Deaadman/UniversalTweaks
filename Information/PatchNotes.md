<p align="center">
    <a href="#"><img src="https://raw.githubusercontent.com/Deaadman/UniversalTweaks/release/Images/PatchNotesHeading.png"></a>

---

Welcome to the patch notes for this modification. This document provides a detailed insight into the history of every update made to this project. These patch notes keep you informed about the latest additions, bug fixes, and enhancements with each release. Along with current information, it also brings you insights into upcoming possible ideas.

So please note that the upcoming ideas provided within these patch notes aren't final and are subject to change. They should not be interpreted as a guarantee of implementation, and production may be halted at any time due to reasons such as life and loss of interest.

| Versions: |
| - |
| [vX.X.X](#vxxx) |
| [v1.2.0 - ???](#v120---) |
| [v1.1.1](#v111) |
| [v1.1.0 - Ton of Tweaks Update](#v110---ton-of-tweaks-update) |
| [v1.0.0 - Initial Launch](#v100---initial-launch) |

---

## vX.X.X:

>**Note:** A bundle of ideas, with no guarantee of implementation.

- Flashlight Tweaks
	- Prevent `High` state if there isn't an aurora (may balance things)
	- Figure out why the `Intense` audio won't play without an aurora.
	- Allow a small chance of wolves to be scared by the `High` state flashlight without an aurora (only at night).
<br></br>
- First Person Handedness - Suggested by [**Romain**](https://github.com/RomainDeschampsFR).
	- Add an option to switch between left and right hand.
	- Allow players to change this using `ModSettings`.
	- Fix animation tracking points that break when switched to the left hand.
<br></br>
- Temperature Rising Debuff?
	- Add new thresholds if the temperature is too hot.
	- Then decline the player's health if they are overheating for too long.
	- Display this by overlapping the temperature circle with a red circle.
<br></br>
- UI Tweaks
	- Remove the Wintermute label in `Panel_MainMenu` if Wintermute isn't installed.
	- Possibly add a menu to display metrics, which may include:
		- FPS
		- CPU Usage and Temp
		- GPU Usage and Temp
	- Add labels for equippable items in `Panel_HUD` which displayes the current item in hand. (Like Fortnite).
	- Remove the spray paint option from the radial menu if there is no spray paint can in your inventory.
<br></br>
- Programming
	- Add more `null` checks.
		- Will help prevent errors.
		- Allow the mod to run more smoothly if an error is encountered.
<br></br>
- Mod Integration
	- Integrate Disable Breath Effects mod with this one.
	- Integrate [**TLD_NonPotableToiletWater**](https://github.com/Ezinw/TLD_NonPotableToiletWater/releases) mod with this one, ask for permission first.
	- ModSettings support
		- Add settings for players to change, such as the decay rate for the snow shelters.
<br></br>
- Multicoloured items?
	- Flares
	- Spray Paint Cans

---

## v1.2.0 - ???:

> **Upcoming Release...**

### Highlights / Key Changes:
- Flashlights no longer flicker if no aurora is active.
- Flashlights no longer spawn with 100% charge, it's now completely random.

### Added:
- Added the following harmony patches to the `FlashlightTweaks.cs` script.
	- `LightRandomIntensity.Update`
		- This patch checks to see if an aurora is currently active, if it isn't it stops the original script from running.
	- `FlashlightItem.Awake`
		- This patch utilises `UnityEngine.Random.Range(0f, 1f);` to set a random float to `m_CurrentBatteryCharge`.

### Changed / Updated:
- Updated the following `private` classes to `static private`.
	- In the `FlashlightTweaks` script.
		- `FlashlightKeepBatteryCharge` class.
		- `FlashlightFunctionality` class.
		- `FlashlightBatteryDrain` class.
	- In the `DecalTweaks` script.
		- `RemoveSprayPaintRestrictions` class.
	- In the `GunTweaks` script.
		- `RevolverMovementUnblocked` class.
		- `RevolverLimitedMobilityUIDisable` class.
	- In the `SnowShelterTweaks` script.
		- `ShowShelterDecayRate` class.
	- In the `UITweaks` script.
		- `FireSpriteFix` class.
- Updated all the scripts namespaces that are in the `Tweaks` folder to `namespace UniversalTweaks.Tweaks;` from `namespace UniversalTweaks;`.

---

## v1.1.1:

> Released on the **25th of October 2023**.

### Highlights / Key Changes:
- Fixed issue of `SnareTweaks` disabling all other equip prompts.

### Changed / Updated:
- Changed the `SnareItemInspectEquipFunctionality` harmony patch from a `Prefix` method to a `Postfix`.
	- Should help future-proof the code while also eliminating any potential issues.
<br></br>
- Updated the `SnareItemInspectEquipPrompt` harmony patch to include an `if` statement to check if the inspected item is a `SnareItem`.

### Fixed:
- Fixed an issue where the `SnareItemInspectEquipPrompt` harmony patch was disabling all other equip prompts.
	- For example, 'press space to drink' and 'press space to skip time'.

---

## v1.1.0 - Ton of Tweaks Update:

> Released on the **24th of October 2023**.

### Highlights / Key Changes:
- Snares now have an option to reset them from the inspect menu if a bunny was caught - Suggested by **Mentat**.
- Aiming with a revolver no longer requires you to be stationary - Suggested by [**Romain**](https://github.com/RomainDeschampsFR).
- Decals (spray paint) now have no restrictions on how close they can be placed to one another - Suggested by **FarcryBliss**.
- Removed `Headache` debuff from Peach and Rose Hip Pies - Suggested by **Valerie**.
- Reduced how quickly snow shelters decay per day, from `100` to `50` HP - Suggested by **StrayCat**.
- Fixed a small `UISprite` misalignment on the `FeedFire` panel. 
- Now requires `LocalizationUtilities` as a dependent mod.

### Added:
- Added a `Tweaks` folder.
	- This folder holds the `FoodTweaks.cs`, `SnowShelterTweak.cs`, `UITweaks.cs`, `DecalTweaks.cs`, `SnareTweaks` and `GunTweaks.cs` scripts.
<br></br>
- Added a `FoodTweaks.cs` script.
- Added two methods `PieItems()` and `RemoveHeadacheDebuffFromItems()`.
	- These handle getting the items, and removing the debuff.
- Added the `OnSceneWasInitialized()` method to `Main.cs`.
	- This calls the `PieItems()` method, once the method is called - it isn't called again.
<br></br>
- Added a `SnowShelterTweaks.cs` script.
- Added a harmony patch `SnowShelterManager.InstantiateSnowShelter()`.
	- This targets every time a new snow shelter is made, then `__result.m_DailyDecayHP` changes from `100` to `50`.
<br></br>
- Added a `UITweaks.cs` script.
- Added a harmony patch `Panel_FeedFire.Initialize()`.
	- This targets when the panel is built, then changes the `localPosition` and `localScale` of the `m_Sprite_FireFill` UISprite.
<br></br>
- Added a `DecalTweaks.cs` script.
- Added a harmony patch `DynamicDecalsManager.Start()`.
	- This targets the `m_DecalOverlapLeniencyPercent` field and adjusts it from `20%` to `100%`.
	- This means that decals now have no restrictions on how close they can be placed to one another.
<br></br>
- Added a `SnareTweaks.cs` script.
- Added two harmony patches `PlayerManager.InitLabelsForGear()` and `PlayerManager.UpdateInspectGear()`.
	- `InitLabelsForGear()` adds the `Equip` action button for the snare when the state is set to `WithRabbit`.
	- `UpdateInspectGear()` is the function that allows the snare to be set to `Set` from the inspect menu.
<br></br>
- Added a `Localization.json` file.
- Added the `LoadLocalizations()` method to be called in the `OnInitializeMelon()` method.
	- This handles all the different languages for the `GAMEPLAY_SetSnare` localization.
	- Universal Tweaks now requires LocalizationUtilities as a dependent mod.
<br></br>
- Added a `GunTweaks.cs` script.
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
- Updated all the `namespace UniversalTweaks{}` to `namespace UniversalTweaks;` - this is the newer C# 10.0 Syntax.

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
	- `InitLabelsForGear()` adds the `Equip` action button