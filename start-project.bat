start "" cmd /k "setup-env.bat"


echo Iniciando o Teste

echo Finalizando imagens Docker existentes...
docker-compose down -v

echo Compilando imagens Docker existentes...

docker compose build --no-cache


echo Iniciando imagens Docker existentes...

start "" cmd /k "docker compose up -d"

echo compilando os projetos...

echo Iniciando a Compilação da Solução Consolidado.sln...
dotnet build src/Consolidado.sln


echo Iniciando Consolidado...

start "" cmd /k "start-consolidado.bat"

start chrome http://localhost:5176/swagger/index.html



echo Iniciando a Compilação da Solução Lancamentos.sln...
dotnet build src/Lancamentos.sln

echo Iniciando Consolidado...
start "" cmd /k "start-lancamentos.bat"

start chrome http://localhost:5177/swagger/index.html



echo Iniciando a Compilação da Solução Integrador.sln...
dotnet build src/Integrador.sln

start "" cmd /k "start-integrador.bat"