/* ===========================
   CRIAÇÃO DOS BANCOS
=========================== */

IF DB_ID('LancamentosDB') IS NULL
BEGIN
    PRINT 'Criando banco LancamentosDB';
    CREATE DATABASE LancamentosDB;
END
ELSE
BEGIN
    PRINT 'Banco LancamentosDB já existe';
END
GO

IF DB_ID('ConsolidadoDB') IS NULL
BEGIN
    PRINT 'Criando banco ConsolidadoDB';
    CREATE DATABASE ConsolidadoDB;
END
ELSE
BEGIN
    PRINT 'Banco ConsolidadoDB já existe';
END
GO

/* ===========================
   TABELAS - LancamentosDB
=========================== */

USE LancamentosDB;
GO

IF OBJECT_ID('dbo.Lancamentos', 'U') IS NULL
BEGIN
    PRINT 'Criando tabela Lancamentos';

    CREATE TABLE dbo.Lancamentos (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        Valor DECIMAL(18,2) NOT NULL,
        Tipo INT NOT NULL, -- 1 = Crédito | 2 = Débito
        Lancamento DATETIME2 NOT NULL,
        DataCriacao DATETIME2 NOT NULL DEFAULT SYSDATETIME()
    );

    CREATE INDEX IX_Lancamentos_Lancamento
        ON dbo.Lancamentos (Lancamento);
END
ELSE
BEGIN
    PRINT 'Tabela Lancamentos já existe';
END
GO

/* ===========================
   TABELAS - ConsolidadoDB
=========================== */

USE ConsolidadoDB;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID('dbo.SaldoDiario', 'U') IS NULL
BEGIN
    PRINT 'Criando tabela SaldoDiario';

    CREATE TABLE dbo.SaldoDiario (
        DataLancamento DATE NOT NULL PRIMARY KEY,
        TotalCreditos DECIMAL(18,2) NOT NULL,
        TotalDebitos DECIMAL(18,2) NOT NULL,
        SaldoFinal AS (TotalCreditos - TotalDebitos) PERSISTED,
        DataAlteracao DATETIME2 NOT NULL DEFAULT SYSDATETIME()
    );
END
ELSE
BEGIN
    PRINT 'Tabela SaldoDiario já existe';
END
GO
