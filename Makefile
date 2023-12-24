publish:
	@dotnet publish NextDoor -c Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true --verbosity normal -p:TargetPlatform=osx-arm64 --runtime osx-arm64 --output ./bin/NextDoor.macOS.arm64
	@cp -r ./Assets ./bin/NextDoor.macOS.arm64
	@rm ./bin/NextDoor.macOS.arm64/NextDoor.pdb
	@zip -r "./bin/NextDoor.macOS.arm64.Release.zip" ./bin/NextDoor.macOS.arm64

	@dotnet publish NextDoor -c Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true --verbosity normal -p:TargetPlatform=win10-x64 --runtime win10-x64 --output ./bin/NextDoor.win10.x64
	@cp -r ./Assets ./bin/NextDoor.win10.x64
	@rm ./bin/NextDoor.win10.x64/NextDoor.pdb
	@zip -r "./bin/NextDoor.win10.x64.Release.zip" ./bin/NextDoor.win10.x64

	@dotnet publish NextDoor -c Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true --verbosity normal -p:TargetPlatform=linux-x64 --runtime linux-x64 --output ./bin/NextDoor.linux.x64
	@cp -r ./Assets ./bin/NextDoor.linux.x64
	@rm ./bin/NextDoor.linux.x64/NextDoor.pdb
	@zip -r "./bin/NextDoor.linux.x64.Release.zip" ./bin/NextDoor.linux.x64

run:
	@dotnet run --project NextDoor