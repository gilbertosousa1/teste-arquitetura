# 📦 Arquitetura de Integração e Consolidação - Teste Arquitetura

## 🎯 Visão Geral do Projeto

Este repositório descreve uma **arquitetura de microserviços em .NET 8** composta pelos módulos **Lancamentos**, **Integrador** e **Consolidado**, responsáveis pelo fluxo completo de eventos financeiros, integração via mensageria assíncrona e consolidação de dados diários.

A arquitetura foi pensada para ser:
- ✅ **Desacoplada** - Serviços independentes sem dependências diretas
- ✅ **Orientada a Eventos** - Comunicação assíncrona via RabbitMQ
- ✅ **Escalável** - Cada componente pode escalar independentemente
- ✅ **Resiliente** - Tratamento de falhas e reprocessamento de mensagens
- ✅ **Testável** - Separação clara de responsabilidades com testes unitários

**Tecnologias principais**: .NET 8, ASP.NET Core, Entity Framework Core, RabbitMQ, SQL Server, Docker

---

## 🚀 Quick Start

### Pré-requisitos

- ✅ .NET 8.0 SDK
- ✅ Docker & Docker Compose
- ✅ Git
- ✅ PowerShell ou bash

### Instalação Rápida

```bash
# 1. Clone o repositório
git clone <repository-url>
cd teste-arquitetura

# 2. Execute o setup (Windows)
.\setup-env.bat

# 3. Inicie os containers
docker-compose up -d

# 4. Compile a solução
dotnet build

# 5. Execute a solução
dotnet run --project src/Lancamentos/Lancamentos.Api
```

Os serviços estarão disponíveis em:
- 🌐 **Lancamentos.Api**: http://localhost:5000
- 🌐 **Swagger**: http://localhost:5000/swagger
- 🐰 **RabbitMQ**: http://localhost:15672 (guest/guest)
- 🗄️ **SQL Server**: localhost:1433 (sa/seu_password)

---

## 📁 Estrutura do Projeto

```
teste-arquitetura/
│
├── documentacao/              # Diagramas e documentação
│   └── Arquitetura.drawio    # Diagrama da arquitetura
│
├── infra/                    # Configurações de infraestrutura
│   ├── rabitMq/
│   │   └── definitions.json  # Definições de filas e exchanges
│   └── sqlserver/
│       ├── Dockerfile        # Dockerfile do SQL Server
│       ├── entrypoint.sh     # Script de inicialização
│       └── init-db.sql       # Script de criação de BD
│
├── src/                      # Código-fonte dos serviços
│   ├── Consolidado/
│   │   ├── Consolidado.Api/              # API REST
│   │   ├── Consolidado.Application/      # Interface Web (Não Implementada)
│   │   ├── Consolidado.Business/         # Lógica de negócio
│   │   ├── Consolidado.Domain/           # Modelos de domínio
│   │   ├── Consolidado.Infrastructure/   # Persistência (EF Core)
│   │   ├── Consolidado.Tests/            # Testes unitários (Não Implementado)
│   │   └── Consolidado.Util/             # Utilidades
│   │
│   ├── Lancamentos/
│   │   ├── Lancamentos.Api/              # API REST
│   │   ├── Lancamentos.Application/      # Interface Web (Não Implementada)
│   │   ├── Lancamentos.Business/         # Lógica de negócio
│   │   ├── Lancamentos.Domain/           # Modelos de domínio
│   │   ├── Lancamentos.Infrastructure/   # Persistência (EF Core)
│   │   ├── Lancamentos.Tests/            # Testes unitários (Não Implementado)
│   │   └── Lancamentos.Util/             # Utilidades
│   │
│   └── Integrador/
│       ├── Integrador.Worker/            # Worker Service
│       ├── Integrador.Business/          # Lógica de integração
│       ├── Integrador.Domain/            # Modelos de domínio
│       ├── Integrador.Infrastructure/    # Persistência (EF Core)
│       └── Integrador.Util/              # Utilidades
│
├── docker-compose.yml        # Orquestração de containers
├── setup-env.bat            # Script de setup (Windows)
├── LICENSE                  # Licença Apache 2.0
└── README.md               # Este arquivo
```

