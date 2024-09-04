using FinanceSystem.API.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSystem.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public decimal TotalNotasEmitidas { get; set; }
        public decimal TotalSemCobranca { get; set; }
        public decimal TotalNotasVencidas { get; set; }
        public decimal TotalNotasAVencer { get; set; }
        public decimal TotalNotasPagas { get; set; }
        public string[] InadimplenciaLabels { get; set; } = new string[12];
        public decimal[] InadimplenciaData { get; set; } = new decimal[12];
        public string[] ReceitaLabels { get; set; } = new string[12];
        public decimal[] ReceitaData { get; set; } = new decimal[12];

        public async Task OnGetAsync()
        {
            var notasFiscais = await _httpClient.GetFromJsonAsync<List<NotaFiscalDto>>("https://localhost:7042/api/NotasFiscais");

            if (notasFiscais != null && notasFiscais.Any())
            {
                TotalNotasEmitidas = notasFiscais.Sum(n => n.ValorNota);
                TotalSemCobranca = notasFiscais.Where(n => n.Status != "Cobrança Realizada").Sum(n => n.ValorNota);
                TotalNotasVencidas = notasFiscais.Where(n => n.DataCobranca < DateTime.Now && n.Status != "Pagamento Realizado").Sum(n => n.ValorNota);
                TotalNotasAVencer = notasFiscais.Where(n => n.DataCobranca > DateTime.Now).Sum(n => n.ValorNota);
                TotalNotasPagas = notasFiscais.Where(n => n.Status == "Pagamento Realizado").Sum(n => n.ValorNota);

                foreach (var nota in notasFiscais)
                {
                    int mes = nota.DataEmissao.Month - 1;

                    if (nota.Status == "Pagamento Atrasado" || nota.Status == "Cobrança Realizada")
                    {
                        InadimplenciaData[mes] += nota.ValorNota;
                    }

                    if (nota.Status == "Pagamento Realizado" && nota.DataPagamento.HasValue)
                    {
                        int mesPagamento = nota.DataPagamento.Value.Month - 1 ;

                        ReceitaData[mesPagamento] += nota.ValorNota;
                    }
                }
            }
            else
            {
                TotalNotasEmitidas = 0;
                TotalSemCobranca = 0;
                TotalNotasVencidas = 0;
                TotalNotasAVencer = 0;
                TotalNotasPagas = 0;
            }

            InadimplenciaLabels = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
            ReceitaLabels = InadimplenciaLabels;
        }

    }
}
