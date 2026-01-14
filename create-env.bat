@echo off
REM Define o nome do arquivo .env a ser criado ou sobrescrito

SET ENV_FILE=.env

REM Apaga o arquivo .env existente, se houver
IF EXIST %ENV_FILE% DEL %ENV_FILE%

REM Adiciona variáveis de ambiente ao arquivo .env no formato CHAVE=VALOR
REM O uso de% >> redireciona a saída para o final do arquivo, criando-o se não existir
	echo RabbitMQ__Host=%RabbitMQ__Host% >> %ENV_FILE%
	echo RabbitMQ__Port=%RabbitMQ__Port% >> %ENV_FILE%
	echo RabbitMQ__VHost=%RabbitMQ__VHost% >> %ENV_FILE%
	echo RabbitMQ__Exchange=%RabbitMQ__Exchange% >> %ENV_FILE%
	echo RabbitMQ__ExchangeType=%RabbitMQ__ExchangeType% >> %ENV_FILE%
	echo RabbitMQ__Queue=%RabbitMQ__Queue% >> %ENV_FILE%
	echo RabbitMQ__RoutingKey=%RabbitMQ__RoutingKey% >> %ENV_FILE%
	echo RabbitMQ__User=%RabbitMQ__User% >> %ENV_FILE%
	echo RabbitMQ__Pass=%RabbitMQ__Pass% >> %ENV_FILE%
    echo ConnectionStrings__lancamentosDB=%ConnectionStrings__lancamentosDB% >> %ENV_FILE%
	echo SA_PASSWORD=%SA_PASSWORD% >> %ENV_FILE%
echo Arquivo %ENV_FILE% criado com sucesso.
pause