---

## 🛠️ Instalação Detalhada

### 1. Configurar Variáveis de Ambiente

**Windows (PowerShell):**
```powershell
# Execute o script de setup
.\setup-env.bat
```

---


### 2. Iniciar a Infraestrutura

```bash
# Compilar as Imagens Docker
docker compose build --no-cache

# Iniciar os serviços
docker-compose up -d
```

**Verificar se os containers estão rodando:**
```bash
docker-compose ps
```

**Saída esperada:**
```
NAME           STATUS         PORTS
sqlserver      Up (healthy)   0.0.0.0:1433->1433/tcp
rabbitmq       Up             0.0.0.0:5672->5672/tcp, 0.0.0.0:15672->15672/tcp
lancamentos-api Up (healthy)  0.0.0.0:5000->8080/tcp
```
---

### 3. Compilar os Projetos

```bash
# Ou compilar soluções individualmente
dotnet build src/Consolidado.sln
dotnet build src/Lancamentos.sln
dotnet build src/Integrador.sln
```

---

## 🏃 Executando os Serviços

### Opção 1: Execução das Bats

1- Configurar as Variáveis de ambiente
```bash
setup-env.bat
```
2- Iniciar todas as aplicações automáticas
```bash
start-project.bat
```


### Opção 2: Docker Compose (Recomendado)

```bash
# Compilar as Imagens Docker
docker compose build --no-cache

# Iniciar os serviços
docker-compose up -d
```

Serão iniciados e gerenciados automaticamente o banco de dados SqlServer e RabbitMQ.

### Opção 3: Execução Local (Desenvolvimento)

**Terminal 1 - Consolidado.Api:**
```bash
cd src/Consolidado/Consolidado.Api
dotnet run
# API disponível em: http://localhost:5176
```

**Terminal 2 - Lancamentos.Api:**
```bash
cd src/Lancamentos/Lancamentos.Api
dotnet run
# API disponível em: http://localhost:5177
```

**Terminal 3 - Integrador.Worker:**

<h3 style='color:red'>Caso o Integrador não subir automático devido a erro de conexão com o RabbitMq por favor recompilar e rodar via Debug do Visual Studio</h3>

```bash
cd src/Integrador/Integrador.Worker
dotnet run

# Worker iniciado e aguardando mensagens
```

---

---

## � API REST - Endpoints

### Lancamentos.Api

**Base URL:** `http://localhost:5177/api/Lancamento`

```http
POST   /api/lancamento              # Criar novo lançamento
```

**Exemplo de Request:**
```json
POST /api/lancamentos
Content-Type: application/json

{
  "dataLancamento": "(DateTime) - Data do Lançamento no padrão yyyy-MM-ddTHH:mm:ss",
  "valor": "(Decimal) - Valor do Lançamento",
  "tipo": "(int) Tipo do Lançamento sendo 1 para Crédito e 2 para Débito",
}
```

### Consolidado.Api

**Base URL:** `http://localhost:5176/api/SaldoDiario`

```http
GET    /api/consolidado              # Listar saldos consolidados
```

### Swagger/OpenAPI

Acesse a documentação interativa:
- **Lancamentos**: `http://localhost:5177/swagger/index.html`
- **Consolidado**: `http://localhost:5176/swagger/index.html`

### Postman

**Collection do Postman para testes e documentação:**  \documentacao\Postman\TesteArquitetura.postman_collection.json
---


## 🐰 RabbitMQ - Message Queue

### Acessar o Management UI

- **URL**: `http://localhost:15672`
- **Usuário**: `admin`
- **Senha**: `admin`

### Filas e Exchanges Configurados

Consulte `infra/rabitMq/definitions.json` para ver todas as definições:

**Exchanges:**
- `lancamentos.exchange` - Exchange principal de lançamentos

