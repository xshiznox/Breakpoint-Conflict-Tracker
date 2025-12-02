@echo off
echo Creating release package for Breakpoint Conflict Tracker
echo ======================================================
echo.

REM Check if publish directory exists
if not exist "bin\Release\net6.0-windows\win-x64\publish\" (
    echo Error: Publish directory not found. Please run the publish command first:
    echo dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
    echo.
    pause
    exit /b
)

REM Create release directory
set release_dir=release
if exist "%release_dir%" (
    rmdir /s /q "%release_dir%"
)
mkdir "%release_dir%"

REM Copy the standalone executable
copy "bin\Release\net6.0-windows\win-x64\publish\BreakpointConflictTracker.exe" "%release_dir%\"

REM Copy other important files
copy "README.md" "%release_dir%\"
copy "LICENSE" "%release_dir%\"

echo Release package created in the '%release_dir%' directory
echo.
echo Contents:
dir "%release_dir%"
echo.
pause
