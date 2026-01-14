@echo off
echo Configurando variáveis de ambiente...

setx SA_PASSWORD "StrongPass!123"
setx RABBITMQ_USER "admin"
setx RABBITMQ_PASS "admin"

setx RabbitMQ__Host "rabbitmq" 
setx RabbitMQ__Port "5672" 
setx RabbitMQ__VHost "/"
setx RabbitMQ__Exchange "lancamentos-exchange"
setx RabbitMQ__ExchangeType "topic"
setx RabbitMQ__Queue "lancamentos-queue"
setx RabbitMQ__RoutingKey "lancamentos.*"
setx RabbitMQ__User "admin"
setx RabbitMQ__Pass "admin"

setx SQL_CONNECTION "Server=sqlserver;Database=LancamentosDb;User Id=sa;Password=StrongPass!123;TrustServerCertificate=True"

setx ConnectionStrings__lancamentosDB "Server=sqlserver;Database=LancamentosDB;User Id=sa;Password=StrongPassword!123;TrustServerCertificate=True"




echo.
echo Variáveis configuradas com sucesso.
echo Feche e reabra o terminal antes de executar o docker-compose.

setlocal enabledelayedexpansion

REM Arquivo .env de saída
set ENV_FILE=.env

REM Limpa o .env antigo
if exist %ENV_FILE% del %ENV_FILE%

REM Lista de variáveis obrigatórias
set VARS=RabbitMQ__Host RabbitMQ__Port RabbitMQ__VHost RabbitMQ__Exchange RabbitMQ__ExchangeType RabbitMQ__Queue RabbitMQ__RoutingKey RabbitMQ__User RabbitMQ__Pass ConnectionStrings__lancamentosDB

echo Gerando arquivo %ENV_FILE%...

for %%V in (%VARS%) do (
    call set VALUE=%%%V%%
    if "!VALUE!"=="" (
        echo ERRO: Variavel de ambiente %%V nao encontrada no Windows
        exit /b 1
    )
    echo %%V=!VALUE!>> %ENV_FILE%
)

echo.
echo Arquivo .env gerado com sucesso!
echo.

endlocal

pause
