using System.ComponentModel.DataAnnotations;

namespace FinanceSystem.Core.Enums
{
    public enum StatusNotaFiscal
    {
        [Display(Name = "Emitida")]
        Emitida = 1,
        [Display(Name = "Cobrança Realizada")]
        CobrancaRealizada = 2,
        [Display(Name = "Pagamento em Atraso")]
        PagamentoEmAtraso = 3,
        [Display(Name = "Pagamento Realizado")]
        PagamentoRealizado = 4
    }
}
