using Fina.Core.Responses;
using Fina.Core.Models;
using Fina.Core.Requests.Reporters;
using Fina.Core.Models.Reports;


namespace Fina.Core.Handlers;

public interface IReportHandler
{
    Task<Response<Expanse?>> GetReportsByCategoryAsync(GetReporterByCategoryRequest request);
    // Task<Response<Expanse?>> GetReportsByExtenseBasicAsync(GetReportsByExtenseBasicRequest request);

    Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(GetIncomesAndExpensesRequest request);
    Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(GetIncomesByCategoryRequest request);
    Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(GetExpensesByCategoryRequest request);
    Task<Response<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request);
}