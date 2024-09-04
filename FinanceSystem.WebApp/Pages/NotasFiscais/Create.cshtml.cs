using FinanceSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceSystem.WebApp.Pages.NotasFiscais
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public NotaFiscal? Input { get; set; }

        public string Title { get; set; } = "Cadastrar Nota Fiscal";

        public async Task<IActionResult> OnGetAsync(int? id = null)
        {
            if (id == null)
            {
                return Page();
            }

            Title = "Editar Nota Fiscal";
            var response = await _httpClient.GetAsync($"https://localhost:7042/api/NotasFiscais/{id}");

            if (response.IsSuccessStatusCode)
            {
                var notaFiscal = await response.Content.ReadFromJsonAsync<NotaFiscal>();

                if (notaFiscal != null)
                {
                    Input = new NotaFiscal
                    {
                        Id = notaFiscal.Id,
                        Pagador = notaFiscal.Pagador,
                        NumeroNota = notaFiscal.NumeroNota,
                        DataEmissao = notaFiscal.DataEmissao,
                        DataCobranca = notaFiscal.DataCobranca,
                        DataPagamento = notaFiscal.DataPagamento,
                        ValorNota = notaFiscal.ValorNota,
                        DocumentoNotaFiscal = notaFiscal.DocumentoNotaFiscal,
                        DocumentoBoleto = notaFiscal.DocumentoBoleto,
                        Status = notaFiscal.Status
                    };
                    return Page();
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Input == null)
            {
                return Page();
            }

            HttpResponseMessage response;

            if (Input.Id == null)
            {
                response = await _httpClient.PostAsJsonAsync("https://localhost:7042/api/NotasFiscais", Input);
            }
            else
            {
                response = await _httpClient.PutAsJsonAsync($"https://localhost:7042/api/NotasFiscais/{Input.Id}", Input);
            }

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/NotasFiscais/Index");
            }

            ModelState.AddModelError(string.Empty, "Erro ao cadastrar ou editar a nota fiscal.");
            return Page();
        }
    }
}
