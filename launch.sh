dotnet publish NextDoor -c Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true --output ./bin/NextDoor.Debug/
cp -r ./Assets ./bin/NextDoor.Debug
./bin/NextDoor.Debug/NextDoor