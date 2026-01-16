@echo off
echo Configurando variáveis de ambiente...

setx SA_PASSWORD "StrongPass!123"
setx RABBITMQ_USER "admin"
setx RABBITMQ_PASS "admin"

setx RabbitMQ__Host "localhost" 
setx RabbitMQ__Port "5672" 
setx RabbitMQ__VirtualHost "/"
setx RabbitMQ__Exchange "lancamentos.exchange"
setx RabbitMQ__ExchangeType "topic"
setx RabbitMQ__Queue "lancamentos.queue"
setx RabbitMQ__RoutingKey "lancamentos.*"
setx RabbitMQ__User "admin"
setx RabbitMQ__Password "admin"

setx SQL_CONNECTION "Server=localhost;Database=LancamentosDb;User Id=sa;Password=StrongPass!123;TrustServerCertificate=True"

setx ConnectionStrings__lancamentosDB "Server=localhost;Database=LancamentosDB;User Id=sa;Password=StrongPass!123;TrustServerCertificate=True"
setx ConnectionStrings__consolidadoDB "Server=localhost;Database=ConsolidadoDB;User Id=sa;Password=StrongPass!123;TrustServerCertificate=True"
echo Variáveis de ambiente configuradas com sucesso.

exit