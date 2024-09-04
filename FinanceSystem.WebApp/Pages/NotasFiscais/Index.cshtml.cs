using FinanceSystem.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSystem.WebApp.Pages.NotasFiscais
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<NotaFiscalDto>? NotasFiscais { get; set; } = new List<NotaFiscalDto>();

        public int? MesEmissao { get; set; }
        public int? MesCobranca { get; set; }
        public int? MesPagamento { get; set; }
        public string StatusNota { get; set; } = string.Empty;

        public async Task OnGetAsync(int? mesEmissao, int? mesCobranca, int? mesPagamento, string statusNota)
        {
            MesEmissao = mesEmissao;
            MesCobranca = mesCobranca;
            MesPagamento = mesPagamento;
            StatusNota = statusNota;

            NotasFiscais = await _httpClient.GetFromJsonAsync<List<NotaFiscalDto>>("https://localhost:7042/api/NotasFiscais");

            if (MesEmissao.HasValue)
            {
                NotasFiscais = NotasFiscais!.Where(n => n.DataEmissao.Month == MesEmissao.Value).ToList();
            }
            if (MesCobranca.HasValue)
            {
                NotasFiscais = NotasFiscais!.Where(n => n.DataCobranca.HasValue && n.DataCobranca.Value.Month == MesCobranca.Value).ToList();
            }
            if (MesPagamento.HasValue)
            {
                NotasFiscais = NotasFiscais!.Where(n => n.DataPagamento.HasValue && n.DataPagamento.Value.Month == MesPagamento.Value).ToList();
            }
            if (!string.IsNullOrEmpty(StatusNota))
            {
                NotasFiscais = NotasFiscais!.Where(n => n.Status == StatusNota).ToList();
            }
        }

        public async Task<IActionResult> OnPostDeleteNotaFiscalAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7042/api/NotasFiscais/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            return NotFound();
        }

    }
}
