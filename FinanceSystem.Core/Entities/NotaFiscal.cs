using FinanceSystem.Core.Enums;

namespace FinanceSystem.Core.Entities
{
    public class NotaFiscal
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
        public StatusNotaFiscal Status { get; set; } 
    }
}
