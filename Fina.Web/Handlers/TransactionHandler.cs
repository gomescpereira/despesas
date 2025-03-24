using System.Net.Http.Json;
using Fina.Core.Common;
// Falta Colocar funções data
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Web.Handlers
{
    public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler 
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
   
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/transactions", request);
            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
            ?? new Response<Transaction?>(null, 400, "Falha ao criar Transação");
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/transactions/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
              ?? new Response<Transaction?>(null, 400, "Falha ao atualizar a Transaction");
        }

          public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
          {
            var result = await _client.DeleteAsync($"v1/transactions/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
               ?? new Response<Transaction?>(null, 400, "Falha ao excluir a Transação");

          }

          public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
           => await _client.GetFromJsonAsync<Response<Transaction?>>($"v1/transactions/{request.Id}")
           ?? new Response<Transaction?>(null, 400, "Não foi possível obter a Transação");

          public async Task<PagedResponse<List<Transaction>?>> GetAllAsync(GetAllTransactionsRequest request)
          => await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>("v1/transactions")
           ?? new PagedResponse<List<Transaction>?>(null, 400, "Não foi possível obter as transactions");
      
          public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request) 
          {
             const string format = "yyyy-MM-dd";
             var startDate = request.StartDate is not null
             ? request.StartDate.Value.ToString(format)
             : DateTime.Now.GetFirstDay().ToString(format);

            var endDate = request.EndDate is not null
             ? request.EndDate.Value.ToString(format)
             : DateTime.Now.GetLastDay().ToString(format);
        
            var url = $"v1/transactions?startDate={startDate}&endDate={endDate}";

            return await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>(url)
            ?? new PagedResponse<List<Transaction>?>(null, 400, "Não foi possível obter as transações");
          }
    }
    
}