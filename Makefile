.PHONY: build
build: bin/Debug/net5.0/osx-x64/cscat

.PHONY: build-release
build-release: bin/Release/net5.0/osx-x64/cscat

bin/Debug/net5.0/osx-x64/cscat: Program.cs
	dotnet build -c Debug -r osx-x64 -p:PublishSingleFile=true --nologo

bin/Release/net5.0/osx-x64/cscat: Program.cs
	dotnet build -c Release -r osx-x64 -p:PublishSingleFile=true --nologo

.PHONY: lint
lint:
	PATH="$$PATH:$$HOME/.dotnet/tools" dotnet format