**Filas:**
- `lancamentos.queue` - Fila de lançamentos

**Bindings:**
```
lancamentos.exchange → lancamentos.queue (routing key: lancamento.criado)
```

### Fluxo de Mensagens

```
Lancamentos.Api 
    ↓ (Salva o Lançamento no Banco LancamentosDB na tabela dbo.Lancamentos e publica o evento)
lancamentos.exchange
    ↓ (roteia para)
lancamentos.queue
    ↓ (consome)
Integrador.Worker
    ↓ (processa)
ConsolidadoDB
    ↓ (Salva o saldo consolidado no Banco ConsolidadoDB na tabela dbo.SaldosDiario)

```

---

## 🗄️ Banco de Dados SQL Server

### Credenciais de Acesso

- **Host**: `localhost,1433`
- **Usuário**: `sa`
- **Senha**: Configurada em `SA_PASSWORD`
- **Caminho do arquivo**: `/var/opt/mssql/` (inside container)

### Bancos de Dados

| Banco | Uso | Tabelas Principais |
|-------|-----|-------------------|
| LancamentosDB | Serviço Lancamentos | dbo.Lancamentos |
| ConsolidadoDB | Serviço Consolidado | dbo.SaldosDiario |

### Conexão via SQL Server Management Studio

```
Server: localhost,1433
Authentication: SQL Server Authentication
Login: sa
Password: <SA_PASSWORD>
Trust server certificate: ✓
```

### Conectar via sqlcmd

```bash
sqlcmd -S localhost,1433 -U sa -P <SA_PASSWORD>
> SELECT name FROM sys.databases
> GO
```

---

## 🐳 Docker e Containerização

### Gerenciar Containers

```bash
# Listar containers em execução
docker ps

# Listar todos os containers
docker ps -a

# Ver logs de um container
docker logs -f sqlserver
docker logs -f rabbitmq
docker logs -f lancamentos-api

# Parar os serviços
docker-compose stop

# Reiniciar os serviços
docker-compose restart

# Remover containers (sem remover dados)
docker-compose down

# Remover containers E volumes (apaga todos os dados)
docker-compose down -v

# Recriar containers
docker-compose up -d --force-recreate
```

### Health Checks

```bash
# Verificar saúde dos serviços
docker-compose ps

# Logs de health checks
docker logs sqlserver | grep health
```

---

## 📊 Arquitetura em Camadas

### Consolidado

```
┌─────────────────────────────────────┐
│  Consolidado.Api                    │ ← HTTP Requests
│  (Controllers, Endpoints)           │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│  Consolidado.Application            │ ← Frontend App (Não implementado, adicionado ao projeto para evolução futura)
│  (WebAp para FrontEnd)              │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│  Consolidado.Business               │ ← Lógica de Negócio
│  (BLL, Rules)                       │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│  Consolidado.Domain                 │ ← Domínio
│  (Entities )                        │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│  Consolidado.Infrastructure         │ ← Persistência
│  (DbContext, Repositories, EF Core) │
└────────────────┬────────────────────┘
                 │
                 ▼
            SQL Server
```

---

## ⚙️ Padrões e Boas Práticas

✅ **Domain-Driven Design (DDD)**
- Entidades ricas em domínio
- Value Objects
- Agregados

✅ **Arquitetura em Camadas**
- Separação clara de responsabilidades
- Dependency Injection
- Inversion of Control (IoC)

✅ **Entity Framework Core**
- Code-First Migrations
- LINQ Queries
- Repository Pattern

✅ **Comunicação Assíncrona**
- Event-Driven Architecture
- Message Queue (RabbitMQ)
- Idempotência de processamento

✅ **Containerização**
- Docker Compose
- Orquestração de serviços
- Health Checks

---

## 🔒 Segurança

⚠️ **Recomendações Importantes:**

1. **Não commit de credenciais**
   ```bash
   # Adicione ao .gitignore:
   appsettings.Development.json
   *.user
   .env
   ```

