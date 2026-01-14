@echo off
echo Configurando variáveis de ambiente...

setx SA_PASSWORD "StrongPass!123"
setx RABBITMQ_USER "admin"
setx RABBITMQ_PASS "admin"

setx SQL_CONNECTION "Server=sqlserver;Database=LancamentosDb;User Id=sa;Password=StrongPass!123;TrustServerCertificate=True"

echo.
echo Variáveis configuradas com sucesso.
echo Feche e reabra o terminal antes de executar o docker-compose.
pause
