#!/bin/bash
set -e

SQLCMD="/opt/mssql-tools18/bin/sqlcmd"

echo "🚀 Entrypoint SQL iniciado"

# inicia o SQL Server em background
/opt/mssql/bin/sqlservr &

echo "⏳ Aguardando SQL Server aceitar conexões..."
until $SQLCMD -S localhost -U sa -P "$SA_PASSWORD" -C -Q "SELECT 1" &> /dev/null
do
  sleep 3
done

echo "✅ SQL disponível — executando init-db.sql"
$SQLCMD -S localhost -U sa -P "$SA_PASSWORD" -C -i /usr/src/app/init-db.sql

echo "🎉 Init-db.sql executado com sucesso"

# traz o sqlservr para foreground
wait
