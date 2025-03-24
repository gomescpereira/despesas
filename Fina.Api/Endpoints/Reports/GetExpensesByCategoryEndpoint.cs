using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models.Reports;
using Fina.Core.Requests.Reporters;
using Fina.Core.Responses;

namespace Fina.Api.Endpoints.Reports;

public class GetExpensesByCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/expenses", HandleAsync)
            .Produces<Response<List<ExpensesByCategory>?>>();

    private static async Task<IResult> HandleAsync(
        // ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetExpensesByCategoryRequest
        {
            UserId = ApiConfiguration.UserId,
        };
        var result = await handler.GetExpensesByCategoryReportAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}