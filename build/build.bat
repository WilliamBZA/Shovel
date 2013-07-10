@echo off

echo Cleaning any binary artifacts...
if exist bin\. rmdir /S /Q .\bin
if exist bin-build-with-shovel\. rmdir /S /Q .\bin-build-with-shovel

echo Bootstrapping Shovel binaries...
msbuild /nologo /verbosity:quiet /target:Rebuild /property:OutDir=..\..\build\bin ..\src\Shovel\Shovel.csproj

echo Rebuilding Shovel with itself... Pretty nifty huh?
echo Note: ScriptCS must be available in the path for this to work.
rem scriptcs build.csx -loglevel Error -- -tasks:Build,Package
scriptcs build.csx -loglevel Error -- -tasks:Build

echo Done building Shovel with itself.