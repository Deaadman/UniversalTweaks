<p align="center">
    <a href="#"><img src="https://raw.githubusercontent.com/Deaadman/UniversalTweaks/release/Images/PatchNotesHeading.png"></a>

---

Welcome to the patch notes for this modification. This document provides a detailed insight into the history of every update made to this project. These patch notes keep you informed about the latest additions, bug fixes, and enhancements with each release. Along with current information, it also brings you insights into upcoming possible ideas.

So please note that the upcoming ideas provided within these patch notes aren't final and are subject to change. They should not be interpreted as a guarantee of implementation, and production may be halted at any time due to reasons such as life and loss of interest.

| Versions: |
| - |
| [vX.X.X](#vxxx) |
| [v1.2.0 - Tailored Tweaks Update](#v120---tailored-tweaks-update) |
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
	- Fix animation tracking points that break when switched to the left hand.
<br></br>
- Temperature Rising Debuff?
	- Add new thresholds if the temperature is too hot.
	- Then decline the player's health if they are overheating for too long.
	- Display this by overlapping the temperature circle with a red circle.
<br></br>
- UI Tweaks
	- Possibly add a menu to display metrics, which may include:
		- FPS
		- CPU Usage and Temp
		- GPU Usage and Temp
	- Add labels for equippable items in `Panel_HUD` which displays the current item in hand. (Like Fortnite).
	- Remove the spray paint option from the radial menu if there is no spray paint can in your inventory.
<br></br>
- Multicoloured items?
	- Flares
	- Spray Paint Cans

---

## v1.2.0 - Tailored Tweaks Update:

> **Upcoming Release...**

### Highlights / Key Changes:
- Integrated the mods:
	- [**Disable Breath Effects**](https://github.com/Thekillergreece/DisableBreathEffect) - by [**Thekillergreece**](https://github.com/Thekillergreece) and [**zeobviouslyfakeacc**](https://github.com/zeobviouslyfakeacc) 
	- [**TLD_NonPotableToiletWater**](https://github.com/Ezinw/TLD_NonPotableToiletWater) - by [**Ezinw**](https://github.com/Ezinw).
- Now requires [**ModSettings**](https://github.com/DigitalzombieTLD/ModSettings) as a dependent mod with massive amounts of customization.
- Added a left-handed option for animations - Suggested by [**Romain**](https://github.com/RomainDeschampsFR). `EXPERIMENTAL!`
- Swapped the original MRE texture with a new Brown MRE - Suggested by **Bisexual Bastard** and textures done by [**Jods**](https://github.com/Jods-Its) and **Kaiusername**.
- Removed both `Wintermute` and `Expansion` menu items from the Main Menu if they aren't installed.
- Flashlights no longer flicker if no aurora is active.
- Flashlights no longer spawn with 100% charge, it's now completely random.
- Crosshair can now always show - Suggested by **wheelchaircutie**.

### Added:
- Added the following harmony patches to the `TweaksFlashlight.cs` script.
	- `LightRandomIntensity.Update`
		- This patch checks to see if an aurora is currently active, if it isn't it stops the original script from running.
	- `FlashlightItem.Awake`
		- This patch utilises `UnityEngine.Random.Range(0f, 1f);` to set a random float to `m_CurrentBatteryCharge`.
<br></br>
- Added the following harmony patches to the `TweaksUserInterface.cs` script.
	- `Panel_MainMenu.Initialize`
		- This patch checks to see whether the user has `Wintermute` or `TFTFT` installed, if not it calls a custom `RemoveMainMenuItem()` method.
		- This method iterates through all menu items, and finds the types specified. Once found, it removes them and refreshes the menu.
	- `Panel_HUD.Initialize`
		- This calls adds the `DisplayMetrics` class as a component to the `Panel_HUD` gameobject.
		- Then calls the `Initialize` method from the `DisplayMetrics` class to setup all the gameobjects and labels.
	- `HUDManager.UpdateCrosshair`
		- This patch sets the alpha of the `Crosshair` sprite to `1f` depending on the option chosen in [**ModSettings**](https://github.com/DigitalzombieTLD/ModSettings).
<br></br>
- Added a `TweaksWater.cs` script.
	- This contains a `WaterSource.Deserialize` harmony patch which sets the `m_CurrentLiquidQuality` to `NonPotable` on any WaterSource component.
	- This feature comes from the mod [**TLD_NonPotableToiletWater**](https://github.com/Ezinw/TLD_NonPotableToiletWater) by [**Ezinw**](https://github.com/Ezinw) - but was reprogrammed for more efficiency.
<br></br>
- Added a `TweaksBreath.cs` script.
	- This contains a `Breath.PlayBreathEffect` harmony patch which grabs the original `m_ColdBreathTempThreshold`, `m_VeryColdBreathTempThreshold` and `m_FreezingBreathTempThreshold` values before modifying them.
	- This allows for players to enable and disable the effect at will through [**ModSettings**](https://github.com/DigitalzombieTLD/ModSettings).
<br></br>
- Added a `AssetBundleLoader.cs` file
	- Contains an easy method to load any assetbundle
<br></br>
- Added a `TextureSwapper.cs` script.
	- This script loads the `UniversalTweaksAssetBundle` assetbundle, then loads the `2DTextures` within and stores them in a dictionary
	- Then it finds a `MeshRenderer` on all meshes that are childs of the `GEAR_MRE` prefab and swaps out the original one with the custom one loaded in the dictionary.
	- Something similar happens with the `ico` expect it's through a harmony patch.
<br></br>
- Added a `FirstPersonHandedness.cs` script.
	- Currently it switches the scale of `x` of the rig to either `1` or `-1` based on which setting is chosen.
	- While it sort of works, some animations doesn't work properly so it's marked as `experimental`.
<br></br>
- Added a `Settings.cs` script.
	- Lots of settings were added in here for certain tweaks.

### Changed / Updated:
- Changed the entire solution structure of this mod to this:
	- 📁 **Properties**
		- 📄 `AssemblyInfo.cs`
		- 📄 `BuildInfo.cs`
		- 📄 `Settings.cs`
	- 📁 **Resources**
		- 📄 `Localization.json`
		- 📄 `UniversalTweaksAssetBundle`
	- 📁 **Utilities**
		- 📄 `AssetBundleLoader.cs`
		- 📄 `Logging.cs`
	- 📄 `FirstPersonHandedness.cs`
	- 📄 `MelonModImplementation.cs`
	- 📄 `TextureSwapper.cs`
	- 📄 `TweaksBreath.cs`
	- 📄 `TweaksDecals.cs`
	- 📄 `TweaksFlashlight.cs`
	- 📄 `TweaksFood.cs`
	- 📄 `TweaksGuns.cs`
	- 📄 `TweaksSnare.cs`
	- 📄 `TweaksSnowShelter.cs`
	- 📄 `TweaksUserInterface.cs`
	- 📄 `TweaksWater.cs`
- As it was previously this (Version v1.1.1):
	- 📁 **Data**
		- 📄 `Localization.json`
	- 📁 **Miscellaneous**
		- 📄 `Logging.cs`
	- 📁 **Properties**
		- 📄 `AssemblyInfo.cs`
	- 📁 **Tweaks**
		- 📄 `DecalTweaks.cs`
		- 📄 `FlashlightTweaks.cs`
		- 📄 `FoodTweaks.cs`
		- 📄 `GunTweaks.cs`
		- 📄 `SnareTweaks.cs`
		- 📄 `SnowShelterTweaks.cs`
		- 📄 `UITweaks.cs`
	- 📄 `BuildInfo.cs`
	- 📄 `Main.cs`
<br></br>
- Updated the following `private` classes to `static private`.
	- In the `TweaksFlashlight` script.
		- `FlashlightKeepBatteryCharge` class.
		- `FlashlightFunctionality` class.
		- `FlashlightBatteryDrain` class.
	- In the `TweaksDecals` script.
		- `RemoveSprayPaintRestrictions` class.
	- In the `TweaksGuns` script.
		- `RevolverMovementUnblocked` class.
		- `RevolverLimitedMobilityUIDisable` class.
	- In the `TweaksSnowShelter` script.
		- `ShowShelterDecayRate` class.
	- In the `TweaksUserInterface` script.
		- `FireSpriteFix` class.
<br></br>
- Updated the `TweaksFood.cs` script.
	- Instead of two methods which get the `GEAR_` item then pass it to the `RemoveHeadacheDebuffFromItem`, it has now been restructured to just `RemoveHeadacheDebuff` which takes a list of `strings`.
	- These strings get the `GEAR_` item from `GearItem.LoadGearItemPrefab` and destroys any `CausesHeadaccheDebuff` component attached to the prefab.

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
- Now requires [**LocalizationUtilities**](https://github.com/dommrogers/LocalizationUtilities) as a dependent mod.

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