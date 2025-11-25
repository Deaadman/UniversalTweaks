# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres [Semantic Versioning](https://semver.org/).

## [1.4.6] - 2025-11-25

### Deprecated

- Snare tweaks for now as newer versions of The Long Dark have broken it, will be re-enabled in a future release.

### Fixed

- Spacebar actions no longer being visible during inspect mode ([#36](https://github.com/Deaadman/UniversalTweaks/issues/36)).

## [1.4.5] - 2025-11-21

### Added

- 'Lily Pancakes' to the list of items in which the headache debuff can be removed ([#34](https://github.com/Deaadman/UniversalTweaks/issues/34)).

### Changed

- Updated for the latest version of The Long Dark - v2.44 ([#31](https://github.com/Deaadman/UniversalTweaks/issues/31)).
- Some code restructuring.

### Fixed

- The 'Extended Functionality' setting for flashlights no longer deterring aurora wolves ([#30](https://github.com/Deaadman/UniversalTweaks/issues/30))

## [1.4.4] - 2024-12-17

### Changed

- Updated for the latest version of The Long Dark - v2.36.

### Fixed

- Fixed an issue with Rock Caches throwing errors when placing. _(To actually place Rock Caches indoors, please install PlaceAnywhere on our [Discord Server](https://discord.gg/2mnXAZfGXQ) under #untested-mod-releases)_

## [1.4.3] - 2024-08-11

### Changed

- Updated for the latest version of The Long Dark - v2.32.

### Removed

- Removed the Campfire UI Tweaks as Hinterland seems to have removed them, themselves.

### Fixed

- Fixed an issue where enabling Cheat Tweaks would hide all the Container Tweak options.
- Fixed an some wording / typo issues within the settings menu.
- Fixed an issue with the fatigue penalty setting not applying to both of the stews.

## [1.4.2] - 2024-06-29

### Added

- **UI Tweaks**
	- There is now an option to disable the 'Campfire Lives' at the bottom of the screen.
- **Miscellaneous Tweaks**
	- Merged the **[Carry Weight](https://github.com/Xpazeman/tld-carry-weight-mod)** mod from **[Xpazeman](https://github.com/Xpazeman)** into Universal Tweaks with his permission.
	- Merged the **[Container Tweaks](https://github.com/GruffCassquatch/ContainerTweaks)** mod from **[Cass](https://github.com/GruffCassquatch)** into Universal Tweaks with her permission.
	- Merged the **[Limitless Container Space](https://github.com/Atlas-Lumi/LimitlessContainerSpace)** mod from **[Emma](https://github.com/Atlas-Lumi)** into Universal Tweaks with her permission.
	- Added some format to display the data types with Universal Tweaks's mod settings, e.g. KG.

### Changed

- Updated for the latest version of The Long Dark - v2.31.

### Fixed

- Fixed an issue with the broken weight tweak for the Old Man's Bear Dressing.
- Fixed an object reference issue with the method `ModifyFlashFlashlightBeamColour()`.

## [1.4.1] - 2024-06-18

### Removed

- Removed the fire feeding tweak that hides all research books from the fuel list when starting / adding onto an existing fire.

## [1.4.0] - 2024-06-17

### Added

- **Travois Tweaks**
	- Override all travois restrictions when travelling near stairs, hard-to-get places, etc - Suggested by **[TonisGaming](https://github.com/TonisGaming)**.
	- Interacting with things while holding the travois, allowing to go indoors with them.
- **Respirator Tweaks**
	- The duration of respirator's canister's are now configurable - Suggested by **ProxyXVl/AgentOfChaos**.
- **Noisemaker Tweaks**
	- The fuse timer of the noisemaker can now be adjusted - Suggested by **FarcryFromBliss**.
	- The range at which the player can throw the noisemaker can also be adjusted - Suggested by **FarcryFromBliss**.
- **Firestarting Tweaks**
	- Skill books will no longer show up in fuel tabs unless it has been completely researched - Suggested by **DarkUncle**.
- **Food Tweaks**
	- All insulated flasks heat retention can now be customised, making them last longer or shorter - Suggested by **[LettereUniche](https://github.com/LettereUniche)**.
	- Added an option to reduce the fatigue loss on the Thomson & Ranger stew's - Suggested by **natural blue**.
- **Miscellaneous Tweaks**
	- Items drops rotations can now be randomised, instead of pointing the same direction every time something is dropped - Suggested by **[Fuar](https://github.com/Fuar11)**.
	- The old man's beard dressings weight can now be relative to the lichens weight - Suggested by **DarkUncle**.
	- Merged the [EnableFeatProgressInCustomMode](https://github.com/RomainDeschampsFR/EnableFeatProgressInCustomModeLegacy) mod from **[Romain](https://github.com/RomainDeschampsFR)** into Universal Tweaks with his permission.

### Changed

- **Food Tweaks**
	- Included the [Camber Flight Porridge](https://thelongdark.fandom.com/wiki/Camber_Flight_Porridge) to the list of foods that no longer give the headache debuff - Suggested by **Valerie**.

## [1.3.0] - 2023-12-10

### Added

- **Flashlight Tweaks**
	- Flashlights now stay lit when dropped if no aurora is active.
	- Added an option so the high state can now be disabled if no aurora is active.
	- Added an infinite battery option - Suggested by **FarcryFromBliss**.
	- Added options to change colors of the flashlight beam, both normal and miner's. 
	- Added options to adjust the low and high beam durations and also the recharge times - Suggested by **V3n0m**.
	- Added an option for flashlight flickering to only happen during an aurora.
- **Rock Cache Tweaks**
	- Players can now build them indoors - Suggested by **Data-0**.
	- Added an option to adjust max per region.
	- Added an option to adjust minimum distance between each cache.
- **Spray Paint Tweaks**
	- Added an option so decals can glow in the dark - Suggested by **V3n0m**.
- **Travois Tweaks**
	- Added three different decay options.
	- Added an option to change how quickly you can turn angles.
	- Added an option to change the max slope angle degree.

### Changed

- Updated for the latest version of The Long Dark - v2.25.
- Changed all the logic for the breath effects tweak, it has much been simplified and more lightweight.
- Changed the headache debuff logic slightly.
- Changed the readability of some settings as they weren't quite clear.
- Changed the texture swapping method, it is now more generic.

### Removed

- Deprecated the left-handed animations tweak.

## [1.2.1] - 2023-11-19

### Added

- Added support for the Turkish language, thanks to [Elderly-Emre](https://github.com/Elderly-Emre) for submitting a pull request.
- Added a workaround option within the settings for those who also use relentless night.

### Changed

- Changed the structure for the settings of this mod for [ModSettings](https://github.com/DigitalzombieTLD/ModSettings). Now easier to understand and navigate.

### Fixed

- Fixed all toilets not changing to Non-Potable when selected in settings.
- Fixed flashlights draining twice as quick during an aurora.
- Fixed decal leniency option not working as expected.

## [1.2.0] - 2023-11-11

### Added

- Added compatibility with [**ModSettings**](https://github.com/DigitalzombieTLD/ModSettings), and is now a requirement as this mod heavily depends on it due to the amount of customisation.
- Added an option to switch the original blue MRE texture with a brown texture - Suggested by **Bisexual Bastard** and textures done by [**Jods**](https://github.com/Jods-Its) and **Kaiusername**.
- Added the below mods within this mod:
	- [**Disable Breath Effects**](https://github.com/Thekillergreece/DisableBreathEffect) - by [**Thekillergreece**](https://github.com/Thekillergreece) and [**zeobviouslyfakeacc**](https://github.com/zeobviouslyfakeacc) 
	- [**TLD_NonPotableToiletWater**](https://github.com/Ezinw/TLD_NonPotableToiletWater) - by [**Ezinw**](https://github.com/Ezinw).
- Added an option so both the `Wintermute` and `Expansion` menu items from the main menu don't show if they aren't installed.
- Added a left-handed option for animations - Suggested by [**Romain**](https://github.com/RomainDeschampsFR).
- Added an option so flashlights no longer flicker if no aurora is active.
- Added an option so flashlights can now no longer spawn with 100% charge, it's now completely random.
- Added an option so the users crosshair can now always show - Suggested by **wheelchaircutie**.

### Changed

- Changed the spray paint can within the radial menu, so it is now greyed out if no spray paint can is found in your inventory.
- Changed the entire structure of this project and how it was laid out.
- Changed the logic for removing the headache debuff from items.

## [1.1.1] - 2023-10-25

### Fixed

- Fixed the issue of the snare tweaks disabling all other equip prompts.

## [1.1.0] - 2023-10-24

### Added

- Added compatibility with [**LocalizationUtilities**](https://github.com/dommrogers/LocalizationUtilities), and is now a requirement as a dependent mod.
- Added an option to snares as you can now reset them from the inspect menu if a bunny was caught - Suggested by **Mentat**.
- Added a feature to no longer requires you to be stationary when aiming with a revolver - Suggested by [**Romain**](https://github.com/RomainDeschampsFR).
- Added a feature so decals no restrictions on how close they can be placed to one another - Suggested by **FarcryBliss**.
- Added a feature to remove the headache debuff from peach and rose hip pies - Suggested by **Valerie**.

### Changed

- Changed how quickly snow shelters decay per day, from `100` to `50` HP - Suggested by **StrayCat**.
- Changed the namespace syntax to the newer C# 10.

### Fixed

- Fixed a small misalignment in the feed fire panel with a sprite. 

## [1.0.0] - 2023-10-14

### Added

- The first version is released and published as 1.0.0.

[1.4.6]: https://github.com/Deaadman/UniversalTweaks/compare/v1.4.5...v1.4.6
[1.4.5]: https://github.com/Deaadman/UniversalTweaks/compare/v1.4.4...v1.4.5
[1.4.4]: https://github.com/Deaadman/UniversalTweaks/compare/v1.4.3...v1.4.4
[1.4.3]: https://github.com/Deaadman/UniversalTweaks/compare/v1.4.2...v1.4.3
[1.4.2]: https://github.com/Deaadman/UniversalTweaks/compare/v1.4.1...v1.4.2
[1.4.1]: https://github.com/Deaadman/UniversalTweaks/compare/v1.4.0...v1.4.1
[1.4.0]: https://github.com/Deaadman/UniversalTweaks/compare/v1.3.0...v1.4.0
[1.3.0]: https://github.com/Deaadman/UniversalTweaks/compare/v1.2.1...v1.3.0
[1.2.1]: https://github.com/Deaadman/UniversalTweaks/compare/v1.2.0...v1.2.1
[1.2.0]: https://github.com/Deaadman/UniversalTweaks/compare/v1.1.1...v1.2.0
[1.1.1]: https://github.com/Deaadman/UniversalTweaks/compare/v1.1.0...v1.1.1
[1.1.0]: https://github.com/Deaadman/UniversalTweaks/compare/v1.0.0...v1.1.0
[1.0.0]: https://github.com/Deaadman/UniversalTweaks/tree/v1.0.0