2. **Senhas seguras**
   - SQL Server: Mínimo 8 caracteres (maiúsculas, números)
   - RabbitMQ: Trocar "admin" em produção

3. **Variáveis de ambiente**
   - Use `appsettings.Development.json` localmente
   - Injete variáveis em produção

4. **HTTPS**
   - Habilitar para publicação em produção

5. **Dependency Updates**
   ```bash
   dotnet outdated
   dotnet package update
   ```

---

## 📝 Logs e Monitoramento

### Logs da Aplicação

```bash
# Ver logs dos últimos 100 linhas do container sqlserver
docker-compose logs --tail 100 sqlserver

# Ver logs dos últimos 100 linhas do container rabbitmq
docker-compose logs --tail 100 rabbitmq

# Combinar logs de múltiplos serviços
docker-compose logs -f sqlserver rabbitmq
```

### Níveis de Log

Em `appsettings.json`:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "MyCompany": "Debug"
    }
  }
}
```

---

## 🚨 Troubleshooting

### Problema: Porta 1433 já em uso
```bash
# Encontrar o processo usando a porta
netstat -ano | findstr :1433
# Matar o processo
taskkill /PID <PID> /F
```

### Problema: SQL Server não inicia
```bash
# Verificar logs
docker logs sqlserver
# Aumentar tempo de inicialização
docker-compose up -d sqlserver
sleep 30
```

### Problema: RabbitMQ não responde
```bash
# Reiniciar RabbitMQ
docker-compose restart rabbitmq
# Limpar dados
docker-compose down -v && docker-compose up -d
```

### Problema: Aplicação não conecta ao BD
```bash
# Verificar string de conexão
# Verificar firewall
# Verificar senha SA_PASSWORD
docker-compose logs sqlserver | grep -i error
```

---

## 📚 Recursos Adicionais

- [Documentação .NET 8](https://docs.microsoft.com/pt-br/dotnet/)
- [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [RabbitMQ Documentation](https://www.rabbitmq.com/documentation.html)
- [Docker Compose](https://docs.docker.com/compose/)
- [SQL Server on Linux](https://docs.microsoft.com/pt-br/sql/linux/)

---

## 🎯 Descrição Detalhada dos Serviços

### Responsabilidade do Lancamentos

### 📌 Características

* Salva lançamentos no banco de dados **LancamentosDB** tabela: **dbo.Lancamentos**
* Publica mensagens no RabbitMQ
* Não possui dependência direta com o Consolidado
* Modelo orientado a eventos (event-driven)

### 📤 Evento Publicado

* **Exchange**: `lancamentos.exchange`
* **Routing Key**: `lancamento.criado`
* **Fila** (bindada): `lancamentos.queue`

### 📄 Payload Exemplo

```json
{
  "dataLancamento": "2026-01-15T10:30:00",
  "valor": 150.00,
  "tipo": 1
}
```

---

## 🟨 Solução: Integrador

### 🎯 Responsabilidade

Atuar como **ponte entre eventos de lançamentos, calcular as movimentações diárias, fechar o saldo diário e efetuar a persistência no banco ConsolidadoDB**, consumindo mensagens do RabbitMQ e aplicando a lógica de consolidação.

### 🧠 Componentes Principais

* **Worker Service (.NET 8)**
* **RabbitMQ Consumer (AsyncEventingBasicConsumer)**
* **Entity Framework Core**

### 🔄 Fluxo de Processamento

1. Consome mensagem da fila `lancamentos.queue`
2. Desserializa o evento `Lancamento`
3. Busca o saldo diário correspondente
4. Cria ou atualiza o saldo consolidado
5. Persiste no banco
6. Dá **ACK** na mensagem

### ⚠️ Controle de Mensagens

* `autoAck = false`
* **ACK** (`BasicAck`) somente após sucesso
* **NACK sem requeue** em erro crítico

> Isso evita loop infinito e garante processamento idempotente.

---

## 🟩 Solução: Consolidado

### 🎯 Responsabilidade

Armazenar e manter o **saldo diário consolidado**, agrupado por data.

### 🗄️ Banco de Dados

* Tabela: `SaldosDiario`

### 📦 Entidade Principal

* **SaldoDiario**

### 🧱 Regras Importantes

* Um registro por dia
* Atualizações incrementais conforme novos lançamentos
* Entidade possui construtor vazio para compatibilidade com EF Core

---

## 🔧 Tecnologias Utilizadas

* .NET 8
* Worker Service
* RabbitMQ.Client (API moderna com IChannel)
* Entity Framework Core
* SQL Server / PostgreSQL (dependendo do ambiente)

---

## 🛡️ Boas Práticas Aplicadas

* Arquitetura orientada a eventos
* Separação clara de responsabilidades
* Uso de `IServiceScopeFactory` no Worker
* Controle manual de ACK/NACK
* Evita acoplamento entre domínios

---

## 🚀 Resultado

A solução permite:

* Escalar consumidores facilmente
* Garantir consistência no consolidado
* Reprocessar mensagens com segurança
* Evoluir cada módulo de forma independente

---

## 🔧 Próximos passos e propósta de melhorias

- Criação de uma fila no RabbiMq de Erros de negócio para serem sinalizadas em paineis via Zabbix, Grafana ou Nagios
- Criação de Testes unitários para serem validados pré commit no repositório GIT
- Adição do fluxo de Deploy automatizado pelo GitLab, Bitbucket, Jenkins ou AzureDevops
- Adição de protocolos de autorização de acesso as apis OAUTH2 ou a implantação de algoritmo proprietário de autenticação
- Dockerização das aplicações Web e Integrador para serem rodados em Kubernetes com autoscale
- Aplicação de Rate Limiting e API Gateway
- Cache distribuído (Redis)
- Testes de carga e performance


---

## 📌 Observações Finais

Esta arquitetura é ideal para cenários de:

* Processamento financeiro
* Integração entre sistemas
* Alta volumetria de eventos

Qualquer novo consumidor pode ser adicionado sem impacto nos produtores.



---

## 📄 Licença

Este projeto está licenciado sob a **Licença Apache 2.0** - veja o arquivo [LICENSE](./LICENSE) para detalhes completos.

---

## 👨‍💻 Autores

Desenvolvido como projeto de apresentação de arquitetura de software de **Arquitetura de Microserviços em .NET 8**.

---

## 📞 Contato e Suporte

- 📚 Consulte a [Documentação da Arquitetura](./documentacao/Arquitetura.drawio)

---

## 🎓 Aprendizados

Este projeto demonstra:

- ✅ Arquitetura de microserviços desacoplada
- ✅ Padrão de eventos (Event-Driven Architecture)
- ✅ Comunicação assíncrona com RabbitMQ
- ✅ Domain-Driven Design (DDD)
- ✅ Entity Framework Core com Migrations
- ✅ Containerização com Docker
- ✅ Swagger/OpenAPI documentation
- ✅ Health Checks e Resiliência
- ✅ Best Practices em .NET 8

---

## ✅ Checklist para Novo Desenvolvedor

Ao iniciar o projeto, certifique-se de:

- [ ] .NET 8.0 SDK instalado
- [ ] Docker e Docker Compose instalados
- [ ] Git configurado
- [ ] Variáveis de ambiente configuradas
- [ ] Docker Compose iniciado com sucesso
- [ ] Banco de dados migrado
- [ ] Projetos compilam sem erros
- [ ] APIs acessíveis no Swagger

---

## 📌 Status do Projeto

```
✅ Arquitetura base implementada
✅ 2 Microserviços funcionais
✅ 1 Console aplication funcional
✅ Docker Compose configurado
✅ Documentação completa
⏳ Observabilidade (próxima iteração)
⏳ Autenticação (próxima iteração)
```

---

**Última atualização**: Janeiro 16, 2026  
**Versão**: 1.0.0  
**Status**: ✅ Implementado e funcional
