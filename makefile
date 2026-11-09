PROJECT := Source/Source.csproj

.PHONY: init run test debug release publish-linux publish-windows publish clean distclean reset

init:
	dotnet restore

run:
	dotnet run --project $(PROJECT) -c Debug

test:
	dotnet run --project $(PROJECT) -c Release

debug:
	dotnet build $(PROJECT) -c Debug

release:
	dotnet build $(PROJECT) -c Release

publish-linux:
	dotnet publish $(PROJECT) -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true -o publish/linux-x64

publish-windows:
	dotnet publish $(PROJECT) -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o publish/win-x64

publish: publish-linux publish-windows

clean:
	dotnet clean $(PROJECT) -c Debug
	dotnet clean $(PROJECT) -c Release
	rm -rf publish/**/*

distclean: clean
	rm -rf */bin */obj publish

reset: distclean init
