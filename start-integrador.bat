echo Iniciando a Compilação da Solução Integrador.sln...
dotnet build src/Integrador.sln

cd src/Integrador/Integrador.Worker/bin/Debug/net8.0

Integrador.Worker.exe
