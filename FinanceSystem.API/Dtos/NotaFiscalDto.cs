using FinanceSystem.Core.Entities;
using FinanceSystem.Core.Enums;

namespace FinanceSystem.API.Dtos
{
    public class NotaFiscalDto
    {
        public int? Id { get; set; }
        public string? Pagador { get; set; }
        public string? NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime? DataCobranca { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorNota { get; set; }
        public string? DocumentoNotaFiscal { get; set; }
        public string? DocumentoBoleto { get; set; }
        public string? Status { get; set; }
    }
}
