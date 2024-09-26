## Overview
A car simulation built with Unity/C#, featuring a system for checking car status and displaying information.

## Key Components

### Core Classes
- `EntryPoint`: Initializes and manages checks.
- `CarReader`: Manages the list of checks.
- `DataWriter`: Displays information on screen.
- `CarData`: Stores car data and simulation settings.

### Interfaces and Abstract Classes
- `ICheck`: Interface for all checks.
- `Writer`: Abstract class for check classes.

### Check Classes
All inherit from `Writer` and implement `ICheck`:

1. `CheckActiveGear`: Checks active gear.
2. `CheckEngineStatus`: Checks engine status.
3. `CheckTransmissionMode`: Checks transmission mode.
4. `FindNearestCar`: Searches for the nearest car.
5. `SpeedChecker`: Checks car speed.
   - Converts speed to km/h.
   - Displays rounded value.
6. `RpmChecker`: Checks engine RPM.
   - Reads RPM from `Dashboard.Rpm`.
   - Converts and displays value in r/min.

## Dependencies
- Unity
- TextMeshPro
- Vehicle Physics Pro

## Installation
1. Clone repository
2. Open in Unity
3. Set up `CarData` in the scene

## Usage
- Add `EntryPoint` to the scene
- Configure references in the inspector
- Run the scene

## Extending Functionality
1. Create a class inheriting from `Writer` and implementing `ICheck`
2. Implement `Check()`
3. Add type to `DataType`
4. Add field in `DataWriter`
5. Initialize in `EntryPoint`

## Notes
- Uses Strategy pattern
- Easily extendable architecture
- `maxDetectionDistance` in `CarData` is crucial for `FindNearestCar`
