# DANGER

- Changing the Wheel Lock CAN CAUSE HARM when changing to a smaller wheel lock, since the wheel will attempt to center!

`USE WITH CAUTION!`

# Info

- Created to set `SIMAGIC` wheels to the wheellock of a specific car, specifically for Assetto Corsa Rally

# Building

- Requires the `dotnet build` to compile
- Requires `SimHub` to build (change the csproj `SIMHUB_INSTALL_PATH` if needed)
- Might need `NDP48-DevPack-ENU.exe` (not sure)

# Installation

- Kill `SimHub`
- Copy the DLL to the root folder of `SimHub` (`SIMHUB_INSTALL_PATH`)
- Start `SimHub`, it will ask to enable this plugin
- Go to the settings in `Additional Plugins` to modify the wheel lock per car
	- Car identifiers come from SimHub property `GameData.CarId`

# Inner working

- The plugin reads the configruation to get a list of cars/locks
- When the `GameData.CarId` changes to a car in the defined list, it will send the new wheel lock to `SIMAGIC`
	- This will use the (slightly dangerous, CORS?!) localhost JSONRPC to send a new setting for the wheel lock