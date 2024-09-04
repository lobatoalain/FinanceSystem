-- Criação do banco de dados
CREATE DATABASE SistemaFinanceiro;
GO

-- Uso do banco de dados
USE SistemaFinanceiro;
GO

-- Criação da tabela NotasFiscais
CREATE TABLE NotasFiscais (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Pagador NVARCHAR(100) NOT NULL,
    NumeroNota NVARCHAR(50) NOT NULL,
    DataEmissao DATETIME NOT NULL,
    DataCobranca DATETIME NULL,
    DataPagamento DATETIME NULL,
    ValorNota DECIMAL(18, 2) NOT NULL,
    DocumentoNotaFiscal NVARCHAR(255) NOT NULL,
    DocumentoBoleto NVARCHAR(255) NULL,
    Status INT NOT NULL
);
GO

-- Inserção de dados
INSERT INTO NotasFiscais (Pagador, NumeroNota, DataEmissao, DataCobranca, DataPagamento, ValorNota, DocumentoNotaFiscal, DocumentoBoleto, Status)
VALUES 
('Empresa A', 'NF123', CONVERT(DATETIME, '2023-01-09', 120), NULL, NULL, 1000.00, 'docs/nf123.pdf', 'docs/boleto123.pdf', 1),
('Empresa B', 'NF124', CONVERT(DATETIME, '2023-02-05', 120), CONVERT(DATETIME, '2023-02-10', 120), NULL, 1500.00, 'docs/nf124.pdf', 'docs/boleto124.pdf', 2),
('Empresa C', 'NF125', CONVERT(DATETIME, '2023-03-01', 120), CONVERT(DATETIME, '2023-03-05', 120), NULL, 2000.00, 'docs/nf125.pdf', 'docs/boleto125.pdf', 3),
('Empresa D', 'NF126', CONVERT(DATETIME, '2023-04-12', 120), CONVERT(DATETIME, '2023-04-15', 120), CONVERT(DATETIME, '2023-04-20', 120), 2500.00, 'docs/nf126.pdf', 'docs/boleto126.pdf', 4),
('Empresa E', 'NF127', CONVERT(DATETIME, '2023-05-07', 120), CONVERT(DATETIME, '2024-10-07', 120), NULL, 3000.00, 'docs/nf127.pdf', 'docs/boleto127.pdf', 2),
('Empresa F', 'NF128', CONVERT(DATETIME, '2023-05-17', 120), NULL, NULL, 2900.00, 'docs/nf128.pdf', 'docs/boleto128.pdf', 1),
('Empresa G', 'NF129', CONVERT(DATETIME, '2023-07-19', 120), CONVERT(DATETIME, '2023-08-19', 120), NULL, 3000.00, 'docs/nf129.pdf', 'docs/boleto129.pdf', 2),
('Empresa H', 'NF130', CONVERT(DATETIME, '2023-09-09', 120), CONVERT(DATETIME, '2023-10-19', 120), CONVERT(DATETIME, '2023-10-15', 120), 1000.00, 'docs/nf130.pdf', 'docs/boleto130.pdf', 4);
GO
