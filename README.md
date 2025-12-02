# Breakpoint Conflict Tracker

A Windows Forms application for tracking mod conflicts in the game Breakpoint.

## Features
- Track conflicts between mods and vanilla game items
- Organize items by category (Facial Paint, Head Protection, Gloves, etc.)
- Add descriptions for each conflict
- Simple and intuitive interface

## Categories
- Facial Paint
- Head Protection
- Headset
- Gloves
- Facemask
- Pants (100+ items)
- NVG
- Shoes
- Camo
- Vests


## Installation
1. Download the standalone executable from the releases page
2. Run the executable directly (no installation required)

## Development
This application is built with C# and Windows Forms using .NET 6.

To build the project:
```bash
dotnet build
```

To run the project:
```bash
dotnet run
```

To create a standalone executable:
```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## Scripts
This repository includes several helper scripts to make development and deployment easier:

- `build-and-publish.bat` - Builds and publishes the standalone executable
- `create-release.bat` - Packages the executable and documentation into a release folder
- `setup-github-repo.bat` - Provides instructions for setting up a GitHub repository

## License
This project is licensed under the MIT License.
