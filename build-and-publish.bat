@echo off
echo Building and Publishing Breakpoint Conflict Tracker
echo ===============================================
echo.

echo Restoring packages...
dotnet restore
if %errorlevel% neq 0 (
    echo Error restoring packages
    pause
    exit /b
)

echo.
echo Building project...
dotnet build --configuration Release
if %errorlevel% neq 0 (
    echo Error building project
    pause
    exit /b
)

echo.
echo Publishing standalone executable...
dotnet publish --configuration Release --runtime win-x64 --self-contained true -p:PublishSingleFile=true
if %errorlevel% neq 0 (
    echo Error publishing project
    pause
    exit /b
)

echo.
echo Build and publish completed successfully!
echo Standalone executable is located at:
echo bin\Release\net6.0-windows\win-x64\publish\BreakpointConflictTracker.exe
echo.
pause
